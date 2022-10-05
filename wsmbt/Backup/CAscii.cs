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
   class CAscii
   {
      public static byte Num2Ascii(byte nNum)
      {
         if (nNum <= 9)
            return (byte)(nNum + '0');
         else
            if ((nNum >= 0xA) && (nNum <= 0xF))
               return (byte)(nNum - 0xA + 'A');
            else
               return (byte)'0';

      }

      public static byte Ascii2Num(byte nChar)
      {
         if ((nChar >= '0') && (nChar <= '9'))
            return (byte)(nChar - '0');
         else
            if ((nChar >= 'A') && (nChar <= 'F'))
               return (byte)(nChar - 'A' + 0xA);
            else
               return 0;
      }

      public static byte HiLo4BitsToByte(byte nHi, byte nLo)
      {
         return (byte)(((0xF & nHi) << 4) | (0xF & nLo));

      }

      public static void RTU2ASCII(byte[] nRtu, int Size, byte[] nAscii)
      {
         for (int i = 0; i < Size; i++)
         {       // The first index is reserved for ':'
            nAscii[1 + i * 2] = Num2Ascii(ByteAccess.HI4BITS(nRtu[i]));
            nAscii[1 + i * 2 + 1] = Num2Ascii(ByteAccess.LO4BITS(nRtu[i]));
         }
      }

      public static byte LRC(byte[] nMsg, int DataLen)
      {
         byte nLRC = 0; // LRC char initialized

         for (int i = 0; i < DataLen; i++)
            nLRC += nMsg[i];

         return (byte)(-nLRC);
      }

      public static byte LRCASCII(byte[] MsgASCII, int DataLen)
      {
         byte nLRC = 0; // LRC char initialized
         byte nTemp = 0;

         int DataSize = (DataLen - 5) / 2;

         for (int i = 0; i < DataSize; i++)
         {
            nTemp = HiLo4BitsToByte(Ascii2Num(MsgASCII[1 + i * 2]),
                                    Ascii2Num(MsgASCII[1 + i * 2 + 1]));
            nLRC += nTemp;
         }

         return (byte)(-nLRC);
      }

      public static bool VerifyRespLRC(byte[] Resp, int Length)
      {
         byte LRC;
         byte MsgLRC;

         if (Length < 5)
            return false;

         LRC = LRCASCII(Resp, Length);
         MsgLRC = HiLo4BitsToByte(Ascii2Num(Resp[Length - 4]),
                                  Ascii2Num(Resp[Length - 3]));

         return (LRC == MsgLRC);
      }
   }
}
