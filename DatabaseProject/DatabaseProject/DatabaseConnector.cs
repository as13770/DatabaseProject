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
                SqlCommand sqlquery = new SqlCommand(queryString, connection);
                SqlDataAdapter read = new SqlDataAdapter(sqlquery);
                DataSet ds = new DataSet();
                read.Fill(ds);
                currentview.DataSource = ds.Tables[0];
                connection.Close();
            }
        }

        public void deleteData(String query)
        {
            queryString = query;
        }

        public int addData(String query, SqlParameter[] parameters)
        {
            try
            {
                queryString = query;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlquery = new SqlCommand(queryString, connection);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        sqlquery.Parameters.Add(parameters[i]);
                    }

                    int changed = sqlquery.ExecuteNonQuery();
                    connection.Close();
                    return changed;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return -1;
            }
            
        }

        public int deleteData(String query, SqlParameter parameter)
        {
            queryString = query;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlquery = new SqlCommand(queryString, connection);
                sqlquery.Parameters.Add(parameter);
                int changed = sqlquery.ExecuteNonQuery();
                connection.Close();
                return changed;
            }
        }

    }
}
