using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeScreen(new Containers(), new ContainerVersion(), new Locations(), new OnShip(), new OnTrain(), new Personnel(), new Ports(), new ProductManifest(), new Products(), new Ships(), new ShippingCompany(), new ShipVisits(), new Storage(), new Stacks(), new Trains()));
        }
    }
}
