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
    public partial class ContainerVersion : Form
    {
        private HomeScreen homescreen;

        public ContainerVersion()
        {
            InitializeComponent();
        }

        public void sendHomeScreen(HomeScreen homescreen)
        {
            this.homescreen = homescreen;
        }

        private void ContainerVersion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
