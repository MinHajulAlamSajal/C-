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

namespace RestaurantUI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public void loadDataBase()
        {
            SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Person", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
