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
    public partial class Containers : Form
    {
        private HomeScreen homescreen;
        DatabaseConnector dc;
        String tableName;

        public Containers()
        {
            tableName = "Containers";
            InitializeComponent();
            dc = new DatabaseConnector(this.dataGridView1, tableName); //pass the datagrid where the data will be displayed, and the name of the table for querying
            initializeData();
        }

        private void initializeData() //Displays the current table inside the datagrid
        {
            dc.viewTable();
            dataGridView1.Refresh();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void Refresh_Click(object sender, EventArgs e) //Displays the current table with up-to-date information
        {
            initializeData();
        }

        private void BackButton_Click(object sender, EventArgs e) //goes back to HomeScreen, which can be navigated to reach other forms
        {
            Hide();
            homescreen.Show();
        }

        private void Add_Click(object sender, EventArgs e) //Inserts values of the textboxes into the table
        {
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    AddStatus.Text = "Missing Information";
                }
                else
                {
                    AddStatus.Text = "";
                    String query = "INSERT INTO " + tableName + " ([SerialNumber], [Size], [isHighCube], [isTanktainer]) ";
                    query += "VALUES (@SerialNumber, @Size, @isHighCube, @isTanktainer);";
                    SqlParameter[] parameters = {
                        new SqlParameter("@SerialNumber", textBox1.Text),
                        new SqlParameter("@Size", textBox2.Text),
                        new SqlParameter("@isHighCube", textBox4.Text),
                        new SqlParameter("@isTanktainer", textBox5.Text),
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
                        textBox4.Text = "";
                        textBox5.Text = "";
                        initializeData();
                    }


                }
            }
        }

        private void Delete_Click(object sender, EventArgs e) //deletes a row from the table
        {
            if (textBox3.Text == "")
            {
                DeleteStatus.Text = "Missing Information";
            }
            else
            {
                DeleteStatus.Text = "";
                String query = "DELETE FROM " + tableName + " WHERE SerialNumber = @SerialNumber";
                SqlParameter parameter = new SqlParameter("@SerialNumber", textBox3.Text);
                DeleteStatus.Text = "Rows changed: " + dc.deleteData(query, parameter);
                textBox3.Text = "";
                initializeData();
            }
        }

        public void sendHomeScreen(HomeScreen homescreen) //Gets passed the homescreen instead of creating a new one
        {
            this.homescreen = homescreen;
        }

        private void Containers_FormClosed(object sender, FormClosedEventArgs e) //Application will not close on its own without this
        {
            Application.Exit();
        }
    }
}
