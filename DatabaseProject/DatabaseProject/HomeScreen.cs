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

        Containers containers;
        ContainerVersion containerversion;
        Locations locations;
        OnShip onship;
        OnTrain ontrain;
        Personnel personnel;
        Ports ports;
        ProductManifest productmanifest;
        Products products;
        Ships ships;
        ShippingCompany shippingcompany;
        ShipVisits shipvisits;
        Storage storage;
        Stacks stacks;
        Trains trains;
        public HomeScreen(Containers containers, ContainerVersion containerversion, Locations locations, OnShip onship, OnTrain ontrain, Personnel personnel, Ports ports, ProductManifest productmanifest, Products products, Ships ships, ShippingCompany shippingcompany, ShipVisits shipvisits, Storage storage, Stacks stacks, Trains trains)
        {
            this.containers = containers;
            containers.sendHomeScreen(this);
            this.containerversion = containerversion;
            containerversion.sendHomeScreen(this);
            this.locations = locations;
            locations.sendHomeScreen(this);
            this.onship = onship;
            onship.sendHomeScreen(this);
            this.ontrain = ontrain;
            ontrain.sendHomeScreen(this);
            this.personnel = personnel;
            personnel.sendHomeScreen(this);
            this.ports = ports;
            ports.sendHomeScreen(this);
            this.productmanifest = productmanifest;
            productmanifest.sendHomeScreen(this);
            this.products = products;
            products.sendHomeScreen(this);
            this.ships = ships;
            ships.sendHomeScreen(this);
            this.shippingcompany = shippingcompany;
            shippingcompany.sendHomeScreen(this);
            this.shipvisits = shipvisits;
            shipvisits.sendHomeScreen(this);
            this.storage = storage;
            storage.sendHomeScreen(this);
            this.stacks = stacks;
            stacks.sendHomeScreen(this);
            this.trains = trains;
            trains.sendHomeScreen(this);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) Console.WriteLine("Nothing selected");
            else
                switch (comboBox1.SelectedIndex)
                {
                    case 0://CONTAINERS
                        containers.Show();
                        Hide();
                        break;
                    case 1://CONTAINERVERSION
                        containerversion.Show();
                        Hide();
                        break;
                    case 2://LOCATIONS
                        locations.Show();
                        Hide();
                        break;
                    case 3://ONSHIP
                        onship.Show();
                        Hide();
                        break;
                    case 4://ONTRAIN
                        ontrain.Show();
                        Hide();
                        break;
                    case 5://PERSONNEL
                        personnel.Show();
                        Hide();
                        break;
                    case 6://PORTS
                        ports.Show();
                        Hide();
                        break;
                    case 7://PRODUCTMANIFEST
                        productmanifest.Show();
                        Hide();
                        break;
                    case 8://PRODUCTS
                        products.Show();
                        Hide();
                        break;
                    case 9://SHIPS
                        ships.Show();
                        Hide();
                        break;
                    case 10://SHIPPINGCOMPANY
                        shippingcompany.Show();
                        Hide();
                        break;
                    case 11://SHIPVISITS
                        shipvisits.Show();
                        Hide();
                        break;
                    case 12://STORAGE
                        storage.Show();
                        Hide();
                        break;
                    case 13://STACKS
                        stacks.Show();
                        Hide();
                        break;
                    case 14://TRAINS
                        trains.Show();
                        Hide();
                        break;
                    default:
                        break;
                }
        }
    }
}
