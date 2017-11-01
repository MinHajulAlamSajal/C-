using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        //public void insert_query(int id, string name, int price, string ing, byte[] img)
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
        //        string query = "insert into order (Id,Name,Price,Ingredients,Image) values ('" + id + "','" + name + "','" + price + "','" + ing + "',@img)";
        //        //SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
        //        if (conn.State != ConnectionState.Open)
        //        {
        //            MessageBox.Show("HELLO insert method");
        //            conn.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.Add(new SqlParameter("@img", img));
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
       
        public void orderList()
        {
           
          //  MessageBox.Show("order List");
           try{
              
                SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                conn.Open();
            //  SqlDataAdapter adapter = new SqlDataAdapter("select * from ListOrder", conn);
             //   SqlDataAdapter adapter = new SqlDataAdapter("select Person.*,ListOrder.* from Person,ListOrder", conn);
             //   SqlDataAdapter adapter = new SqlDataAdapter("select Person.*,ListOrder.* from Person,ListOrder ", conn);
               SqlDataAdapter adapter = new SqlDataAdapter(" select * from ViewOrder " , conn);
               DataTable dt = new DataTable();
                         adapter.Fill(dt);
                         dataGridView1.DataSource = dt;

                         DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                         dataGridView1.Columns.Add(chk);
                         chk.HeaderText = "Delivered";
                         chk.Name = "chk";

                         dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                         dataGridView1.RowTemplate.Height = 150;
                         dataGridView1.AllowUserToAddRows = false;
               

                     }
                     catch (Exception ex)
                     {
                       //  MessageBox.Show("Exception");
                     }
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                try
                {
                 //   string id = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                   //    MessageBox.Show((e.RowIndex + 1) + "Row" + (e.ColumnIndex + 1) + "Column button Clicked");
                 //   int a = e.RowIndex;
                    // int b = e.ColumnIndex ;
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = true;
                       string a = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                       string b = dataGridView1.Rows[e.RowIndex].Cells["UserCode"].Value.ToString();
                   //    MessageBox.Show("id" + a);
                   //    MessageBox.Show("userCode" + b);
                   //   string query = "delete from ViewOrder where UseCode='" + b + "' and Id='" + a + "'";
                    //   string query = "delete from ViewOrder where UserCode="+b;
                       string query = "delete from ViewOrder where Id =" + a;
                       SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                       conn.Open();
                       SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                       DataTable dt = new DataTable();
                       adapter.Fill(dt);
                    //   delete from employee   where firstname = 'Mike' or firstname = 'Eric';

 
                }
                catch (Exception ex) { 
                }
            }
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
                             
        }

        
    }
}

