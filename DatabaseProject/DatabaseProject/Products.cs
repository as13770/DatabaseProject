using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class Products : Form
    {
        private HomeScreen homescreen;
        DatabaseConnector dc;
        String tableName;

        public Products()
        {
            tableName = "Products";
            InitializeComponent();
            dc = new DatabaseConnector(this.dataGridView1, tableName);
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
            dc.viewTable();
            dataGridView1.Refresh();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            homescreen.Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                AddStatus.Text = "Missing Information";
            }
            else
            {
                AddStatus.Text = "";
                String query = "INSERT INTO "+tableName+" (ProductID, Name) ";
                query += "VALUES (@ProductID, @Name);";
                SqlParameter[] parameters = { new SqlParameter("@ProductID", textBox1.Text), new SqlParameter("@Name", textBox2.Text) };
                dc.addData(query, parameters);
                textBox1.Text = "";
                textBox2.Text = "";
                initializeData();

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                DeleteStatus.Text = "Missing Information";
            }
            else
            {
                DeleteStatus.Text = "";
                String query = "DELETE FROM " + tableName + " WHERE ProductID = @ProductID";
                SqlParameter parameter = new SqlParameter("@ProductID", textBox3.Text);
                dc.deleteData(query, parameter);
                textBox3.Text = "";
                initializeData();
            }
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
