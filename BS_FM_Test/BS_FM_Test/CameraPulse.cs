using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MccDaq;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    
   public class CameraPulse
    {
        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);
        System.Diagnostics.Stopwatch watchTimeout = new System.Diagnostics.Stopwatch();

        public void PulseCamera (int pulseCount)//Pulse count method based on selected recipe
        {
            DaqBoard.DBitOut(DigitalPortType.FirstPortA, 16, DigitalLogicState.Low);//Assure output in low state
            
            On_Pulse(200);//200ms Starting pulse
            Off_Pulse(100);//100ms Starting gap 
            
            for (int i = 0; i <pulseCount; i++)//recipe pulsecount loop
            {      
                On_Pulse(100);
                Off_Pulse(100);
                }

            On_Pulse(200);//200ms Finishing pulse
            DaqBoard.DBitOut(DigitalPortType.FirstPortA, 16, DigitalLogicState.Low);//Return to low state

        }
        public void On_Pulse (int pulseOn_ms)// Pulse on time method
        {
            
            watchTimeout.Reset();
            watchTimeout.Start();
            while (watchTimeout.ElapsedMilliseconds < pulseOn_ms)
            {
                DaqBoard.DBitOut(DigitalPortType.FirstPortA, 16, DigitalLogicState.High);
            }
        }
            
            
            public void Off_Pulse (int pulseOff_ms)// Pulse off time method
            {
            
            watchTimeout.Reset();
            watchTimeout.Start();
            while (watchTimeout.ElapsedMilliseconds < pulseOff_ms)
            {
                DaqBoard.DBitOut(DigitalPortType.FirstPortA, 16, DigitalLogicState.Low);
            }
            }

            
        }
        


    
}
