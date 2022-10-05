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


namespace WSMBT
{

   ///<summary>This table lists all enumerations defined in Result.</summary>
   /// <seealso cref="WSMBT.WSMBTControl.GetLastErrorString">GetLastErrorString</seealso>
   public enum Result
   {
      ///<summary>0 - No error.</summary>
      SUCCESS = 0,

      ///<summary>1 - Illegal function.</summary>
      ILLEGAL_FUNCTION = 1,
      ///<summary>2 - Illegal data address.</summary>
      ILLEGAL_DATA_ADDRESS = 2,
      ///<summary>3 - Illegal data value.</summary>
      ILLEGAL_DATA_VALUE = 3,
      ///<summary>4 - Slave device failure.</summary>
      SLAVE_DEVICE_FAILURE = 4,
      ///<summary>5 - Acknowledge.</summary>
      ACKNOWLEDGE = 5,
      ///<summary>6 - Slave device busy.</summary>
      SLAVE_DEVICE_BUSY = 6,
      ///<summary>7 - Negative acknowledge.</summary>
      NEGATIVE_ACKNOWLEDGE = 7,
      ///<summary>8 - Memory parity error.</summary>
      MEMORY_PARITY_ERROR = 8,
      ///<summary>10 - Gateway path unavailable.</summary>
      GATEWAY_PATH_UNAVAILABLE = 10,
      ///<summary>11 - Gateway target device failed to respond.</summary>
      GATEWAY_DEVICE_FAILED = 11,

      ///<summary>200 - TCP/IP Connection error. Call <see cref="WSMBT.WSMBTControl.GetLastErrorString">GetLastErrorString</see> for more information.</summary>
      CONNECT_ERROR = 200,
      ///<summary>201 - Could not connect within the specified time.</summary>
      CONNECT_TIMEOUT = 201,
      ///<summary>202 - Write error. Call <see cref="WSMBT.WSMBTControl.GetLastErrorString">GetLastErrorString</see> for more information.</summary>
      WRITE = 202,
      ///<summary>203 - Read error. Call <see cref="WSMBT.WSMBTControl.GetLastErrorString">GetLastErrorString</see> for more information.</summary>
      READ = 203,

      ///<summary>300 - Response timeout.</summary>
      RESPONSE_TIMEOUT = 300,
      ///<summary>301 - Connection is closed.</summary>
      ISCLOSED = 301,
      ///<summary>302 - CRC Error.</summary>
      CRC = 302,
      ///<summary>303 - Not the expected response received.</summary>
      RESPONSE = 303,
      ///<summary>304 - Byte count error.</summary>
      BYTECOUNT = 304,
      ///<summary>305 - Quantity is out of range.</summary>
      QUANTITY = 305,
      ///<summary>306 - Function out of range. 1 - 127.</summary>
      FUNCTION = 306,
      ///<summary>307 - Transaction ID did not match. Try increase the response timeout.</summary>
      TRANSACTIONID = 307,

      ///<summary>1000 - Demo mode expired. Restart your application to continue.</summary>
      DEMO_TIMEOUT = 1000,
   };

   ///<summary>Specify the protocol to use.</summary>
   public enum Mode
   {
      ///<summary>Modbus TCP/IP. Default mode and according to the Modbus specification.</summary>
      TCP_IP = 0,
      ///<summary>Modbus RTU over TCP/IP. A Modbus RTU message embedded in TCP packet.</summary>
      RTU_OVER_TCP_IP = 1,
      ///<summary>Modbus ASCII over TCP/IP. A Modbus ASCII message embedded in TCP packet.</summary>
      ASCII_OVER_TCP_IP
//      ///<summary>Modbus UDP/IP.</summary>
//      UDP_IP,
   };
}