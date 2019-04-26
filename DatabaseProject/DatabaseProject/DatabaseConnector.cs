using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DatabaseProject
{
    public class DatabaseConnector
    {
        String connectionString = "Server=databasesystemsproject.cy9rjwfchpnj.us-east-1.rds.amazonaws.com,1433;Database=SavannahPort;User Id=admin;Password=mypassword;";
        String queryString;
        DataGridView currentview;
        String currentTable;

        public DatabaseConnector(DataGridView dataGridViewer, String table)
        {
            currentview = dataGridViewer;
            currentTable = table;
        }

        public void viewTable()
        {
            queryString = "SELECT * FROM " + currentTable;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand query = new SqlCommand(queryString, connection);          
                SqlDataAdapter read = new SqlDataAdapter(query);
                DataSet ds = new DataSet();
                read.Fill(ds);
                currentview.DataSource = ds.Tables[0];
            }
        }

        public void deleteData(String id)
        {
            queryString = "";
        }

    }
}
