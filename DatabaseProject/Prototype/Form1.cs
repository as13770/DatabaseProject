using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class Form1 : Form
    {
        List<Category> categories = new List<Category>();

        public Form1()
        {
            InitializeComponent();

            categoriesListBox.DataSource = categories;
            categoriesListBox.DisplayMember = "FullInfo";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            categories = db.getCategories(idText.Text);

            categoriesListBox.DataSource = categories;
            categoriesListBox.DisplayMember = "FullInfo";
        }
    }
}
