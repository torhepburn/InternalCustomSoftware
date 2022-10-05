using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace InfoPathTest
{
    public partial class Form1 : Form
    {
        private string hh;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            XmlReader reader = XmlReader.Create("C:\\A\\Form.xml");

            byte[] buffer = new byte[2000];
            /*
            byte[] buffer = new byte[2000];
            int readBytes = 0;

            hh = "This is a test";

            var txtbyte = System.Text.Encoding.UTF8.GetBytes(hh);

            string e64 = Convert.ToBase64String(txtbyte);

            var back = Convert.FromBase64String(e64);

            try
            {
                string a = Encoding.UTF8.GetString(back);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            string b = "'end";
            */

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "my:field39"))
                {
                    hh = reader.ReadElementContentAsString();

                    var bak = Convert.FromBase64String(hh);

                    buffer = bak;

                    //string aa = Encoding.UTF8.GetString(bak);
                    //readBytes = reader.ReadContentAsBase64(buffer, 0, 50);

                    ////reader.ReadContentAsBase64()
                    //while(
                    //(readBytes  = Convert.ReadElementContentAsBase64(buffer, 0, 50))>0)
                    //{

                    //hh = "dGhpcyBpcyBhIHRlc3Q=";

                    //var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(hh);

                    //string e64 = Convert.ToBase64String(plaintextbytes);

                }


                /*
                while (dr.Read())
                {
                    // read in using GetValue and cast to byte array
                    byte[] xData = (byte[])dr.GetValue(0);

                    // write bytes to disk as file
                    FileStream fs1 = new FileStream
                        (xtract, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs1);
                    bw.Write(xData);
                    bw.Close();

                    pdfReader = System.Diagnostics.Process.Start(xtract);
                }

                hh.GetType();
            }
        }*/


                //try
                //{
                //    var back = Convert.FromBase64String(e64);

                //    using (MemoryStream ms = new MemoryStream(back))
                //    {
                //        BinaryReader theReader = new BinaryReader(ms);
                //        //DecodeAttachment(theReader);
                //    }
                //    //var G = System.Text.Encoding.UTF8.GetString(back);
                //    //int fileSize = (int)back.ReadUInt32();
                //    //byte[] theData = Convert.FromBase64String(e64);

                //    string kkk = "PPP";

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            }

            // write bytes to disk as file
            FileStream fs1 = new FileStream
                (@"C:\A\xtract.pdf", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs1);
            bw.Write(buffer);
            bw.Close();
        }
    }
}

    //}

    //public class InfoPathAttachmentDecoder
    //{
    //    private const int SP1Header_Size = 20;
    //    private const int FIXED_HEADER = 16;

    //    private int fileSize;
    //    private int attachmentNameLength;
    //    private string attachmentName;
    //    private byte[] decodedAttachment;

    //    /// <summary>
    //    /// Accepts the Base64 encoded string
    //    /// that is the attachment.
    //    /// </summary>
    //    public InfoPathAttachmentDecoder(string theBase64EncodedString)
    //    {
    //        byte[] theData = Convert.FromBase64String(theBase64EncodedString);
    //        using (MemoryStream ms = new MemoryStream(theData))
    //        {
    //            BinaryReader theReader = new BinaryReader(ms);
    //            DecodeAttachment(theReader);
    //        }
    //    }

    //    private void DecodeAttachment(BinaryReader theReader)
    //    {
    //        //Position the reader to get the file size.
    //        byte[] headerData = new byte[FIXED_HEADER];
    //        headerData = theReader.ReadBytes(headerData.Length);

    //        fileSize = (int)theReader.ReadUInt32();
    //        attachmentNameLength = (int)theReader.ReadUInt32() * 2;

    //        byte[] fileNameBytes = theReader.ReadBytes(attachmentNameLength);
    //        //InfoPath uses UTF8 encoding.
    //        Encoding enc = Encoding.Unicode;
    //        attachmentName = enc.GetString(fileNameBytes, 0, attachmentNameLength - 2);
    //        decodedAttachment = theReader.ReadBytes(fileSize);
    //    }

    //    public void SaveAttachment(string saveLocation)
    //    {
    //        string fullFileName = saveLocation;
    //        //if (!fullFileName.EndsWith(Path.DirectorySeparatorChar))
    //        //{
    //        //    fullFileName += Path.DirectorySeparatorChar;
    //        //}

    //        fullFileName += attachmentName;

    //        if (File.Exists(fullFileName))
    //            File.Delete(fullFileName);

    //        FileStream fs = new FileStream(fullFileName, FileMode.CreateNew);
    //        BinaryWriter bw = new BinaryWriter(fs);
    //        bw.Write(decodedAttachment);

    //        bw.Close();
    //        fs.Close();
    //    }

    //    public string Filename
    //    {
    //        get { return attachmentName; }
    //    }

    //    public byte[] DecodedAttachment
    //    {
    //        get { return decodedAttachment; }
    //    }
    ////}
//}

