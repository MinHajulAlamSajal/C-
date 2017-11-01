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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            #region
            /*     SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Restaurant where Id=" + Restaurant.id_1, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            nameLabel.Text = dt.Rows[0]["Name"].ToString();
            ingredientsLabel.Text = dt.Rows[0]["Ingredients"].ToString();
            priceLabel.Text = dt.Rows[0]["Price"].ToString();
            byte[] img = (byte[])(dt.Rows[0]["Image"]);
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);  */
            #endregion
            
        }
        
        public static string id;
       
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataTable dt;
        public void picView(string TextBox)
        {
            
              id=TextBox;
              //LoginUser(id);
            productDetailPanel.Visible = true;
            try
            {
                SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Restaurant where Id=" + id, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                nameLabel.Text = dt.Rows[0]["Name"].ToString();
                ingredientsLabel.Text = dt.Rows[0]["Ingredients"].ToString();
                priceLabel.Text = dt.Rows[0]["Price"].ToString();
                byte[] img = (byte[])(dt.Rows[0]["Image"]);
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Product is not available");
            }
        }
        public void allPanelClose(){
            profPanel.Visible=false;
            memberPanel.Visible=false;
            productDetailPanel.Visible=false;
            orderPanelA.Visible = false;
        }
        private void orderButton_Click(object sender, EventArgs e)
        {
            allPanelClose();
            memberPanel.Visible=true;
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void viewProf(string TextBox)
        {
            try
            {
              //  MessageBox.Show("View Prof" + TextBox);
                conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                conn.Open();
                adapter = new SqlDataAdapter("select * from Person where UserCode=" + TextBox, conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.RowTemplate.Height = 30;
                dataGridView3.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {

            }
        }
       
        public static string userCode;
        public void LoginUser(string TextBox)
        {
            userCode = TextBox;
            viewProf(TextBox);
        //    MessageBox.Show("Log in" + Form2.userCode);
          //  Form5 f5 = new Form5();
         //   f5.Show();
       //     f5.orderList();
            try
            {

                conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                conn.Open();
                adapter = new SqlDataAdapter("select * from Restaurant where Id=" + Form2.id, conn);
                dt = new DataTable();
                adapter.Fill(dt);
                int id = (int)dt.Rows[0]["Id"];
                string name = dt.Rows[0]["Name"].ToString();
                int price = (int)dt.Rows[0]["Price"];
                string ing = dt.Rows[0]["Ingredients"].ToString();
                byte[] img = (byte[])(dt.Rows[0]["Image"]);
           //     string query = "insert into ListOrder (Id,Price,Name,Ingredients,Image) values ('" + id + "','" + price + "','" + name + "','" + ing + "',@img)";
                string query = "insert into ViewOrder (UserCode,Id,Price,Name,Ingredients,Image) values ('" + TextBox + "','" + id + "','" + price + "','" + name + "','" + ing + "',@img)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                int x = cmd.ExecuteNonQuery();
           
             //   adapter = new SqlDataAdapter("select Person.*,ListOrder.* from Person,ListOrder", conn);
              //  adapter = new SqlDataAdapter("select * from ListOrder", conn);
                //    adapter = new SqlDataAdapter("select Person.*,ListOrder.* from Person,ListOrder where Person.UserCode="+Form2.userCode, conn);

                adapter = new SqlDataAdapter("select * from ViewOrder where UserCode="+TextBox, conn); 
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

               
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 120;
                dataGridView1.AllowUserToAddRows = false;    
            }
            catch (Exception ex)
            {

            }
        }
        private void Loginbutton_Click(object sender, EventArgs e)
        {
        
            string query="select UserCode,Mobile from Person where UserCode='"+userCodeTextBox.Text+"'and Mobile='"+mobileTextBox.Text+"'";
            SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
           
            string a = dt.Rows[0]["UserCode"].ToString();
            string b = dt.Rows[0]["Mobile"].ToString();
         //   string user = a;
           // string mobile = b;
         //   int user=int.Parse(dt.Rows[0]["UserCode"].ToString());
          //  int mobile=int.Parse(dt.Rows[0]["Mobile"].ToString());
            if (userCodeTextBox.Text == a && mobileTextBox.Text == b)
            {
              allPanelClose();
                profPanel.Visible = true;
                LoginUser(a);
            }
            else
            {
                MessageBox.Show("Wrong Entered");
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
         //   MessageBox.Show("OK ! \nAdd Your Cart");
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

            }
            MessageBox.Show("Total Food Price Is =" + sum);
        }

        private void registerF2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            f3.registerDB();
        }



        public int Rows { get; set; }
    }
}
