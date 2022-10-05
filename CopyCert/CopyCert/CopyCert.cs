using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CopyCert
{
    public partial class CopyCert : Form
    {
        private string fromCopy;
        private string toCopy;
        private string customer;
        private string address;
        private string po;
        private string pn;
        private string sn;
        private string cprocedure;
        private string caldue;
        private string ttestp;
        private string temperature;
        private string humidity;
        private string cname;
        private string title;
        private string written;
        
        public CopyCert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fromCopy = textBox1.Text.Trim();
            toCopy = textBox2.Text.Trim();

            SqlParameter descrip = new SqlParameter("@descrip", SqlDbType.NVarChar, 254);
            SqlParameter ctype = new SqlParameter("@ctype", SqlDbType.NVarChar, 254);
            SqlParameter results = new SqlParameter("@results", SqlDbType.NVarChar, 254);
            SqlParameter refstd = new SqlParameter("@refstd", SqlDbType.NVarChar, 254);
            SqlParameter pertinfo = new SqlParameter("@pertinfo", SqlDbType.NVarChar, 254);

            SqlConnection cnxn = new SqlConnection
                ("server = midsql01; user = readWrite; password = Read+Write!; database = AccessFrontEnds;");

            SqlCommand cmd = new SqlCommand
            ("Select " +
                "[Customer Name]," +
                "[Customer Address], " +
                "[Customer PO #], " +
                "[Desc], " +
                "[p/n], " +
                "type, " +
                "[serial #], " +
                "[calibration procedure], " +
                "[certified results], " +
                "[next calibration due], " +
                "[type of test performed], " +
                "[reference standards used], " +
                "temperature, " +
                "relativehumidity, " +
                "[other pertinent information], " +
                "name, " +
                "title, " +
                "[written by]" +
                "from Cc_CofC where [certification #] " +
                "= '" + fromCopy + "'", cnxn);
               //from cc_cofc", cnxn);

            cnxn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { customer = dr.GetString(0); }
                if (!dr.IsDBNull(1)) { address = dr.GetString(1); }
                if (!dr.IsDBNull(2)) { po = dr.GetString(2); }
                if (!dr.IsDBNull(3)) { descrip.Value = dr.GetString(3); }
                if (!dr.IsDBNull(4)) { pn = dr.GetString(4); }
                if (!dr.IsDBNull(5)) { ctype.Value = dr.GetString(5); }
                if (!dr.IsDBNull(6)) { sn = dr.GetString(6); }
                if (!dr.IsDBNull(7)) { cprocedure = dr.GetString(7); }
                if (!dr.IsDBNull(8)) { results.Value = dr.GetString(8); }
                if (!dr.IsDBNull(9)) { caldue = dr.GetString(9); }
                if (!dr.IsDBNull(10)) { ttestp = dr.GetString(10); }
                if (!dr.IsDBNull(11)) { refstd.Value = dr.GetString(11); }
                if (!dr.IsDBNull(12)) { temperature = dr.GetString(12); }
                if (!dr.IsDBNull(13)) { humidity = dr.GetString(13); }
                if (!dr.IsDBNull(14)) { pertinfo.Value = dr.GetString(14); }
                if (!dr.IsDBNull(15)) { cname = dr.GetString(15); }
                if (!dr.IsDBNull(16)) { title = dr.GetString(16); }
                if (!dr.IsDBNull(17)) { written = dr.GetString(17); }
            }

            cnxn.Close();

            cmd = new SqlCommand(
                "Update cc_cofc set " +
                "[Customer Name] = '" + customer + "'," +
                "[Customer Address] = '" + address + "'," +
                "[Customer PO #] = '" + po + "'," +
                "[Desc] = " + descrip + "," +
                "[p/n] = '" + pn + "'," +
                "type = " + ctype + "," +
                "[serial #] = '" + sn + "'," +
                "[calibration procedure] = '" + cprocedure + "'," +
                "[certified results] = " + results + "," +
                "[next calibration due] = '" + caldue + "'," +
                "[type of test performed] = '" + ttestp + "'," +
                "[reference standards used] = " + refstd + "," +
                "temperature = '" + temperature + "'," +
                "relativehumidity = '" + humidity + "'," +
                "[other pertinent information] = " + pertinfo + "," +
                "name = '" + cname + "'," +
                "title = '" + title + "'," +
                "[written by] = '" + written + "' " +
                "where [certification #] = '" + toCopy + "'", cnxn);

            cmd.Parameters.Add(descrip);
            cmd.Parameters.Add(ctype);
            cmd.Parameters.Add(results);
            cmd.Parameters.Add(refstd);
            cmd.Parameters.Add(pertinfo);

            cnxn.Open();
            try
            {
                int rowsReturned = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Close();

        }
    }
}
