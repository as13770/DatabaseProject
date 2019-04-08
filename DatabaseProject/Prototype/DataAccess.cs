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
        public List<Category> getCategories(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MyGuitarShop")))
            {
                return connection.Query<Category>("SELECT * FROM CATEGORIES").ToList();
            }
        }
    }
}
