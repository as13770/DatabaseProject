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
    public partial class ShipVisits : Form
    {
        private HomeScreen homescreen;

        public ShipVisits()
        {
            InitializeComponent();
            initializeData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initializeData();

        }

        public void sendHomeScreen(HomeScreen homescreen)
        {
            this.homescreen = homescreen;
        }

        private void initializeData()
        {
            DatabaseConnector dt = new DatabaseConnector(this.dataGridView1, "Ships");
            dt.viewTable();
            dataGridView1.Refresh();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            Hide();
            homescreen.Show();
        }

        private void ShipVisits_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
