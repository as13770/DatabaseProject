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
    public partial class ShipVisits : Form
    {
        private HomeScreen homescreen;
        DatabaseConnector dc;
        String tableName;

        public ShipVisits()
        {
            tableName = "ShipVisits";
            InitializeComponent();
            dc = new DatabaseConnector(this.dataGridView1, tableName);
            initializeData();
        }

        private void initializeData()
        {
            dc.viewTable();
            dataGridView1.Refresh();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public void sendHomeScreen(HomeScreen homescreen)
        {
            this.homescreen = homescreen;
        }

        private void ShipVisits_FormClosed(object sender, FormClosedEventArgs e)
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
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
                {
                    AddStatus.Text = "Missing Information";
                }
                else
                {
                    AddStatus.Text = "";
                    String query = "INSERT INTO " + tableName + " ([VisitID], [ShipID], [CompanyID], [PortOfArrival], [PortOfDeparture], [DateArrival], [GrossTonnage], [CrewsEffectsDeclaration], [MaritimeDeclarationOfHealth], [Nettonnage], [Remarks]) ";
                    query += "VALUES (@VisitID, @ShipID, @CompanyID, @PortOfArrival, @PortOfDeparture, @DateArrival, @GrossTonnage, @CrewsEffectsDeclaration, @MaritimeDeclarationOfHealth, @Nettonnage, @Remarks);";
                    SqlParameter[] parameters = {
                        new SqlParameter("@VisitID", textBox1.Text),
                        new SqlParameter("@ShipID", textBox2.Text),
                        new SqlParameter("@CompanyID", textBox4.Text),
                        new SqlParameter("@PortOfArrival", textBox5.Text),
                        new SqlParameter("@PortOfDeparture", textBox6.Text),
                        new SqlParameter("@DateArrival", textBox7.Text),
                        new SqlParameter("@GrossTonnage", textBox8.Text),
                        new SqlParameter("@CrewsEffectsDeclaration", textBox9.Text),
                        new SqlParameter("@MaritimeDeclarationOfHealth", textBox10.Text),
                        new SqlParameter("@Nettonnage", textBox11.Text),
                        new SqlParameter("@Remarks", textBox12.Text)
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
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
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
                String query = "DELETE FROM " + tableName + " WHERE VisitID = @VisitID";
                SqlParameter parameter = new SqlParameter("@VisitID", textBox3.Text);
                DeleteStatus.Text = "Rows changed: " + dc.deleteData(query, parameter);
                textBox3.Text = "";
                initializeData();
            }
        }
    }
}
