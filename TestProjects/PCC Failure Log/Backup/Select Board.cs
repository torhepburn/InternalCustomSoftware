using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCC_Failure_Log
{
    public partial class Select_Board : Form
    {
        public Select_Board()
        {
            InitializeComponent();
        }

        private void Select_Board_Load(object sender, EventArgs e)
        {
            Ltask.Text = pV.task;
        }

        private void b4004_Click(object sender, EventArgs e)
        {
            if (pV.purpose == "MCert")
            {
                if (pV.location == "CEI")
                {
                    pV.select = "company = 'cei' and board = '4004' " +
                        "and ([xml file] like '%618068%' or " +
                        "[xml file] like '%618072%' or " +
                        "[xml file] like '%618074%')";
                }
                else
                {
                    pV.select = "company = 'zygo' and board = '4004' " +
                        "and ([xml file] like '%7151655%' or " +
                        "[xml file] like '%7171748%' or " +
                        "[xml file] like '%7171756%')";
                }
            }
            else
            {
                if (pV.location == "CEI")
                {
                    pV.select = "company = 'cei' and board = '4004' " +
                        "and ([xml file] not like '%618068%' and " +
                        "[xml file] not like '%618072%' and " +
                        "[xml file] not like '%618074%')";
                }
                else
                {
                    pV.select = "company = 'zygo' and board = '4004' " +
                        "and ([xml file] not like '%7151655%' and " +
                        "[xml file] not like '%7171748%' and " +
                        "[xml file] not like '%7171756%')";
                }
            }
            Form1 f1 = new Form1();
            f1.Show();
            Close();
        }

        private void b4104_Click(object sender, EventArgs e)
        {
            if (pV.purpose == "MCert")
            {
                if (pV.location == "CEI")
                {
                    pV.select = "company = 'cei' and board = '4104' " +
                        "and ([xml file] like '%618041%' or " +
                        "[xml file] like '%618042%' or " +
                        "[xml file] like '%9145386%')";
                }
                else
                {
                    pV.select = "company = 'zygo' and board = '4104' " +
                        "and ([xml file] like '%7382437%' or " +
                        "[xml file] like '%7262253%' or " +
                        "[xml file] like '%7432600%')";
                }
            }
            else
            {
                if (pV.location == "CEI")
                {
                    pV.select = "company = 'cei' and board = '4104' " +
                        "and ([xml file] not like '%618041%' and " +
                        "[xml file] not like '%618042%' and " +
                        "[xml file] not like '%9145386%')";
                }
                else
                {
                    pV.select = "company = 'zygo' and board = '4104' " +
                        "and ([xml file] not like '%7382437%' and " +
                        "[xml file] not like '%7262253%' and " +
                        "[xml file] not like '%7432600%')";
                }
            }
            Form1 f1 = new Form1();
            f1.Show();
            Close();
        }

    }
}