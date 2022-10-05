// WSMBT
//
// Copyright (C) 2011 - Brian Witte
// Witte Software
//
// You may not distribute the source code nor documentation,
// in whole or in part, to any third-party without the expressed
// written consent of Witte Software
//
// You may utilize the supplied software and documentation in
// anyway desired for development of its own in-house software product.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;


namespace WSMBT
{


   class CTxRx
   {
      private Mode _Mode = Mode.TCP_IP;
      private TcpClient client;
      private string Error = "";
      int Time = 0;
      private int _Timeout = 1000;

      UInt16 TransactionID = 0;
      private byte[] _TxBuf = new byte[600];
      private byte[] _RxBuf = new byte[600];
      private int _TxBufSize = 0;
      private int _RxBufSize = 0;

      public CTxRx()
      {
      }

      public void SetClient (TcpClient _client)
      {
         client = _client;
      }

      public Mode Mode
      {
         get { return this._Mode; }
         set { this._Mode = value; }
      }

      public int Timeout
      {
         get { return this._Timeout; }
         set { this._Timeout = value; }
      }

      public string GetErrorMessage()
      {
         return Error;
      }

      public int GetTxBuffer(byte[] byteArray)
      {
         if (byteArray.GetLength(0) >= _TxBufSize)
         {
            Array.Copy(_TxBuf, byteArray, _TxBufSize);
            return _TxBufSize;
         }
         else
            return 0;
      }

      public int GetRxBuffer(byte[] byteArray)
      {
         if (byteArray.GetLength(0) >= _RxBufSize)
         {
            Array.Copy(_RxBuf, byteArray, _RxBufSize);
            return _RxBufSize;
         }
         else
            return 0;
      }

      public Result TxRx(byte[] TXBuf, int QueryLength, byte[] RXBuf, int ResponseLength)
      {
         int tick = Environment.TickCount & Int32.MaxValue;
         _TxBufSize = 0;
         _RxBufSize = 0;


         // Be sure to wait a least 4ms before send another request
         Result Res;
         if ((tick - Time) < 20)  // Resolution of TickCount is 15ms
         {
            System.Threading.Thread.Sleep(4);
         }
         if (client == null)
            return Result.ISCLOSED;

         try
         {
            if (!client.Connected)
               return Result.ISCLOSED;
         }
         catch (Exception e)
         {
            Error = e.Message;
            return Result.ISCLOSED;
         }


         switch (_Mode)
         {
            case Mode.TCP_IP:
               if (ResponseLength == int.MaxValue)  // ReportSlaveID expected
                  return Result.ILLEGAL_FUNCTION;
               Res = TxRxTCP(TXBuf, QueryLength, RXBuf, ResponseLength);
               break;

            case Mode.RTU_OVER_TCP_IP:
               Res = TxRxRTUOverTCP(TXBuf, QueryLength, RXBuf, ResponseLength);
               break;

            case Mode.ASCII_OVER_TCP_IP:
               Res = TxRxASCIIOverTCP(TXBuf, QueryLength, RXBuf, ResponseLength);
               break;

            default:
               Res = Result.SUCCESS;
               break;
         }
         Time = Environment.TickCount;
         return Res;
      }

      // //////////////////////////////////////////////////////////////////////////////////////////////////////
      private void DiscardReadBuffer()
      {
         byte[] Buf = new byte[100];
         if (client.GetStream().CanRead)
         {
            while (client.GetStream().DataAvailable)
            {
               client.GetStream().Read(Buf, 0, 100);
            }
         }
      }

      private bool ResponseTimeout()
      {
         int time1 = Environment.TickCount & Int32.MaxValue;
         int sleeptime = _Timeout / 100;
         if (sleeptime == 0)
            sleeptime = 1;

         while (!client.GetStream().DataAvailable)
         {
            int time2 = Environment.TickCount & Int32.MaxValue;
            if (Math.Abs(time2 - time1) > _Timeout)
               return true;

            System.Threading.Thread.Sleep(sleeptime);
         }
         return false;
      }

