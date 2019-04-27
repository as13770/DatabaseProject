﻿using System;
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
    public partial class Ships : Form
    {
        private HomeScreen homescreen;
        DatabaseConnector dc;
        String tableName;

        public Ships()
        {
            tableName = "Ships";
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

        public void sendHomeScreen(HomeScreen homescreen)
        {
            this.homescreen = homescreen;
        }

        private void Ships_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
                {
                    AddStatus.Text = "Missing Information";
                }
                else
                {
                    AddStatus.Text = "";
                    String query = "INSERT INTO " + tableName + " ([ShipID (IMO)], [Vessel_Name], [Classification]) ";
                    query += "VALUES (@ShipIDIMO, @Vessel_Name, @Classification);";
                    SqlParameter[] parameters = { new SqlParameter("@ShipIDIMO", textBox1.Text), new SqlParameter("@Vessel_Name", textBox2.Text), new SqlParameter("@Classification", textBox4.Text) };
                    AddStatus.Text = "Rows changed: " + dc.addData(query, parameters);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    initializeData();

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
                String query = "DELETE FROM " + tableName + " WHERE [ShipID (IMO)] = @ShipIDIMO";
                SqlParameter parameter = new SqlParameter("@ShipIDIMO", textBox3.Text);
                DeleteStatus.Text = "Rows changed: " + dc.deleteData(query, parameter);
                textBox3.Text = "";
                initializeData();
            }
        }
    }
}
