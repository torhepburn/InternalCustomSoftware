using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;

namespace Text2Image
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn = new SqlConnection
            ("server = middb01; password = views; " +
              "user = views; database = dashboard;");
  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter
                ("Select * from view_employees", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);

            //if (table.Rows.Count > 0 )
            //{
                foreach (DataRow row in table.Rows)
                {
                    string a = row[2].ToString();
                    //ev.Graphics.DrawString(row[0].ToString().Trim(), arial, Brushes.Black, 50, lineDrop);
                    //ev.Graphics.DrawString(row[1].ToString().Trim(), arial, Brushes.Black, 150, lineDrop);
                    //ev.Graphics.DrawString(row[2].ToString().Trim(), arial, Brushes.Black, 250, lineDrop);
                    //ev.Graphics.DrawString(row[3].ToString().Trim(), arial, Brushes.Black, 300, lineDrop);
                    //ev.Graphics.DrawString(row[4].ToString().Trim(), arial, Brushes.Black, 400, lineDrop);
                    //ev.Graphics.DrawString(row[5].ToString().Trim(), arial, Brushes.Black, 650, lineDrop);
                    //ev.Graphics.DrawString(row[6].ToString().Trim(), arial, Brushes.Black, 750, lineDrop);
                    //lineDrop = lineDrop + 25;
                    CreateBitmapImage(a);
                }
            //}

            //DGV.DataSource = table;

            
            
        }

 private Bitmap CreateBitmapImage(string sImageText)   
 {   
     Bitmap objBmpImage = new Bitmap(1, 1);   
     
     int intWidth = 0;   
     int intHeight = 0;   
     
     // Create the Font object for the image text drawing.   
     Font objFont = new Font("Arial", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);  
    
     // Create a graphics object to measure the text's width and height.  
     Graphics objGraphics = Graphics.FromImage(objBmpImage);  
       
     // This is where the bitmap size is determined.  
     intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;  
     intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;  
    
     // Create the bmpImage again with the correct size for the text and font.  
     objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));  
    
     // Add the colors to the new bitmap.  
     objGraphics = Graphics.FromImage(objBmpImage);  
    
     // Set Background color  
     objGraphics.Clear(Color.Red);  
     ////objGraphics.SmoothingMode = SmoothingMode.AntiAlias;  
     ////objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;  
     objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);  
     objGraphics.Flush();

     objBmpImage.Save(@"c:\a\" + sImageText + ".bmp");
    
     return (objBmpImage);  
 }
    }
}
