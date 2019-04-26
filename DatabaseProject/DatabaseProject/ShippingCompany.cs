﻿using System;
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
    public partial class ShippingCompany : Form
    {
        private HomeScreen homescreen;

        public ShippingCompany()
        {
            InitializeComponent();
        }

        public void sendHomeScreen(HomeScreen homescreen)
        {
            this.homescreen = homescreen;
        }

        private void ShippingCompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
