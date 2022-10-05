using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f40_Room : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        private string RoomNumber;
        private string Description;
        private string Notes;
        private bool flagRoom;
        private bool flagDescription;
        private bool flagEntered;

        SqlParameter Rnumber = new SqlParameter("@Rnumber", SqlDbType.VarChar, 10);
        SqlParameter Rdescrip = new SqlParameter("@Rdescrip", SqlDbType.VarChar, 255);
        SqlParameter Rnotes = new SqlParameter("@Rnotes", SqlDbType.VarChar, 255);
        
        public f40_Room()
        {
            InitializeComponent();
        }

        private void f40_Room_Load(object sender, EventArgs e)
        {
            if (g.task == "Edit")
            {
                tbRoomNumber.Text = g.room;
                tbRoomNumber.ReadOnly = true;
                tbRoomNumber.BackColor = System.Drawing.Color.FromArgb(60,220,220);
                tbDescription.Text = g.Rdescription;
                tbNotes.Text = g.Rnotes;
                tbDescription.Select();
            }

            if (g.task == "Add")
            {
                tbRoomNumber.ReadOnly = false;
            }
        }

        private void bEnterRoomData_Click(object sender, EventArgs e)
        {
            if (tbRoomNumber.Text != "")
            {
                Rnumber.Value = g.facility + "-" +
                    tbRoomNumber.Text.ToString().Trim().ToUpper();
                
                flagRoom = true;
            }
            else
            {
                MessageBox.Show("Enter a Room Number.");
                tbRoomNumber.Focus();
                flagRoom = false;
            }


            if (tbDescription.Text != "")
            {
                Rdescrip.Value = tbDescription.Text.ToString().Trim().ToUpper();
                flagDescription = true;
            }
            else
            {
                MessageBox.Show("Enter a Description.");
                tbDescription.Focus();
                flagDescription = false;
            }

            if (tbNotes.Text != "")
            {
                Rnotes.Value = tbNotes.Text.ToString().Trim();
            }
            else
            {
                Rnotes.Value = "";
            }

            
            if (g.task == "Add")
            {
                if (flagRoom == true && flagDescription == true)
                {
                    cnxn = new SqlConnection(g.db);

                    cmd = new SqlCommand
                        ("Select r_roomnumber from room " +
                         " where r_roomnumber = " + Rnumber + " ",cnxn);
                    cmd.Parameters.Add(Rnumber);
                    cnxn.Open();
                    object oo = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    cnxn.Close();
                    if (oo != null)
                    {
                        MessageBox.Show("This Room Number has already been issued.");
                        tbRoomNumber.Text = "";
                        tbRoomNumber.Focus();
                    }
                    else
                    {
                        cmd = new SqlCommand("Insert into room " +
                            "(R_description, R_notes, R_RoomNumber) values (" +
                            Rdescrip +
                            "," + Rnotes +
                            "," + Rnumber + ")", cnxn);
                        cmd.Parameters.Add(Rdescrip);
                        cmd.Parameters.Add(Rnotes);
                        cmd.Parameters.Add(Rnumber);
                        cnxn.Open();
                        int rowsReturned = cmd.ExecuteNonQuery();
                        cnxn.Close();
                        cmd.Parameters.Clear();
                        flagEntered = true;
                    }
                }
            }
            if (g.task == "Edit")
            {
                if (flagRoom == true && flagDescription == true)
                {
                    cnxn = new SqlConnection(g.db);

                    cmd = new SqlCommand("Update room " +
                        "set " +
                        "R_description = " + Rdescrip + "," +
                        "R_notes = " + Rnotes + " " +
                        "where r_ID = " + g.rID + "", cnxn);
                    cmd.Parameters.Add(Rdescrip);
                    cmd.Parameters.Add(Rnotes);
                    cnxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();
                    cmd.Parameters.Clear();
                    flagEntered = true;
                }
                this.Close();
            }
            if (flagEntered == true)
            {
                tbDescription.Text = "";
                tbNotes.Text = "";
                tbRoomNumber.Text = "";
                g.rID = 0;
                flagEntered = false;
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbRoomNumber_TextChanged(object sender, EventArgs e)
        {
            if (tbRoomNumber.Text.Length > 5)
            {
                MessageBox.Show("Number too long.  Five (5) character maximum.");
                tbRoomNumber.Text = "";
                tbRoomNumber.Focus();
            }
        }
    }
}