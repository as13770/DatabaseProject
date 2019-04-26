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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            initializeData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            initializeData();

        }

        private void initializeData()
        {
            DatabaseConnector dc = new DatabaseConnector(this.dataGridView1, "Products");
            dc.viewTable();
            dataGridView1.Refresh();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            new HomeScreen().Show();
        }
    }
}
