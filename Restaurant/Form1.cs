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
    public partial class Restaurant : Form
    {
        string imgLoc = "";
        static public string id_1;

        #region Dia
        public Restaurant()
        {
            InitializeComponent();
        }
        public void AllPanelClose()
        {
            home_panel.Visible = false;
            menu_panel.Visible = false;
            contact_panel.Visible = false;
            login_panel.Visible = false;
           // signUp_panel.Visible = false;
            bengali_panel.Visible = false;
            indian_panel.Visible = false;
            continental_panel.Visible = false;
            admin_panel.Visible = false;
        }
       
        private void Home_Button_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            home_panel.Visible = true;
        }
        private void MenuButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;

        }
        private void ContactButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            contact_panel.Visible = true;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            login_panel.Visible = true;

        }
        private void BengaliButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;
            bengali_panel.Visible = true;
        }
        private void IndianButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;
            indian_panel.Visible = true;
        }
        private void ContinentalButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;
            continental_panel.Visible = true;
        }
        private void SignUp2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" SIGN UP SUCCESSFUL");
        }
        #endregion
            public void Login(string TextBox)
            {
                if (userTextBox.Text == "RoyalPlate" && passTextBox.Text == "RoyalPlate")
                {
                    login_panel.Visible = false;
                    admin_panel.Visible = true;

                }
                else
                {
                    MessageForLoginL.Text = "The Password you provided was Wrong ";
                }
            }
            private void EnterButton_Click(object sender, EventArgs e)
            {
                AllPanelClose();
             
              //  Login("");
                if (userTextBox.Text == "RoyalPlate" && passTextBox.Text == "RoyalPlate")
                {
                    login_panel.Visible = false;
                    admin_panel.Visible = true;

                }
                else
                {
                    login_panel.Visible = true;
                    MessageForLoginL.Text = "The Password you provided was Wrong ";
                }
            }
            private void SignUpButton_Click(object sender, EventArgs e)
            {
                AllPanelClose();
               // signUp_panel.Visible = true;
            }
            private void userTextBox_Click(object sender, EventArgs e)
            {
                userTextBox.Clear();
                userTextBox.ForeColor = Color.Black;
            }
            private void userTextBox_Leave(object sender, EventArgs e)
            {
                if (userTextBox.Text == "")
                {
                    userTextBox.Text = "UserName";
                    userTextBox.ForeColor = Color.Silver;
                }
            }
            private void passTextBox_Click(object sender, EventArgs e)
            {
                passTextBox.Clear();
                userTextBox.ForeColor = Color.Black;
            }
            private void passTextBox_Leave(object sender, EventArgs e)
            {
                if (passTextBox.Text =="")
                {
                    passTextBox.Text = "Password";
                    passTextBox.ForeColor = Color.Silver;
                }
            }
            private void Restaurant_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }
            public void Browse()
            {
                try
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "All Files (*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        imgLoc = dlg.FileName.ToString();
                       adminPicBoxA.ImageLocation = imgLoc;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            private void adminPicBox_Click(object sender, EventArgs e)
            {
                Browse();
            }
            public void addDB()
        {
                int id = int.Parse(idTextBoxA.Text);
                String name = nameTextBoxA.Text;
                string ingredients = ingredientsextBoxA.Text;
                int price = int.Parse(priceTextBoxA.Text);
                byte[] img = null;

                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string query = "insert into Restaurant (Id,Name,Price,Ingredients,Image) values ('" + id + "','" + name + "','" + price + "','" + ingredients + "',@img)";
                SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                int x = cmd.ExecuteNonQuery();             
                MessageBox.Show(x.ToString() + "record(s) saved");
        }
            private void addButtonA_Click(object sender, EventArgs e)
                {
                    addDB();
                    LoadDB();
                }
            public void LoadDB()
            {
                SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Restaurant", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.AllowUserToAddRows = false;
            }
            private void Restaurant_Load(object sender, EventArgs e)
            {
      
            }
            private void Restaurant_Load_1(object sender, EventArgs e)
    {
        LoadDB();
    }
            #region      CLICK Pciture
            private void pictureBox1_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel1B.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void bengaliPictureBox2_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel2B.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void bengaliPictureBox3_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel3B.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void indianPictureBox1_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel1I.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void indianPictureBox2_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel2I.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void indianPictureBox3_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel3I.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void continentalPictureBox1_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel1C.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void continentalPictureBox2_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel2C.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }

            private void continentalPictureBox3_Click(object sender, EventArgs e)
            {
                Restaurant.id_1 = idLabel3C.Text;
                Form2 f2 = new Form2();
                f2.Show();
            }
#endregion
            public void updateDB(string TextBox)
            {
              
                    string query = "update Restaurant set Name ='" + nameTextBoxA.Text + "',Price='" + priceTextBoxA.Text + "',Ingredients='" + ingredientsextBoxA.Text + "' where Id= " + TextBox;
                    SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    LoadDB();
               
            }
            private void updatButton_Click(object sender, EventArgs e)
            {
                updateDB(idTextBoxA.Text);
            }          
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                idTextBoxA.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                nameTextBoxA.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                ingredientsextBoxA.Text = dataGridView1.Rows[e.RowIndex].Cells["Ingredients"].Value.ToString();
                priceTextBoxA.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
               
            }
            public void deleteDB(string TextBox)
            {
                string query = "delete from Restaurant where Id=" + TextBox;
                SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                LoadDB();
            }
            private void deleteButton_Click(object sender, EventArgs e)
            {
                deleteDB(idTextBoxA.Text);
            }
   
    }
}
