using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test2
{
    public partial class EditData : Form
    {
        SqlDataAdapter dataAdapter;
        BindingSource bindingSource1 = new BindingSource();
        DataTable table;
        string sql;

        public EditData()
        {
            InitializeComponent();
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * 
             * Table must have primary key for edit to work
             * 
             * */

            sql = "SELECT " +
                         "  uid " +
                         ",[documentnumber] " +
                         ",[revision] " +
                         ",[pldescription] " +
                         ",[item_code] " +
                         ",[description] " +
                         ",[quantity] " +
                         ",[boxes] " +
                         ",[installon] " +
                         ",[kitwith] " +
                         "FROM Labels_PackingLists where Documentnumber = '" + g.document +  "' " +
                         "AND revision = '" + g.RevToEdit + "'";


            DGV.DataSource = bindingSource1;
            /*  data connection for bindingSource1 defined in GetData  */
            GetData(sql);
        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    "server = CT-MID-SQL11; Database = AccessFrontEnds;" +
                            "user = readWrite; password = Read+Write!;";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                
                // Resize the DataGridView columns to fit the newly loaded content.
                DGV.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

                DGV.Columns[0].Visible = false;

                
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            /*
             *  table needs go have primary key set to function correctly.
             * */

            dataAdapter.Update(table);
        }
    }
}
