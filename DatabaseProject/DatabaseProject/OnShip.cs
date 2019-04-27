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
    public partial class OnShip : Form
    {
        private HomeScreen homescreen;
        DatabaseConnector dc;
        String tableName;

        public OnShip()
        {
            tableName = "OnShip";
            InitializeComponent();
            dc = new DatabaseConnector(this.dataGridView1, tableName);
            initializeData();
        }

        private void initializeData()
        {
            dc.viewTable();
            dataGridView1.Refresh();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            initializeData();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            homescreen.Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == "" || textBox2.Text == "" )
                {
                    AddStatus.Text = "Missing Information";
                }
                else
                {
                    AddStatus.Text = "";
                    String query = "INSERT INTO " + tableName + " ([visitid], [versionid]) ";
                    query += "VALUES (@visitid, @versionid);";
                    SqlParameter[] parameters = {
                        new SqlParameter("@visitid", textBox1.Text),
                        new SqlParameter("@versionid", textBox2.Text)
                        };
                    int returnedNumber = dc.addData(query, parameters);
                    if (returnedNumber == -1)
                    {
                        AddStatus.Text = "Input Error";
                    }
                    else
                    {
                        AddStatus.Text = "Rows changed: " + returnedNumber;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        initializeData();
                    }


                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                DeleteStatus.Text = "Missing Information";
            }
            else
            {
                DeleteStatus.Text = "";
                String query = "DELETE FROM " + tableName + " WHERE visitid = @visitid";
                SqlParameter parameter = new SqlParameter("@visitid", textBox3.Text);
                DeleteStatus.Text = "Rows changed: " + dc.deleteData(query, parameter);
                textBox3.Text = "";
                initializeData();
            }
        }

        public void sendHomeScreen(HomeScreen homescreen)
        {
            this.homescreen = homescreen;
        }

        private void OnShip_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
