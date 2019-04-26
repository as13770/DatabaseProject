using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) Console.WriteLine("Nothing selected");
            else
                switch (comboBox1.SelectedIndex)
                {
                    case 0: //Cargo
                        break;
                    case 1: //Company
                        break;
                    case 2: //Containers
                        break;
                    case 3: //Crew
                        break;
                    case 4: //Dates
                        break;
                    case 5: //ProductCompany
                        break;
                    case 6: //Products
                        new Products().Show();
                        Hide();
                        break;
                    case 7: //Ship
                        break;
                    case 8: //Transportation
                        break;
                    case 9: //Warehouse
                        break;
                    default:
                        break;
                }
        }
    }
}
