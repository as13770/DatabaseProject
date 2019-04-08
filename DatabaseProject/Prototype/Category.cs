using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        //private int myVar;

        public String FullInfo
        {
            get
            {
                return $"{ CategoryID } {CategoryName }";
            }
        }

    }
}
