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
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net.Sockets;


namespace WSMBT
{


   /// <summary>
   /// The Modbus Master TCP/IP Class.
   /// </summary>
   ///
   /// WARNING: If you change the name of this class, you will need to change the
   ///          'Resource File Name' property for the managed resource compiler tool
   ///          associated with all .resx files this class depends on.  Otherwise,
   ///          the designers will not be able to interact properly with localized
   ///          resources associated with this form.
   public partial class WSMBTControl : Component
   {
      CModbus Modbus;
      TcpClient client;
      CTxRx TxRx;
      private int _ResponseTimeout = 1000;
      private int _ConnectTimeout = 1000;
      private Mode _Mode = Mode.TCP_IP;

      string Error = "";
      Result Res = Result.SUCCESS;


      /// <summary>
      /// Initializes a new instance of the WSMBTControl class.
      /// </summary>
      public WSMBTControl()
      {
         InitializeComponent();

         Modbus = new CModbus(TxRx = new CTxRx());

         TxRx.Mode = Mode.TCP_IP;
      }

      /// <summary>
      /// Initializes a new instance of the WSMBTControl class together with the specified container.
      /// </summary>
      /// <param name="container">An IContainer that represents the container for the WSMBTControl.</param>
      public WSMBTControl(IContainer container)
      {
         container.Add(this);

         InitializeComponent();

         Modbus = new CModbus(TxRx = new CTxRx());

         TxRx.Mode = Mode.TCP_IP;
      }

      /// <summary>
      /// Gets or sets the Modbus protocol mode.
      /// </summary>
      /// <example>
      /// This example shows how to set the Mode to Modbus TCP/IP.
      /// <code lang="c#">
      /// wsmbtControl1.Mode = WSMBT.Mode.TCP_IP;
      /// </code>
      /// <code lang="vbnet">
      /// WsmbtControl1.Mode = WSMBT.Mode.TCP_IP
      /// </code>
      /// <code lang="cpp">
      /// wsmbtControl1->Mode = WSMBT::Mode::TCP_IP;
      /// </code>
      /// </example>
      /// <remarks>The default value is Modbus TCP/IP.</remarks>
      [Category("Modbus")]
      [Description("Select which protocol mode to use.")]
      public Mode Mode
      {
         get { return _Mode; }
         set { _Mode = value; }
      }

            /// <summary>
      /// Gets or sets the Max time to wait for response.
      /// </summary>
      /// <example>
      /// This example shows how to set the Response Timeout to 500ms.
      /// <code lang="c#">
      /// wsmbtControl1.ResponseTimeout = 500;
      /// </code>
      /// <code lang="vbnet">
      /// WsmbtControl1.ResponseTimeout = 500
      /// </code>
      /// <code lang="cpp">
      /// wsmbtControl1->ResponseTimeout = 500;
      /// </code>
      /// </example>
      /// <remarks>The default value is 1000.</remarks>
      [Category("Modbus")]
      [Description("Max time to wait for response 100 - 30000ms.")]
      public int ResponseTimeout
      {
         get
         {
            return _ResponseTimeout;
         }
         set
         {
            if ((value >= 100) && (value <= 30000))
               _ResponseTimeout = value;
         }
      }

      /// <summary>
      /// Gets or sets the Max time to wait for connection.
      /// </summary>
      /// <remarks>Set the Connect Timeout before Connect. The default value is 3000.</remarks>
      /// <example>
      /// This example shows how to set the Connect Timeout to 2000ms.
      /// <code lang="c#">
      /// wsmbtControl1.ConnectTimeout = 2000;
      /// </code>
      /// <code lang="vbnet">
      /// WsmbtControl1.ConnectTimeout = 2000
      /// </code>
      /// <code lang="cpp">
      /// wsmbtControl1->ConnectTimeout = 2000;
      /// </code>
      /// </example>
      [Category("Modbus")]
      [Description("Max time to wait for connection 100 - 30000ms.")]
      public int ConnectTimeout
      {
         get { return _ConnectTimeout; }
         set
         {
            if ((value >= 100) && (value <= 30000))
               _ConnectTimeout = value;
         }
      }

      /// <summary>
      /// Modbus function 01 (0x01). Read Coils. 0X references.
      /// <para>This function code is used to read from 1 to 2000 contiguous status of coils in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to read 1-2000.</param>
      /// <param name="coils">Array to hold the values.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result.</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 coils.
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadCoils(1, 0, 10, coils);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As boolean
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadCoils(1, 0, 10, coils)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadCoils(1, 0, 10, coils);
      /// </code>
      /// </example>
      public Result ReadCoils(byte unitId, UInt16 address, UInt16 quantity, bool[] coils)
      {
         return Res = Modbus.ReadFlags(unitId, 1, address, quantity, coils, 0);
      }

