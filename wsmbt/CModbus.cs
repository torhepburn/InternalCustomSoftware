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

namespace WSMBT
{
   class CModbus
   {
      CTxRx TxRx;
      public CModbus (CTxRx Tx)
      {
         TxRx = Tx;
      }

      public Result ReadFlags(byte unitId, byte function, UInt16 address, UInt16 quantity, bool[] Bools, int offset)
      {
         int ReturnSize;
         UInt16 c = 0;
         UInt16 x = 0;
         int nByte;
         Result Error;

         if (function < 1 || function > 127)
            return Result.FUNCTION;
         if (quantity < 1 || quantity > 2000)
            return Result.QUANTITY;
         if ((quantity + offset) > Bools.GetLength(0))
            return Result.QUANTITY;

         byte[] TXBuf = new byte[6 + 2];
         byte[] RXBuf = new byte[3 + 256 + 2];

         TXBuf[0] = unitId;
         TXBuf[1] = function;
         TXBuf[2] = ByteAccess.HiByte(address);
         TXBuf[3] = ByteAccess.LoByte(address);
         TXBuf[4] = ByteAccess.HiByte(quantity);
         TXBuf[5] = ByteAccess.LoByte(quantity);
         ReturnSize = (quantity + 7) / 8 + 3;

         Error = TxRx.TxRx(TXBuf, 6, RXBuf, ReturnSize);

         if (Error == Result.SUCCESS)
            if ((TXBuf[0] != RXBuf[0]) || (TXBuf[1] != RXBuf[1]))
               Error = Result.RESPONSE;
            else
               if ((ReturnSize - 3) != RXBuf[2])
                  Error = Result.BYTECOUNT;
               else
               {
                  nByte = RXBuf[3];
                  for (int i = 0; i < quantity; i++)    // Unpack the flags (bits)
                  {
                     Bools[i + offset] = (nByte & 0x01) == 1;
                     nByte = nByte >> 1;
                     if (++c == 8)
                     {
                        x++;
                        c = 0;
                        nByte = RXBuf[3 + x];
                     }
                  }
               }
         return Error;
      }


      public Result ReadRegisters(byte unitId, UInt16 function, UInt16 address, UInt16 quantity, Int16[] registers, int offset)
      {
         if (function < 1 || function > 127)
            return Result.FUNCTION;
         if ((quantity < 1) || quantity > 125)
            return Result.QUANTITY;
         if ((quantity + offset) > registers.GetLength(0))
            return Result.QUANTITY;

         byte[] TXBuf = new byte[6 + 2];
         byte[] RXBuf = new byte[3 + 2 * 128 + 2];

         TXBuf[0] = unitId;
         TXBuf[1] = (byte)(function & 0xFF);
         TXBuf[2] = ByteAccess.HiByte(address);
         TXBuf[3] = ByteAccess.LoByte(address);
         TXBuf[4] = ByteAccess.HiByte(quantity);
         TXBuf[5] = ByteAccess.LoByte(quantity);

         int ReturnSize = 3 + quantity * 2;

         Result Error = TxRx.TxRx(TXBuf, 6, RXBuf, ReturnSize);

         if (Error == Result.SUCCESS)
            if ((TXBuf[0] != RXBuf[0]) || (TXBuf[1] != RXBuf[1]))
               Error = Result.RESPONSE;
            else
               if ((quantity * 2) != RXBuf[2])
                  Error = Result.BYTECOUNT;
               else
               {
                  for (int i = 0; i < quantity; i++)
                     registers[i + offset] = (Int16)(((UInt32)RXBuf[2 * i + 4] & 0xFF) | ((UInt32)RXBuf[2 * i + 3] & 0xFF) << 8);
               }

         return Error;
      }


      public Result WriteSingleCoil(byte unitId, UInt16 address, bool coil) // 05
      {
         Result Error;

         byte[] TXBuf = new byte[6 + 2];
         byte[] RXBuf = new byte[6 + 2];

         TXBuf[0] = unitId;
         TXBuf[1] = 5;
         TXBuf[2] = ByteAccess.HiByte(address);
         TXBuf[3] = ByteAccess.LoByte(address);
         TXBuf[4] = (byte)(coil ? 0xFF : 0);
         TXBuf[5] = 0;

         Error = TxRx.TxRx(TXBuf, 6, RXBuf, 6);
         if ((Error == Result.SUCCESS) && (TXBuf[0] != 0))
            for (int i = 0; i < 6; i++)
               if (TXBuf[i] != RXBuf[i])
                  Error = Result.RESPONSE;

         return Error;
      }


