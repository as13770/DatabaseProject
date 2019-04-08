using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Prototype
{
    public class DataAccess
    {
        public List<Category> getCategories(string id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MyGuitarShop")))
            {
                try
                {
                    return connection.Query<Category>($"SELECT * FROM CATEGORIES WHERE CategoryID={ id }").ToList();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    Console.WriteLine("connection to sql server failed");
                    return null;
                }
            }
        }
    }
}