      /// <summary>
      /// Modbus function 01 (0x01). Read Coils. 0X references.
      /// <para>This function code is used to read from 1 to 2000 contiguous status of coils in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to read 1-2000.</param>
      /// <param name="coils">Array to hold the values.</param>
      /// <param name="offset">The offset in the coils array to begin writing.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result.</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 coils.
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadCoils(1, 0, 10, coils, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As boolean
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadCoils(1, 0, 10, coils, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadCoils(1, 0, 10, coils, 0);
      /// </code>
      /// </example>
      public Result ReadCoils(byte unitId, UInt16 address, UInt16 quantity, bool[] coils, int offset)
      {
         return Res = Modbus.ReadFlags(unitId, 1, address, quantity, coils, offset);
      }

      /// <summary>
      /// Modbus function 02 (0x02). Read Discrete Inputs. 1X references.
      /// <para>This function code is used to read from 1 to 2000 contiguous status of discrete inputs in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of inputs to read 1-2000.</param>
      /// <param name="discreteInputs">Array to hold the values.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 Discrete Inputs.
      /// <code lang="c#">
      /// bool[] discreteInputs = new bool[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadDiscreteInputs(1, 0, 10, discreteInputs);
      /// </code>
      /// <code lang="vbnet">
      /// Dim discreteInputs(10) As boolean
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadDiscreteInputs(1, 0, 10, discreteInputs)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ discreteInputs = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadDiscreteInputs(1, 0, 10, discreteInputs);
      /// </code>
      /// </example>
      public Result ReadDiscreteInputs(byte unitId, UInt16 address, UInt16 quantity, bool[] discreteInputs)
      {
         return Res = Modbus.ReadFlags(unitId, 2, address, quantity, discreteInputs, 0);
      }

      /// <summary>
      /// Modbus function 02 (0x02). Read Discrete Inputs. 1X references.
      /// <para>This function code is used to read from 1 to 2000 contiguous status of discrete inputs in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of inputs to read 1-2000.</param>
      /// <param name="discreteInputs">Array to hold the values.</param>
      /// <param name="offset">The offset in the discreteInputs array to begin writing.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 Discrete Inputs.
      /// <code lang="c#">
      /// bool[] discreteInputs = new bool[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadDiscreteInputs(1, 0, 10, discreteInputs, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim discreteInputs(10) As boolean
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadDiscreteInputs(1, 0, 10, discreteInputs, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ discreteInputs = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadDiscreteInputs(1, 0, 10, discreteInputs, 0);
      /// </code>
      /// </example>
      public Result ReadDiscreteInputs(byte unitId, UInt16 address, UInt16 quantity, bool[] discreteInputs, int offset)
      {
         return Res = Modbus.ReadFlags(unitId, 2, address, quantity, discreteInputs, offset);
      }

      /// <summary>
      /// Modbus function 03 (0x03). Read Holding Registers. 4X references.
      /// <para>This function code is used to read the contents of a contiguous block of holding registers in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of holding registers to read 1-125.</param>
      /// <param name="registers">Array to hold the values.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 holding registers.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadHoldingRegisters(1, 0, 10, registers);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadHoldingRegisters(1, 0, 10, registers)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadHoldingRegisters(1, 0, 10, registers);
      /// </code>
      /// </example>
      public Result ReadHoldingRegisters(byte unitId, UInt16 address, UInt16 quantity, Int16[] registers)
      {
         return Res = Modbus.ReadRegisters(unitId, 3, address, quantity, registers, 0);
      }

      /// <summary>
      /// Modbus function 03 (0x03). Read Holding Registers. 4X references.
      /// <para>This function code is used to read the contents of a contiguous block of holding registers in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of holding registers to read 1-125.</param>
      /// <param name="registers">Array to hold the values.</param>
      /// <param name="offset">The offset in the registers array to begin writing.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 holding registers.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadHoldingRegisters(1, 0, 10, registers, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadHoldingRegisters(1, 0, 10, registers, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadHoldingRegisters(1, 0, 10, registers, 0);
      /// </code>
      /// </example>
      public Result ReadHoldingRegisters(byte unitId, UInt16 address, UInt16 quantity, Int16[] registers, int offset)
      {
         return Res = Modbus.ReadRegisters(unitId, 3, address, quantity, registers, offset);
      }

      /// <summary>
      /// Modbus function 04 (0x04). Read Input Registers. 3X references.
      /// <para>This function code is used to read from 1 to 125 contiguous input registers in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of inputs registers to read 1-125.</param>
      /// <param name="registers">Array to hold the values.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 input registers.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadInputRegisters(1, 0, 10, registers);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadInputRegisters(1, 0, 10, registers)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadInputRegisters(1, 0, 10, registers);
      /// </code>
      /// </example>
      public Result ReadInputRegisters(byte unitId, UInt16 address, UInt16 quantity, Int16[] registers)
      {
         return Res = Modbus.ReadRegisters(unitId, 4, address, quantity, registers, 0);
      }

      /// <summary>
      /// Modbus function 04 (0x04). Read Input Registers. 3X references.
      /// <para>This function code is used to read from 1 to 125 contiguous input registers in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of inputs registers to read 1-125.</param>
      /// <param name="registers">Array to hold the values.</param>
      /// <param name="offset">The offset in the registers array to begin writing.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 input registers.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadInputRegisters(1, 0, 10, registers, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadInputRegisters(1, 0, 10, registers, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadInputRegisters(1, 0, 10, registers, 0);
      /// </code>
      /// </example>
      public Result ReadInputRegisters(byte unitId, UInt16 address, UInt16 quantity, Int16[] registers, int offset)
      {
         return Res = Modbus.ReadRegisters(unitId, 4, address, quantity, registers, offset);
      }

      /// <summary>
      /// Modbus function 05 (0x05). Write Single Coil. 0X references.
      /// <para>This function code is used to write a single output to either ON or OFF in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="coil">The value of the coil to write. 0 or 1.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to write a "1" to address 0.
      /// <code lang="c#">
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.WriteSingleCoil(1, 0, true);
      /// </code>
      /// <code lang="vbnet">
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.WriteSingleCoil(1, 0, 1)
      /// </code>
      /// <code lang="cpp">
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->WriteSingleCoil(1, 0, true);
      /// </code>
      /// </example>
      public Result WriteSingleCoil(byte unitId, UInt16 address, bool coil)
      {
         return Res = Modbus.WriteSingleCoil (unitId, address, coil);
      }

      /// <summary>
      /// Modbus function 06 (0x06). Write Single Register. 3X references.
      /// <para>This function code is used to write a single holding register in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="register">The value of the register to write.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// This example show how to write the value 100 to address 0.
      /// <example>
      /// <code lang="c#">
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.WriteSingleRegister(1, 0, 100);
      /// </code>
      /// <code lang="vbnet">
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.WriteSingleRegister(1, 0, 100)
      /// </code>
      /// <code lang="cpp">
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->WriteSingleRegister(1, 0, 100);
      /// </code>
      /// </example>
      public Result WriteSingleRegister(byte unitId, UInt16 address, Int16 register)
      {
         return Res = Modbus.WriteSingleRegister(unitId, address, register);
      }

      /// <summary>
      /// Modbus function 15 (0x0F). Write Multiple Coils. 0X references.
      /// <para>This function code is used to force each coil in a sequence of coils to either ON or OFF in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to write 1-1968.</param>
      /// <param name="coils">Array to hold the coils to write.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to write 10 coils.
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    coils[i] = true;
      /// Result = wsmbtControl1.WriteMultipleCoils(1, 0, 10, coils);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As boolean
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    coils(i) = 1
      /// Next i
      /// Result = WsmbtControl1.WriteMultipleCoils(1, 0, 10, coils)
      /// </code>
      /// <code lang="cpp">
      ///  array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      ///  WSMBT::Result Result;
      ///  for (int i = 0; i &lt; 10; i++)
      ///     coils[i] = true;
      ///  Result = wsmbtControl1->WriteMultipleCoils(1, 0, 10, coils);
      /// </code>
      /// </example>
      public Result WriteMultipleCoils(byte unitId, UInt16 address, UInt16 quantity, bool[] coils)
      {
         return Res = Modbus.WriteFlags (unitId, 15, address, quantity, coils, 0);
      }

      /// <summary>
      /// Modbus function 15 (0x0F). Write Multiple Coils. 0X references.
      /// <para>This function code is used to force each coil in a sequence of coils to either ON or OFF in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to write 1-1968.</param>
      /// <param name="coils">Array to hold the coils to write.</param>
      /// <param name="offset">The zero-based offset in the coils parameter at which to begin copying coils to the port.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to write 10 coils.
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    coils[i] = true;
      /// Result = wsmbtControl1.WriteMultipleCoils(1, 0, 10, coils, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As boolean
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    coils(i) = 1
      /// Next i
      /// Result = WsmbtControl1.WriteMultipleCoils(1, 0, 10, coils, 0)
      /// </code>
      /// <code lang="cpp">
      ///  array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      ///  WSMBT::Result Result;
      ///  for (int i = 0; i &lt; 10; i++)
      ///     coils[i] = true;
      ///  Result = wsmbtControl1->WriteMultipleCoils(1, 0, 10, coils, 0);
      /// </code>
      /// </example>
      public Result WriteMultipleCoils(byte unitId, UInt16 address, UInt16 quantity, bool[] coils, int offset)
      {
         return Res = Modbus.WriteFlags(unitId, 15, address, quantity, coils, offset);
      }

      /// <summary>
      /// Modbus function  16 (0x10). Write Multiple registers. 3X references.
      /// <para>This function code is used to write a block of contiguous registers (1 to 123 registers) in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of registers to write 1-123.</param>
      /// <param name="registers">Array to hold the registers to write.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to write 10 registers.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1.WriteMultipleRegisters(1, 0, 10, registers);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    registers(i) = i
      /// Next i
      /// Result = WsmbtControl1.WriteMultipleRegisters(1, 0, 10, registers)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1->WriteMultipleRegisters(1, 0, 10, registers);
      /// </code>
      /// </example>
      public Result WriteMultipleRegisters(byte unitId, UInt16 address, UInt16 quantity, Int16[] registers)
      {
         return Res = Modbus.WriteRegisters(unitId, 16, address, quantity, registers, 0);
      }

      /// <summary>
      /// Modbus function  16 (0x10). Write Multiple registers. 3X references.
      /// <para>This function code is used to write a block of contiguous registers (1 to 123 registers) in a remote device.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of registers to write 1-123.</param>
      /// <param name="registers">Array to hold the registers to write.</param>
      /// <param name="offset">The zero-based offset in the registers parameter at which to begin copying registers to the port.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to write 10 registers.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1.WriteMultipleRegisters(1, 0, 10, registers, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    registers(i) = i
      /// Next i
      /// Result = WsmbtControl1.WriteMultipleRegisters(1, 0, 10, registers, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1->WriteMultipleRegisters(1, 0, 10, registers, 0);
      /// </code>
      /// </example>
      public Result WriteMultipleRegisters(byte unitId, UInt16 address, UInt16 quantity, Int16[] registers, int offset)
      {
         return Res = Modbus.WriteRegisters(unitId, 16, address, quantity, registers, offset);
      }

      /// <summary>
      /// Modbus function 23 (0x17). Read/Write Multiple registers. 3X references.
      /// <para>This function code performs a combination of one read operation and one write operation in a
      /// single Modbus transaction. The write operation is performed before the read.</para>
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="readAddress">Modbus address 0-65535.</param>
      /// <param name="readQuantity">Number of registers to Read 1-125.</param>
      /// <param name="readRegisters">Array to hold the registers to read.</param>
      /// <param name="writeAddress">Modbus address 0-65535.</param>
      /// <param name="writeQuantity">Number of registers to write 1-121.</param>
      /// <param name="writeRegisters">Array to hold the registers to write.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to write 10 registers and read 10 registers.
      /// <code lang="c#">
      /// Int16[] readRegisters = new Int16[10];
      /// Int16[] writeRegisters = new Int16[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    writeRegisters[i] = i;
      /// Result = wsmbtControl1.ReadWriteMultipleRegisters(1, 0, 10, readRegisters, 0, 10, writeRegisters);
      /// </code>
      /// <code lang="vbnet">
      /// Dim readRegisters(10) As Short
      /// Dim writeRegisters(10) As Short
      /// Dim i As Integer
      /// Dim Result As WSMBTResult
      /// For i = 0 To 9
      ///    writeRegisters(i) = i
      /// Next i
      /// Result = WsmbtControl1.ReadWriteMultipleRegisters(1, 0, 10, readRegisters, 0, 10, writeRegisters)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ readRegisters = gcnew array&lt;Int16&gt;(10);
      /// array&lt;Int16&gt;^ writeRegisters = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    writeRegisters[i] = i;
      /// Result = wsmbtControl1->ReadWriteMultipleRegisters(1, 0, 10, readRegisters, 0, 10, writeRegisters);
      /// </code>
      /// </example>
      public Result ReadWriteMultipleRegisters(byte unitId,
                                         UInt16 readAddress,
                                         UInt16 readQuantity,
                                         Int16[] readRegisters,
                                         UInt16 writeAddress,
                                         UInt16 writeQuantity,
                                         Int16[] writeRegisters)
      {
         return Res = Modbus.ReadWriteMultipleRegisters(unitId, readAddress, readQuantity, readRegisters, writeAddress, writeQuantity, writeRegisters);
      }

      /// <summary>
      /// Read coils using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to read 1-2000.</param>
      /// <param name="coils">Array to hold the values.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 user defined coils. If function 01 is used then the function do the same as ReadCoils.
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadUserDefinedCoils(1, 1, 0, 10, coils);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As boolean
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadUserDefinedCoils(1, 1, 0, 10, coils)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadUserDefinedCoils(1, 1, 0, 10, coils);
      /// </code>
      /// </example>
      public Result ReadUserDefinedCoils(byte unitId, byte function, UInt16 address, UInt16 quantity, bool[] coils)
      {
         return Res = Modbus.ReadFlags (unitId, function, address, quantity, coils, 0);
      }

      /// <summary>
      /// Read coils using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to read 1-2000.</param>
      /// <param name="coils">Array to hold the values.</param>
      /// <param name="offset">The offset in the coils array to begin writing.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 user defined coils. If function 01 is used then the function do the same as ReadCoils.
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadUserDefinedCoils(1, 1, 0, 10, coils, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As boolean
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadUserDefinedCoils(1, 1, 0, 10, coils, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadUserDefinedCoils(1, 1, 0, 10, coils, 0);
      /// </code>
      /// </example>
      public Result ReadUserDefinedCoils(byte unitId, byte function, UInt16 address, UInt16 quantity, bool[] coils, int offset)
      {
         return Res = Modbus.ReadFlags(unitId, function, address, quantity, coils, offset);
      }

      /// <summary>
      /// Read registers using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of registers to read 1-125.</param>
      /// <param name="registers">Array to hold the values.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 user defined registers. If function 03 is used then the function do the same as ReadHoldingRegisters.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadUserDefinedRegisters(1, 3, 0, 10, registers);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadUserDefinedRegisters(1, 3, 0, 10, registers)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadUserDefinedRegisters(1, 3, 0, 10, registers);
      /// </code>
      /// </example>
      public Result ReadUserDefinedRegisters(byte unitId, byte function, UInt16 address, UInt16 quantity, Int16[] registers)
      {
         return Res = Modbus.ReadRegisters(unitId, function, address, quantity, registers, 0);
      }

      /// <summary>
      /// Read registers using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of registers to read 1-125.</param>
      /// <param name="registers">Array to hold the values.</param>
      /// <param name="offset">The offset in the registers array to begin writing.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read 10 user defined registers. If function 03 is used then the function do the same as ReadHoldingRegisters.
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// Result = wsmbtControl1.ReadUserDefinedRegisters(1, 3, 0, 10, registers, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim Result As WSMBT.Result
      /// Result = WsmbtControl1.ReadUserDefinedRegisters(1, 3, 0, 10, registers, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// Result = wsmbtControl1->ReadUserDefinedRegisters(1, 3, 0, 10, registers, 0);
      /// </code>
      /// </example>
      public Result ReadUserDefinedRegisters(byte unitId, byte function, UInt16 address, UInt16 quantity, Int16[] registers, int offset)
      {
         return Res = Modbus.ReadRegisters(unitId, function, address, quantity, registers, offset);
      }

      /// <summary>
      /// Write coils using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to write 1-1968.</param>
      /// <param name="coils">Array to hold the coils to write.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    coils[i] = true;
      /// Result = wsmbtControl1.WriteUserDefinedCoils(1, 15, 0, 10, coils);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As Boolean
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    coils(i) = 1
      /// Next i
      /// Result = WsmbtControl1.WriteUserDefinedCoils(1, 15, 0, 10, coils)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    coils[i] = true;
      /// Result = wsmbtControl1->WriteUserDefinedCoils(1, 15, 0, 10, coils);
      /// </code>
      /// </example>
      public Result WriteUserDefinedCoils(byte unitId, byte function, UInt16 address, UInt16 quantity, bool[] coils)
      {
         return Res = Modbus.WriteFlags(unitId, function, address, quantity, coils, 0);
      }

      /// <summary>
      /// Write coils using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of coils to write 1-1968.</param>
      /// <param name="coils">Array to hold the coils to write.</param>
      /// <param name="offset">The zero-based offset in the coils parameter at which to begin copying coils to the port.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// <code lang="c#">
      /// bool[] coils = new bool[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    coils[i] = true;
      /// Result = wsmbtControl1.WriteUserDefinedCoils(1, 15, 0, 10, coils, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim coils(10) As Boolean
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    coils(i) = 1
      /// Next i
      /// Result = WsmbtControl1.WriteUserDefinedCoils(1, 15, 0, 10, coils, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;bool&gt;^ coils = gcnew array&lt;bool&gt;(10);
      /// WSMBT::Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    coils[i] = true;
      /// Result = wsmbtControl1->WriteUserDefinedCoils(1, 15, 0, 10, coils, 0);
      /// </code>
      /// </example>
      public Result WriteUserDefinedCoils(byte unitId, byte function, UInt16 address, UInt16 quantity, bool[] coils, int offset)
      {
         return Res = Modbus.WriteFlags(unitId, function, address, quantity, coils, offset);
      }

      /// <summary>
      /// Write registers using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of registers to write 1-123.</param>
      /// <param name="registers">Array to hold the registers to write.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1.WriteUserDefinedRegisters(1, 16, 0, 10, registers);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    registers(i) = i
      /// Next i
      /// Result = WsmbtControl1.WriteUserDefinedRegisters(1, 16, 0, 10, registers)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1->WriteUserDefinedRegisters(1, 16, 0, 10, registers);
      /// </code>
      /// </example>
      public Result WriteUserDefinedRegisters(byte unitId, byte function, UInt16 address, UInt16 quantity, Int16[] registers)
      {
         return Res = Modbus.WriteRegisters (unitId, function, address, quantity, registers, 0);
      }

      /// <summary>
      /// Write registers using a user defined Modbus function code.
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="function">The user function 1-127.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="quantity">Number of registers to write 1-123.</param>
      /// <param name="registers">Array to hold the registers to write.</param>
      /// <param name="offset">The zero-based offset in the registers parameter at which to begin copying registers to the port.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// <code lang="c#">
      /// Int16[] registers = new Int16[10];
      /// WSMBT.Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1.WriteUserDefinedRegisters(1, 16, 0, 10, registers, 0);
      /// </code>
      /// <code lang="vbnet">
      /// Dim registers(10) As Short
      /// Dim i As Integer
      /// Dim Result As WSMBT.Result
      /// For i = 0 To 9
      ///    registers(i) = i
      /// Next i
      /// Result = WsmbtControl1.WriteUserDefinedRegisters(1, 16, 0, 10, registers, 0)
      /// </code>
      /// <code lang="cpp">
      /// array&lt;Int16&gt;^ registers = gcnew array&lt;Int16&gt;(10);
      /// WSMBT::Result Result;
      /// for (int i = 0; i &lt; 10; i++)
      ///    registers[i] = i;
      /// Result = wsmbtControl1->WriteUserDefinedRegisters(1, 16, 0, 10, registers, 0);
      /// </code>
      /// </example>
      public Result WriteUserDefinedRegisters(byte unitId, byte function, UInt16 address, UInt16 quantity, Int16[] registers, int offset)
      {
         return Res = Modbus.WriteRegisters(unitId, function, address, quantity, registers, offset);
      }

      /// <summary>
      /// Modbus function 17 (0x11). Report slave ID. (RTU/ASCII over TCP/IP mode only).
      /// </summary>
      /// <param name="unitId">The Unit ID 1-255.</param>
      /// <param name="byteCount">The size of the device specific data.</param>
      /// <param name="deviceSpecific">Buffer to hold the data. Be sure this is large enough.</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// This example show how to read the slave ID and device specific data.
      /// <code lang="c#">
      /// WSMBT.Result res;
      /// byte byteCount;                            // Hold the number of bytes returned in deviceSpecific
      /// byte[] deviceSpecific = new byte[100];     // Be sure the size of this array is big enough
      /// res = wsmbtControl1.ReportSlaveID(1, out byteCount, deviceSpecific);
      /// </code>
      /// <code lang="vbnet">
      /// Dim res As WSMBT.Result                    '  Hold the number of bytes returned in deviceSpecific
      /// Dim byteCount As Byte                      '  Be sure the size of this array is big enough
      /// Dim deviceSpecific(100) As Byte
      /// res = WsmbtControl1.ReportSlaveID(1, byteCount, deviceSpecific)
      /// </code>
      /// <code lang="cpp">
      /// WSMBT::Result res;
      /// Byte byteCount;                                                    // Hold the number of bytes returned in deviceSpecific
      /// array&lt;Byte&gt;^ deviceSpecific = gcnew array&lt;Byte&gt;(100);  // Be sure the size of this array is big enough
      /// res = wsmbtControl1->ReportSlaveID(1, byteCount, deviceSpecific);
      /// </code>
      /// </example>
      /// <remarks>byteCount receive the size of the slave ID data. deviceSpecific[0] = Slave ID, deviceSpecific[1] = Run indicator.</remarks>
      public Result ReportSlaveID(byte unitId, out byte byteCount, byte[] deviceSpecific)
      {
         return Res = Modbus.ReportSlaveID(unitId, out byteCount, deviceSpecific);
      }

      /// <summary>
      /// 22 (0x16) Mask Write Register.
      /// </summary>
      /// <param name="unitId">The Unit ID 0-255. 0 means broadcast.</param>
      /// <param name="address">Modbus address 0-65535.</param>
      /// <param name="andMask">The AND mask</param>
      /// <param name="orMask">The OR mask</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <remarks>This function code is used to modify the contents of a specified holding register using a
      /// combination of an AND mask, an OR mask, and the register's current contents. The function
      /// can be used to set or clear individual bits in the register.
      /// <para> Result = (Current Contents AND andMask) OR (orMask AND (NOT andMask))</para>
      /// <para>If the orMask value is zero, the result is simply the logical ANDing of the current contents and
      /// andMask. If the andMask value is zero, the result is equal to the orMask value.</para>
      /// </remarks>
      public Result MaskWriteRegister(byte unitId, UInt16 address, UInt16 andMask, UInt16 orMask)
      {
         return Res = Modbus.MaskWriteRegister(unitId, address, andMask, orMask); // 22
      }

      /// <summary>
      /// Connect to the Modbus remote device.
      /// </summary>
      /// <param name="IPAddress">The DNS name of the remote host to which you intend to connect.</param>
      /// <param name="port">The port number of the remote host to which you intend to connect. (Modbus = 502).</param>
      /// <returns>
      /// <para>If the function succeeds, the return value is zero.</para>
      /// <para>If the function fails, the return value is nonzero. See <see cref="Result">WSMBTControl.Result</see>.</para>
      /// </returns>
      /// <example>
      /// <code lang="c#">
      /// wsmbtControl1.Mode = WSMBT.Mode.TCP_IP; // Use standard Modbus TCP/IP
      /// wsmbtControl1.ConnectTimeout = 2000;
      /// wsmbtControl1.ResponseTimeout = 2000;
      /// WSMBT.WSMBTControl.RESULT Result;
      /// Result = wsmbtControl1.Connect("127.0.0.1", 502);
      /// if (Result != WSMBT.WSMBTControl.Result.SUCCESS)
      ///    MessageBox.Show(wsmbtControl1.GetLastErrorString());
      /// </code>
      /// <code lang="vbnet">
      /// Dim Result As WSMBT.WSMBTControl.RESULT
      /// WsmbtControl1.Mode = WSMBT.Mode.TCP_IP 'Use standard Modbus TCP/IP
      /// WsmbtControl1.ConnectTimeout = 2000
      /// WsmbtControl1.ResponseTimeout = 2000
      /// Result = WsmbtControl1.Connect("127.0.0.1", 502)
      /// If Result &lt;&gt; WSMBT.WSMBTControl.Result.SUCCESS Then
      ///    MessageBox.Show(WsmbtControl1.GetLastErrorString())
      /// End If
      /// </code>
      /// <code lang="cpp">
      /// WSMBT::WSMBTControl::RESULT Result;
      /// wsmbtControl1->Mode = WSMBT::Mode::TCP_IP;
      /// wsmbtControl1->ConnectTimeout = 2000;
      /// wsmbtControl1->ResponseTimeout = 2000;
      /// Result = wsmbtControl1->Connect ("127.0.0.1", 502);
      /// if (Result != WSMBT::Result::SUCCESS)
      ///    MessageBox::Show (wsmbtControl1->GetLastErrorString ());
      /// </code>
      /// </example>
      /// <seealso cref="Close">Close</seealso>
      public Result Connect(string IPAddress, int port)
      {
         client = new TcpClient();

         TxRx.SetClient(client);
         TxRx.Timeout = _ResponseTimeout;

         client.SendTimeout = 2000;
         client.ReceiveTimeout = _ResponseTimeout;

         try
         {
            IAsyncResult ar = client.BeginConnect(IPAddress, port, null, null);
            System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
            if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(_ConnectTimeout), false))
            {
               client.Close();
               return Res = Result.CONNECT_TIMEOUT;
            }
            client.EndConnect(ar);
            wh.Close();
         }
         catch (Exception e)
         {
            Error = e.Message;
            return Res = Result.CONNECT_ERROR;
         }
         TxRx.Mode = _Mode;
         return Res = Result.SUCCESS;
      }

      /// <summary>
      /// Close the TCP/IP Connection.
      /// </summary>
      /// <example>
      /// <code lang="c#">
      /// wsmbtControl1.Close();
      /// </code>
      /// <code lang="vbnet">
      /// WsmbtControl1.Close()
      /// </code>
      /// <code lang="cpp">
      /// wsmbtControl1->Close();
      /// </code>
      /// </example>
      /// <seealso cref="Connect">Connect</seealso>
      public void Close()
      {
         if (client != null)
            client.Close();
      }

      /// <summary>
      /// Returns the last error as a string.
      /// </summary>
      /// <returns>
      /// Error description as string.
      /// </returns>
      public String GetLastErrorString()
      {
         switch (Res)
         {
            case Result.SUCCESS:                           return "Success";
            case Result.ILLEGAL_FUNCTION:                  return "Illegal function.";
            case Result.ILLEGAL_DATA_ADDRESS:              return "Illegal data address.";
            case Result.ILLEGAL_DATA_VALUE:                return "Illegal data value.";
            case Result.SLAVE_DEVICE_FAILURE:              return "Slave device failure.";
            case Result.ACKNOWLEDGE:                       return "Acknowledge.";
            case Result.SLAVE_DEVICE_BUSY:                 return "Slave device busy.";
            case Result.NEGATIVE_ACKNOWLEDGE:              return "Negative acknowledge.";
            case Result.MEMORY_PARITY_ERROR:               return "Memory parity error.";

            case Result.RESPONSE_TIMEOUT:                  return "Response timeout.";
            case Result.ISCLOSED:                          return "Connection is closed.";
            case Result.CRC:                               return "CRC Error.";
            case Result.RESPONSE:                          return "Not the expected response received.";
            case Result.BYTECOUNT:                         return "Byte count error.";
            case Result.QUANTITY:                          return "Quantity is out of range.";
            case Result.FUNCTION:                          return "Modbus function code out of range. 1 - 127.";

            case Result.READ:                              return "Read error. " + TxRx.GetErrorMessage();
            case Result.WRITE:                             return "Write error. " + TxRx.GetErrorMessage();
            case Result.CONNECT_ERROR:                     return Error;
            case Result.CONNECT_TIMEOUT:                   return "Could not connect within the specified time";
            case Result.DEMO_TIMEOUT:                      return "Demo mode expired. Restart your application to continue.";

            default: return "Unknown Error - " + Res.ToString();
         }
      }

      /// <summary>
      /// Returns a single-precision floating point number converted from two Int16.
      /// </summary>
      /// <param name="hiReg">High order register.</param>
      /// <param name="loReg">Low order register.</param>
      /// <returns>A single-precision floating point number.</returns>
      public float RegistersToFloat(Int16 hiReg, Int16 loReg)
      {
         return BitConverter.ToSingle(BitConverter.GetBytes(loReg).Concat(BitConverter.GetBytes(hiReg)).ToArray(), 0);
      }

      /// <summary>
      /// Returns a 32-bit signed integer converted from two Int16.
      /// </summary>
      /// <param name="hiReg">High order register.</param>
      /// <param name="loReg">Low order register.</param>
      /// <returns>A 32-bit signed integer.</returns>
      public Int32 RegistersToInt32(Int16 hiReg, Int16 loReg)
      {
         return BitConverter.ToInt32(BitConverter.GetBytes(loReg).Concat(BitConverter.GetBytes(hiReg)).ToArray(), 0);
      }

      /// <summary>
      /// Return two Int16 convereted from a float.
      /// </summary>
      /// <param name="value">A single-precision floating point number.</param>
      /// <returns>An array of two Int16.</returns>
      public Int16[] FloatToRegisters(float value)
      {
         Int16[] regs = new Int16[2];
         byte[] a = BitConverter.GetBytes(value);
         regs[1] = BitConverter.ToInt16(a, 0);
         regs[0] = BitConverter.ToInt16(a, 2);
         return regs;
      }

      /// <summary>
      /// Return two Int16 convereted from an Int32.
      /// </summary>
      /// <param name="value">A 32-bit signed integer.</param>
      /// <returns>An array of two Int16.</returns>
      public Int16[] Int32ToRegisters(Int32 value)
      {
         Int16[] regs = new Int16[2];
         byte[] a = BitConverter.GetBytes(value);
         regs[1] = BitConverter.ToInt16(a, 0);
         regs[0] = BitConverter.ToInt16(a, 2);
         return regs;
      }

      /// <summary>
      /// Gets the transmit buffer.
      /// </summary>
      /// <param name="byteArray">A byte array to hold the bytes from the transmit buffer.</param>
      /// <returns>Returns the number of transmitted bytes in the byte array.</returns>
      public int GetTxBuffer(byte[] byteArray)
      {
         return TxRx.GetTxBuffer(byteArray);
      }

      /// <summary>
      /// Gets the receive buffer.
      /// </summary>
      /// <param name="byteArray">A byte array to hold the bytes from the receive buffer.</param>
      /// <returns>Returns the number of received bytes in the byte array.</returns>
      public int GetRxBuffer(byte[] byteArray)
      {
         return TxRx.GetRxBuffer(byteArray);
      }
   }
}