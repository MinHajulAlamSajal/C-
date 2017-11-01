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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            newUserPnael.Visible = true;
        }

        private void Registerbutton_Click(object sender, EventArgs e)
        {
            registerDB();

           

        }
        public void registerDB()
            {
                try
                {
                int id = int.Parse(UsercodetextBox5.Text);
                string name = nametextBox.Text;              
                int mobile = int.Parse(mobiletextBox2.Text);
                string email = emailtextBox3.Text;
                string city = citytextBox4.Text;
                string query = "insert into Person (UserCode,Name,Mobile,Email,City) values ('" + id + "','" + name + "','" + mobile + "','" + email + "','" + city + "' )";
                
                  //  string query = "insert into Person  values ('" + UsercodetextBox5.Text + "','" + nametextBox.Text + "','" + mobiletextBox2.Text + "','" + emailtextBox3.Text + "','" + citytextBox4.Text + "')";
                    SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                   
                        conn.Open();
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    registerLabel.Text="Registered SuccessFully";
                }
                catch (Exception )
                {
                 //   MessageBox.Show("There is somehting Wrong");
                }
            }
    }
}
