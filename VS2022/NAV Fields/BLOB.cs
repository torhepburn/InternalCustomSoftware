using Microsoft.Data.SqlClient;
using System.IO.Compression;

namespace NAV_Fields
{
    public partial class BLOB : Form
    {
        public BLOB()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = PA-HOR-AS408; password = 2018#ameteK;user = navdb_read; database = ZYGO-NAV-PROD;");
            cnxn.Open();
            SqlCommand cmd = new SqlCommand("select [Metadata] from [Object Metadata] where [Object Type] = 1 AND [Object ID] = 27", cnxn);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var ms = new MemoryStream();
                    if (BLOB.GetDecompressedStream2013(reader, true, ref ms) == 1)
                    {
                        ms.Position = 0;
                        StreamReader sr = new StreamReader(ms);
                        string text = sr.ReadToEnd();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        public static int GetDecompressedStream2013(SqlDataReader reader, bool decompress, ref MemoryStream ResultStream)
        {
            int fieldIndex = 0;
            int num2 = reader.IsDBNull(fieldIndex) ? 0 : ((int)reader.GetBytes(fieldIndex, 0L, null, 0, 0));
            if (num2 > 0)
            {
                using (Stream stream = new BlobReaderStream(reader, fieldIndex, num2))
                {
                    if (decompress)
                    {
                        byte[] array = new byte[4];
                        long num3 = (long)stream.Read(array, 0, 4);
                        if (num3 < 4L || !BlobMagicOk(array))
                        {
                            int result = 22926086;
                            return result;
                        }

                        using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
                        {
                            deflateStream.CopyTo(ResultStream);
                        }
                    }
                    else
                        stream.CopyTo(ResultStream);
                    return 1;
                }
            }

            return 0;
        }

        private static bool BlobMagicOk(byte[] checkMagic)
        {
            for (int i = 0; i < 4; i++)
            {
                if (checkMagic[i] != BlobMagic[i])
                {
                    return false;
                }
            }
            return true;
        }


        private static byte[] BlobMagic = new byte[]
        {
            2,
            69,
            125,
            91
        };
    }

    public class BlobReaderStream : System.IO.Stream
    {
        private SqlDataReader reader;
        private int fieldIndex;
        private int length;
        private int position;
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
        public override long Length
        {
            get
            {
                return (long)this.length;
            }
        }
        public override long Position
        {
            get
            {
                return (long)this.position;
            }
            set
            {
                this.position = (int)value;
            }
        }
        public BlobReaderStream(SqlDataReader reader, int fieldIndex, int length)
        {
            this.reader = reader;
            this.fieldIndex = fieldIndex;
            this.length = length;
        }
        public override void Flush()
        {
        }
        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            throw new System.NotSupportedException();
        }
        public override void SetLength(long value)
        {
            throw new System.NotSupportedException();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this.position < this.length)
            {
                int num = (int)this.reader.GetBytes(this.fieldIndex, (long)this.position, buffer, offset, count);
                this.position += num;
                return num;
            }
            return 0;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new System.NotSupportedException();
        }
    }
}