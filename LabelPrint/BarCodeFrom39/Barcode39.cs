using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.IO;

namespace BarCodeFrom39
{
    public partial class Barcode39 : Form
    {
        Graphics g;

        public Barcode39()
        {
            InitializeComponent();
        }

        private void Barcode39_Load(object sender, EventArgs e)
        {
            /*
            Bitmap barCode = CreateBarCode("*SML 10008250*");

            try
            {
                //g = Graphics.FromImage(imageFile);
                //g = Graphics.FromImage(bmp);
                //g = Graphics.FromImage(barCode);
                barCode.Save(@"c:\a\tapn.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
             * 
             * */
            //Bitmap bmp = new Bitmap(@"C:\a\labelnew.bmp");

            //Bitmap bm = new Bitmap(typeof(Button), "Button.bmp");

            //bmp.Save(@"c:\a\a.png", System.Drawing.Imaging.ImageFormat.Png);
            //bm.Save(@"c:\a\b.png", System.Drawing.Imaging.ImageFormat.Png);

            //bmp = new Bitmap(@"C:\a\a.png");

            
            //bmp = resizeImage(bmp, new Size(5, 5));

            //RectangleF rectf = new RectangleF(70, 90, 90, 50);

            //Image imageFile = Image.FromFile(@"c:\a\b.png");

           

            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //g.DrawString("yourText", new Font("Tahoma", 60), Brushes.Black, rectf);

            //g.Flush();

            //barCode.Save(@"c:\a\tag.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            
            //image.Image = bmp;

            string ipAddress = "10.213.68.172";
            int port = 9100;

            //ZPL commands

            string ZPLstring = "^XA" +
                               "^FO100,150" +
                               "^ADN,36,20" +
                               "^FDHello, World!^FS" +
                               "^FO200, 200^GB400, 0,4,^FS" +
                               "^FO200, 300^B3N, N, 100, Y, N^FD123456^FS" +
                               "^XZ";

            /*
            string zplImageData = string.Empty;
            //Make sure no transparency exists. I had some trouble with this. This PNG has a white background
            string filePath = @"C:\A\tapn.png";
            byte[] binaryData = System.IO.File.ReadAllBytes(filePath);
            foreach (Byte b in binaryData)
            {
                string hexRep = String.Format("{0:X}", b);
                if (hexRep.Length == 1)
                    hexRep = "0" + hexRep;
                zplImageData += hexRep;
            }
            string zplToSend = "^XA" + "^MNN" + "^LL500" + "~DYE:TAPN,P,P," + binaryData.Length + ",," + zplImageData + "^XZ";
            string printImage = "^XA^FO115,50^IME:TAPN.PNG^FS^XZ";
            */
            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);

                if (client.Connected)
                {
                    MessageBox.Show("CONNECTED");
                }

                // Write ZPL String to connection
                System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
                //writer.Write(zplToSend);
                writer.Write(ZPLstring);
                writer.Flush();
                //writer.Write(printImage);
                //writer.Flush();
                // Close Connection
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            

            //barCode.Save(@"C:\a\barcode2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            /*
            string code = "334455";

            int w = code.Length * 40;
            
            Font threeofNine = new Font("Free 3 of 9", 60,
                                FontStyle.Regular,
                                GraphicsUnit.Point);


            Bitmap bm = new Bitmap(typeof(Button), "Button.bmp");

            bm.Save("C:\\a\\barcode.Gif", System.Drawing.Imaging.ImageFormat.Gif);
            */
            /*

            Graphics oGraphics = Graphics.FromImage(bm);

            PointF oPoint = new PointF(2f, 2f);
            SolidBrush oBrushWrite = new SolidBrush(Color.Black);
            SolidBrush oBrush = new SolidBrush(Color.White);

            oGraphics.FillRectangle(oBrush, 0, 0, 1, 100);

            oGraphics.DrawString("*" + code + "*", threeofNine, oBrushWrite, oPoint);

            bm.Save(@"C:\a\barcode.png", ImageFormat.Gif);*/
            //SizeF barcodesize = oGraphics.MeasureString("12345", threeofNine);
            //oGraphics.DrawString("12344", threeofNine, new SolidBrush(Color.Black), 0, 0);
            //bm.Save(@"C:\a\barcode.png", System.Drawing.Imaging.ImageFormat.Png);


        }

        //public static Image resizeImage(Image imgToResize, Size size)
        //{
        //    return (Image)(new Bitmap(imgToResize, size));
        //}

        //private void PrintPage (object o, PrintPageEventArgs e)
        //{

        //}

        private Bitmap CreateBarCode(string data)
        {
            Bitmap barCode = new Bitmap(1, 1);

            Font threeofNine = new Font("Free 3 of 9", 60,
                                FontStyle.Regular,
                                GraphicsUnit.Point);
            
            Graphics graphics = Graphics.FromImage(barCode);

            SizeF dataSize = graphics.MeasureString(data, threeofNine);
            //dataSize.Height = 700;
            //dataSize.Width = 500;

            barCode = new Bitmap(barCode, dataSize.ToSize());

            graphics = Graphics.FromImage(barCode);

            graphics.Clear(Color.White);

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

            graphics.DrawString(data, threeofNine, new SolidBrush(Color.Black), 0, 0);

            graphics.Flush();

            threeofNine.Dispose();
            graphics.Dispose();

            return barCode;


            /*
            data = "55536";
            string barcodeData = "*" + data + "*";
            Bitmap barcode = new Bitmap(1, 1);
            Font threeOfNine = new Font("Free 3 of 9 Extended", 31, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Font arial = new Font("Arial", 13,
                      System.Drawing.FontStyle.Regular,
                      System.Drawing.GraphicsUnit.Point);

            Graphics graphics = Graphics.FromImage(barcode);
            SizeF dataSize = graphics.MeasureString(barcodeData, threeOfNine);
            dataSize.Height = 70;

            barcode = new Bitmap(barcode, dataSize.ToSize());
            graphics = Graphics.FromImage(barcode);

            graphics.Clear(Color.White);
            //graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            graphics.DrawString(barcodeData, threeOfNine, new SolidBrush(Color.Black), 0, 0);

            graphics.DrawString(data, arial, new SolidBrush(Color.Black), 50, 40);

            graphics.Flush();

            threeOfNine.Dispose();
            graphics.Dispose();

            return barcode;

            */

        }

    }


}