      public Result WriteSingleRegister(byte unitId, UInt16 address, Int16 register) // 06
      {
         Result Error;

         byte[] TXBuf = new byte[6 + 2];
         byte[] RXBuf = new byte[6 + 2];

         TXBuf[0] = unitId;
         TXBuf[1] = 6;
         TXBuf[2] = ByteAccess.HiByte(address);
         TXBuf[3] = ByteAccess.LoByte(address);
         TXBuf[4] = ByteAccess.HiByte((UInt16)register);
         TXBuf[5] = ByteAccess.LoByte((UInt16)register);

         Error = TxRx.TxRx(TXBuf, 6, RXBuf, 6);
         if ((Error == Result.SUCCESS) && (TXBuf[0] != 0))
            for (int i = 0; i < 6; i++)
               if (TXBuf[i] != RXBuf[i])
                  Error = Result.RESPONSE;

         return Error;

      }


      public Result WriteFlags(byte unitId, byte function, UInt16 address, UInt16 quantity, bool[] Bools, int offset)
      {
         Result Error;

         if (function < 1 || function > 127)
            return Result.FUNCTION;
         if ((quantity < 1) || quantity > 1968)
            return Result.QUANTITY;
         if ((quantity + offset) > Bools.GetLength(0))
            return Result.QUANTITY;

         byte[] TXBuf = new byte[7 + 2 * 128 + 2];
         byte[] RXBuf = new byte[6 + 2];

         UInt16 c = 0;
         byte nByteIndex = 7;
         byte nByte = 0;

         TXBuf[0] = unitId;
         TXBuf[1] = function;
         TXBuf[2] = ByteAccess.HiByte(address);
         TXBuf[3] = ByteAccess.LoByte(address);
         TXBuf[4] = ByteAccess.HiByte(quantity);
         TXBuf[5] = ByteAccess.LoByte(quantity);
         TXBuf[6] = (byte)((quantity + 7) / 8);

         for (int i = 0; i < quantity; i++) // Pack the flags
         {
            if (Bools[i + offset])
               nByte |= (byte)(1 << c);
            c++;
            if (c == 8)
            {
               c = 0;
               TXBuf[nByteIndex] = nByte;
               nByteIndex++;
               nByte = 0;
            }
         }
         TXBuf[nByteIndex] = nByte;

         Error = TxRx.TxRx(TXBuf, TXBuf[6] + 7, RXBuf, 6);

         if ((Error == Result.SUCCESS) && (TXBuf[0] != 0))
            for (int i = 0; i < 6; i++)
               if (TXBuf[i] != RXBuf[i])
                  Error = Result.RESPONSE;

         return Error;
      }


      public Result WriteRegisters(byte unitId, byte function, UInt16 address, UInt16 quantity, Int16[] registers, int offset)
      {
         Result Error;

         if (function < 1 || function > 127)
            return Result.FUNCTION;
         if ((quantity < 1) || quantity > 123)
            return Result.QUANTITY;
         if ((quantity + offset) > registers.GetLength(0))
            return Result.QUANTITY;

         byte[] TXBuf = new byte[7 + 2 * 128 + 2];
         byte[] RXBuf = new byte[6 + 2];

         TXBuf[0] = unitId;
         TXBuf[1] = function;
         TXBuf[2] = ByteAccess.HiByte(address);
         TXBuf[3] = ByteAccess.LoByte(address);
         TXBuf[4] = ByteAccess.HiByte(quantity);
         TXBuf[5] = ByteAccess.LoByte(quantity);
         TXBuf[6] = (byte)(quantity * 2);

         for (int i = 0; i < quantity; i++)
         {
            TXBuf[7 + i * 2] = ByteAccess.HiByte((UInt16)registers[i + offset]);
            TXBuf[7 + i * 2 + 1] = ByteAccess.LoByte((UInt16)registers[i + offset]);
         }

         Error = TxRx.TxRx(TXBuf, TXBuf[6] + 7, RXBuf, 6);

         if ((Error == Result.SUCCESS) && (TXBuf[0] != 0))
            for (int i = 0; i < 6; i++)
               if (TXBuf[i] != RXBuf[i])
                  Error = Result.RESPONSE;

         return Error;
      }


