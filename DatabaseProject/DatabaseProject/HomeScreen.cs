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
        public HomeScreen(Containers containers, ContainerVersion containerversion, Locations locations, OnShip onship, OnShip ontrain, Personnel personnel, Ports ports, ProdcutManifest productmanifest, Products products, Ships ships, ShippingCompany shippingcompany, ShipVisits shipvisits, Storage storage, Stacks stacks, Trains trains)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) Console.WriteLine("Nothing selected");
            else
                switch (comboBox1.SelectedIndex)
                {
                    case 0://CONTAINERS
                        break;
                    case 1://CONTAINERVERSION
                        break;
                    case 2://LOCATIONS
                        break;
                    case 3://ONSHIP
                        break;
                    case 4://ONTRAIN
                        break;
                    case 5://PERSONNEL
                        break;
                    case 6://PORTS
                        break;
                    case 7://PRODUCTMANIFEST
                        break;
                    case 8://PRODUCTS
                        Hide();
                        new Products().Show();
                        break;
                    case 9://SHIPS
                        break;
                    case 10://SHIPPINGCOMPANY
                        break;
                    case 11://SHIPVISITS
                        break;
                    case 12://STORAGE
                        break;
                    case 13://STACKS
                        break;
                    case 14://TRAINS
                        break;
                    default:
                        break;
                }
        }
    }
}
