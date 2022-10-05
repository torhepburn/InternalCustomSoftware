using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Get_Date_for_PCC
{
    public partial class Null_out_Zeros : Form
    {
        //SqlConnection cnxn;
        //SqlCommand cmd;
        //private string db = "server = midprj01; user = views; password = views; " +
        //     "database = productioncontrol";
            
        
        public Null_out_Zeros()
        {
            InitializeComponent();
        }

        private void Null_out_Zeros_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = midprj01; user = views; password = views; " +
                 "database = productioncontrol");
            SqlCommand cmd = new SqlCommand
                ("Update [test data] " +
                 "set [ad +5v digital ps] = null, " +
                 "[ad +5v digital ps ripple] = null " +
                 "where AD = 'false';" +
                 "Update [test data] " +
                 "set [da rfdelay dau1] = null " +
                 "where DArf1 = 'false'; " +
                 "Update [test data] " +
                 "set [da rfdelay dau2] = null " +
                 "where DArf2 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau1] = null " +
                 "where DAms1 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau2] = null " +
                 "Where DAms2 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau3] = null " +
                 "Where DAms3 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau4] = null " +
                 "Where DAms4 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax1] = null, " +
                 "[LIN 10 SSI Avg Ax1] = null, " +
                 "[LIN 10 RMS Error Ax1] = null, " +
                 "[LIN 1 MeasPower Ax1] = null, " +
                 "[LIN 1 SSI Avg Ax1] = null, " +
                 "[LIN 1 RMS Error Ax1] = null, " +
                 "[LIN .07 MeasPower Ax1] = null, " +
                 "[LIN .07 SSI Avg Ax1] = null, " +
                 "[LIN .07 RMS Error Ax1] = null " +
                 "Where LINx1 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax2] = null, " +
                 "[LIN 10 SSI Avg Ax2] = null, " +
                 "[LIN 10 RMS Error Ax2] = null, " +
                 "[LIN 1 MeasPower Ax2] = null, " +
                 "[LIN 1 SSI Avg Ax2] = null, " +
                 "[LIN 1 RMS Error Ax2] = null, " +
                 "[LIN .07 MeasPower Ax2] = null, " +
                 "[LIN .07 SSI Avg Ax2] = null, " +
                 "[LIN .07 RMS Error Ax2] = null " +
                 "Where LINx2 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax3] = null, " +
                 "[LIN 10 SSI Avg Ax3] = null, " +
                 "[LIN 10 RMS Error Ax3] = null, " +
                 "[LIN 1 MeasPower Ax3] = null, " +
                 "[LIN 1 SSI Avg Ax3] = null, " +
                 "[LIN 1 RMS Error Ax3] = null, " +
                 "[LIN .07 MeasPower Ax3] = null, " +
                 "[LIN .07 SSI Avg Ax3] = null, " +
                 "[LIN .07 RMS Error Ax3] = null " +
                 "Where LINx3 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax4] = null, " +
                 "[LIN 10 SSI Avg Ax4] = null, " +
                 "[LIN 10 RMS Error Ax4] = null, " +
                 "[LIN 1 MeasPower Ax4] = null, " +
                 "[LIN 1 SSI Avg Ax4] = null, " +
                 "[LIN 1 RMS Error Ax4] = null, " +
                 "[LIN .07 MeasPower Ax4] = null, " +
                 "[LIN .07 SSI Avg Ax4] = null, " +
                 "[LIN .07 RMS Error Ax4] = null " +
                 "Where LINx4 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax1] = null, " +
                 "[DNAC 3.88 Std Dev Ax1] = null " +
                 "Where DNACx1 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax2] = null, " +
                 "[DNAC 3.88 Std Dev Ax2] = null " +
                 "Where DNACx2 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax3] = null, " +
                 "[DNAC 3.88 Std Dev Ax3] = null " +
                 "Where DNACx3 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax4] = null, " +
                 "[DNAC 3.88 Std Dev Ax4] = null " +
                 "Where DNACx4 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax1] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax1] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax1] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax1] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax1] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax1] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax1] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax1] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax1] = null " +
                 "Where EVPVx1 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax2] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax2] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax2] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax2] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax2] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax2] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax2] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax2] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax2] = null " +
                 "Where EVPVx2 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax3] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax3] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax3] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax3] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax3] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax3] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax3] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax3] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax3] = null " +
                 "Where EVPVx3 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax4] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax4] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax4] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax4] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax4] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax4] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax4] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax4] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax4] = null " +
                 "Where EVPVx4 = 'false';" );

            cmd.Connection = cnxn;
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
        
        }
    }
}