      // //////////////////////////////////////////////////////////////////////////////////////////////////////
      private Result TxRxTCP(byte[] TXBuf, int QueryLength, byte[] RXBuf, int ResponseLength)
      {
         int NumberOfBytesRead = 0;
         TransactionID++;

         // build request of form 0 0 0 0 0 6 ui 3 rr rr nn nn
         for (int i = 0; i < 5; i++) _TxBuf[i] = 0;
         _TxBuf[0] = (byte)(TransactionID >> 8);
         _TxBuf[1] = (byte)(TransactionID & 0xFF);
         _TxBuf[4] = (byte)(QueryLength >> 8);
         _TxBuf[5] = (byte)(QueryLength & 0xFF);
         for (int n = 0; n < QueryLength; n++)
            _TxBuf[6 + n] = TXBuf[n];

         if (client.GetStream().CanWrite)
         {
            try
            {
               client.GetStream().Write(_TxBuf, 0, QueryLength + 6);
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.WRITE;
            }
         }
         else
         {
            Error = "You cannot write to this NetworkStream.";
            return Result.WRITE;
         }

         _TxBufSize = QueryLength + 6;

         if (client.GetStream().CanRead)
         {
            try
            {
               do
               {
                  if (ResponseTimeout())
                     return Result.RESPONSE_TIMEOUT;
                  NumberOfBytesRead += client.GetStream().Read(_RxBuf, NumberOfBytesRead, (ResponseLength + 6) - NumberOfBytesRead);
                  if (NumberOfBytesRead == 0)
                     return Result.RESPONSE_TIMEOUT;

                  if (NumberOfBytesRead == 9)
                  {
                     if (_TxBuf[1 + 6] > 0x80)
                     {
                         _RxBufSize = NumberOfBytesRead;
                         return (Result)_TxBuf[2 + 6];
                     }
                  }
               } while (NumberOfBytesRead < (ResponseLength + 6));

               if (TransactionID != ByteAccess.MakeWord(_RxBuf[0], _RxBuf[1]))
               {  // Empty the buffer
                  DiscardReadBuffer();
                  _RxBufSize = NumberOfBytesRead;
                  return Result.TRANSACTIONID;
               }
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.READ;
            }
            finally
            {
               _RxBufSize = NumberOfBytesRead;
            }
         }
         else
         {
            Error = "You cannot read from this NetworkStream.";
            return Result.READ;
         }

         if (NumberOfBytesRead - 6 < ResponseLength)
            return Result.RESPONSE_TIMEOUT;

         for (int n = 0; n < (Math.Min(NumberOfBytesRead, (ResponseLength + 6)) - 6); n++)
            RXBuf[n] = _RxBuf[n + 6];

         return Result.SUCCESS;
      }

// //////////////////////////////////////////////////////////////////////////////////////////////////////
      private Result TxRxRTUOverTCP(byte[] TXBuf, int QueryLength, byte[] RXBuf, int ResponseLength)
      {
         int NumberOfBytesRead = 0;

         byte[] crc = CCRC16.CRC16(TXBuf, QueryLength);
         TXBuf[QueryLength] = crc[0];
         TXBuf[QueryLength + 1] = crc[1];

         DiscardReadBuffer();           // Discard the receive buffer

         if (client.GetStream().CanWrite)
         {
            try
            {
               client.GetStream().Write(TXBuf, 0, QueryLength + 2);
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.WRITE;
            }
         }
         else
         {
            Error = "You cannot write to this NetworkStream.";
            return Result.WRITE;
         }

         _TxBufSize = QueryLength + 2;
         Array.Copy(TXBuf, _TxBuf, _TxBufSize);

         if (TXBuf[0] == 0) // Broadcast
            return Result.SUCCESS;

         if (client.GetStream().CanRead)
         {
            try
            {
               // First read 5 = 3 + 2
               do
               {
                  if (ResponseTimeout())
                     return Result.RESPONSE_TIMEOUT;
                  int read = client.GetStream().Read(RXBuf, NumberOfBytesRead, 5 - NumberOfBytesRead);
                  NumberOfBytesRead += read;
                  if (NumberOfBytesRead == 0)
                     return Result.RESPONSE_TIMEOUT;
               } while ((5 - NumberOfBytesRead) > 0);
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.READ;
            }
            finally
            {
               _RxBufSize = NumberOfBytesRead;
               Array.Copy(RXBuf, _RxBuf, _RxBufSize);
            }

            if (RXBuf[1] > 0x80)  // Could be an exception response
            {
               byte[] b = CCRC16.CRC16(RXBuf, 5);
               if ((b[0] != 0) || (b[1] != 0))
                  return Result.CRC;
               else
                  return (Result)RXBuf[2];  // It was an exception response
            }

            if (ResponseLength == int.MaxValue)  // ReportSlaveID expected
            {
               if (RXBuf[1] == 17)               // It is ReportSlaveID
                  ResponseLength = RXBuf[2] + 3;
               else
               {
                  DiscardReadBuffer();           // Discard the receive buffer
                  return Result.RESPONSE;        // Not expected response
               }
            }

            try
            {
               int toRead = ResponseLength + 2;
               do
               {
                  if (ResponseTimeout())
                     return Result.RESPONSE_TIMEOUT;
                  int read = client.GetStream().Read(RXBuf, NumberOfBytesRead, toRead - NumberOfBytesRead);
                  NumberOfBytesRead += read;
               } while ((toRead - NumberOfBytesRead) > 0);
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.READ;
            }
            finally
            {
               _RxBufSize = NumberOfBytesRead;
               Array.Copy(RXBuf, _RxBuf, _RxBufSize);
            }
         }
         else
         {
            Error = "You cannot read from this NetworkStream.";
            return Result.READ;
         }

         byte[] a = CCRC16.CRC16(RXBuf, ResponseLength + 2);

         if ((a[0] != 0) || (a[1] != 0))
            return Result.CRC;

         return Result.SUCCESS;
      }

// //////////////////////////////////////////////////////////////////////////////////////////////////////
      private Result TxRxASCIIOverTCP(byte[] TXBuf, int QueryLength, byte[] RXBuf, int ResponseLength)
      {
      byte LRC;
      int NumberOfBytesRead = 0;
      byte[] nTxBuf = new byte[(7 + 2 * 128) * 2 + 5];
      byte[] nRxBuf = new byte[(3 + 2 * 128) * 2 + 5];


         CAscii.RTU2ASCII (TXBuf, QueryLength, nTxBuf);
         LRC = CAscii.LRC (TXBuf, QueryLength);

         nTxBuf[0] = (byte)':';
         nTxBuf[QueryLength * 2 + 1] = CAscii.Num2Ascii (ByteAccess.HI4BITS(LRC));
         nTxBuf[QueryLength * 2 + 2] = CAscii.Num2Ascii(ByteAccess.LO4BITS(LRC));
         nTxBuf[QueryLength * 2 + 3] = 13;  // C_R
         nTxBuf[QueryLength * 2 + 4] = 10;  // L_F;

         DiscardReadBuffer();           // Discard the receive buffer

         if (client.GetStream().CanWrite)
         {
            try
            {
               client.GetStream().Write(nTxBuf, 0, QueryLength * 2 + 5);
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.WRITE;
            }
         }
         else
         {
            Error = "You cannot write to this NetworkStream.";
            return Result.WRITE;
         }

         _TxBufSize = QueryLength * 2 + 5;
         Array.Copy(nTxBuf, _TxBuf, _TxBufSize);

         if (TXBuf[0] == 0) // Broadcast
            return Result.SUCCESS;

         if (client.GetStream().CanRead)
         {
            try
            {
               // First read 11 = 1 + 3 * 2 + 2 + 2
               do
               {
                  if (ResponseTimeout())
                     return Result.RESPONSE_TIMEOUT;
                  int read = client.GetStream().Read(nRxBuf, NumberOfBytesRead, 11 - NumberOfBytesRead);
                  NumberOfBytesRead += read;
                  if (NumberOfBytesRead == 0)
                     return Result.RESPONSE_TIMEOUT;
               } while ((11 - NumberOfBytesRead) > 0);
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.READ;
            }
            finally
            {
               _RxBufSize = NumberOfBytesRead;
               Array.Copy(nRxBuf, _RxBuf, _RxBufSize);
            }

            if (CAscii.HiLo4BitsToByte(CAscii.Ascii2Num(nRxBuf[3]), CAscii.Ascii2Num(nRxBuf[4])) > 0x80)
            {
               if (!CAscii.VerifyRespLRC(nRxBuf, 11))
                  return Result.CRC;
               else
                  return (Result)(CAscii.HiLo4BitsToByte(CAscii.Ascii2Num(nRxBuf[5]), CAscii.Ascii2Num(nRxBuf[6])));
            }

            if (ResponseLength == int.MaxValue)  // ReportSlaveID expected
            {
               if (CAscii.HiLo4BitsToByte(CAscii.Ascii2Num(nRxBuf[3]), CAscii.Ascii2Num(nRxBuf[4])) == 17)  // It is ReportSlaveID
                  ResponseLength = CAscii.HiLo4BitsToByte(CAscii.Ascii2Num(nRxBuf[5]), CAscii.Ascii2Num(nRxBuf[6])) + 3;
               else
               {
                  DiscardReadBuffer();           // Discard the receive buffer
                  return Result.RESPONSE;        // Not expected response
               }
            }

            try
            {
               int toRead = (ResponseLength * 2 + 5);
               do
               {
                  if (ResponseTimeout())
                     return Result.RESPONSE_TIMEOUT;
                  int read = client.GetStream().Read(nRxBuf, NumberOfBytesRead, toRead - NumberOfBytesRead);
                  NumberOfBytesRead += read;
               } while ((toRead - NumberOfBytesRead) > 0);
            }
            catch (Exception e)
            {
               Error = e.Message;
               return Result.READ;
            }
            finally
            {
               _RxBufSize = NumberOfBytesRead;
               Array.Copy(nRxBuf, _RxBuf, _RxBufSize);
            }
         }
         else
         {
            Error = "You cannot read from this NetworkStream.";
            return Result.READ;
         }

         if (!CAscii.VerifyRespLRC(nRxBuf, NumberOfBytesRead))
            return Result.CRC;
         // CR                                       LF
         if ((nRxBuf[NumberOfBytesRead - 2] != 13) || (nRxBuf[NumberOfBytesRead - 1] != 10))
            return Result.RESPONSE;

         int Size = (NumberOfBytesRead - 5) / 2;
         for (int i = 0; i < Size; i++)
            RXBuf[i] = CAscii.HiLo4BitsToByte(CAscii.Ascii2Num(nRxBuf[1 + i * 2]),
                                              CAscii.Ascii2Num(nRxBuf[2 + i * 2]));

         return Result.SUCCESS;
      }
   }
}