      public Result MaskWriteRegister(byte unitId, UInt16 address, UInt16 ANDMask, UInt16 ORMask) // 22
      {
         Result Error;

         byte[] TXBuf = new byte[8 + 2];
         byte[] RXBuf = new byte[8 + 2];

         TXBuf[0] = unitId;
         TXBuf[1] = 22;
         TXBuf[2] = ByteAccess.HiByte(address);
         TXBuf[3] = ByteAccess.LoByte(address);
         TXBuf[4] = ByteAccess.HiByte(ANDMask);
         TXBuf[5] = ByteAccess.LoByte(ANDMask);
         TXBuf[6] = ByteAccess.HiByte(ORMask);
         TXBuf[7] = ByteAccess.LoByte(ORMask);

         Error = TxRx.TxRx(TXBuf, 8, RXBuf, 8);

         if ((Error == Result.SUCCESS) && (TXBuf[0] != 0))
            for (int i = 0; i < 8; i++)
               if (TXBuf[i] != RXBuf[i])
                  Error = Result.RESPONSE;

         return Error;
      }


      public Result ReadWriteMultipleRegisters(byte unitId,
                                        UInt16 readAddress,
                                        UInt16 readSize,
                                        Int16[] readRegisters,
                                        UInt16 writeAddress,
                                        UInt16 writeSize,
                                        Int16[] writeRegisters) // 23
      {
         int ReturnSize;
         Result Error;
         if ((readSize < 1) || readSize > 123)
            return Result.QUANTITY;
         if ((writeSize < 1) || writeSize > 121)
            return Result.QUANTITY;

         if (readSize > readRegisters.GetLength(0))
            return Result.QUANTITY;
         if (writeSize > writeRegisters.GetLength(0))
            return Result.QUANTITY;

         byte[] TXBuf = new byte[11 + 2 * 128 + 2];
         byte[] RXBuf = new byte[3 + 2 * 128 + 2];

         TXBuf[0] = unitId;
         TXBuf[1] = 23;
         TXBuf[2] = ByteAccess.HiByte(readAddress);
         TXBuf[3] = ByteAccess.LoByte(readAddress);
         TXBuf[4] = ByteAccess.HiByte(readSize);
         TXBuf[5] = ByteAccess.LoByte(readSize);
         TXBuf[6] = ByteAccess.HiByte(writeAddress);
         TXBuf[7] = ByteAccess.LoByte(writeAddress);
         TXBuf[8] = ByteAccess.HiByte(writeSize);
         TXBuf[9] = ByteAccess.LoByte(writeSize);
         TXBuf[10] = (byte)(writeSize * 2);

         ReturnSize = 3 + readSize * 2; // ReadSize * 2[bytes] + ID + function + nbr of bytes

         for (int i = 0; i < writeSize; i++)
         {
            TXBuf[11 + i * 2] = ByteAccess.HiByte((UInt16)writeRegisters[i]);
            TXBuf[11 + i * 2 + 1] = ByteAccess.LoByte((UInt16)writeRegisters[i]);
         }

         Error = TxRx.TxRx(TXBuf, TXBuf[10] + 11, RXBuf, ReturnSize);

         if (Error == Result.SUCCESS)
            if ((TXBuf[0] != RXBuf[0]) || (TXBuf[1] != RXBuf[1]))
               Error = Result.RESPONSE;
            else
            {
               for (int i = 0; i < readSize; i++)
                  readRegisters[i] = (Int16)ByteAccess.MakeWord(RXBuf[2 * i + 4], RXBuf[2 * i + 3]);
            }
         return Error;
      }

      
      public Result ReportSlaveID(byte unitId, out byte byteCount, byte[] deviceSpecific) // 17
      {
         Result Error;

         byte[] TXBuf = new byte[4];
         byte[] RXBuf = new byte[255];

         TXBuf[0] = unitId;
         TXBuf[1] = 17;

         byteCount = 0;
         Error = TxRx.TxRx(TXBuf, 2, RXBuf, int.MaxValue);

         if (Error == Result.SUCCESS)
            if (TXBuf[0] != RXBuf[0])
               Error = Result.RESPONSE;
            else
            {
               byteCount = RXBuf[2];
               int count = Math.Min(RXBuf[2], deviceSpecific.GetLength(0));
               for (int i = 0; i < count; i++)
                  deviceSpecific[i] = RXBuf[i + 3];
            }

         return Error;
      }
   }
}
