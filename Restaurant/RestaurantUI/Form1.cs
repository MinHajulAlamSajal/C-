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
        Form2 f2 ;
        Form3 f3;

        #region Panel
        public Restaurant()
        {
            InitializeComponent();
        }
        public void AllPanelClose()
        {
            home_panel.Visible = false;
            menu_panel.Visible = false;
            signPanel.Visible = false;
            login_panel.Visible = false;
           // signUp_panel.Visible = false;
            foodItem_panel.Visible = false;
           
           
            admin_panel.Visible = false;
        }
       
        private void Home_Button_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            home_panel.Visible = true;
        }
       public void picViewMenu(string TextBox)
        {
            try
            {
                login_panel.Visible = false;
                SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Restaurant where Id=" + TextBox, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
              
                byte[] img = (byte[])(dt.Rows[0]["Image"]);
                MemoryStream ms = new MemoryStream(img);
                
                    if (TextBox == "1")
                    {
                        menuPictureBox1.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "2")
                    {
                        menuPictureBox2.Image = Image.FromStream(ms);
                    }

                    else if (TextBox == "3")
                    {
                        menuPictureBox3.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "4")
                    {
                        menuPictureBox4.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "5")
                    {
                        menuPictureBox5.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "6")
                    {
                        menuPictureBox6.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "7")
                    {
                        menuPictureBox7.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "8")
                    {
                        menuPictureBox8.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "9")
                    {
                        menuPictureBox9.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "10")
                    {
                        menuPictureBox10.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "11")
                    {
                        menuPictureBox11.Image = Image.FromStream(ms);
                    }
                    else if (TextBox == "12")
                    {
                        menuPictureBox12.Image = Image.FromStream(ms);
                    }
            
            }
            catch (Exception ex)
            {
           //     MessageBox.Show("Pic view menu" + ex.Message);
            }
   
        }
        private void MenuButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;
           
            foodItem_panel.Visible = true;
          int  i= 1;
            while (i <= 12)
            {
                #region PicView Menu
           /*     
                    SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select Image from Restaurant where Id=" + i.ToString(), conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    byte[] img = (byte[])(dt.Rows[0]["Image"]);
                    MemoryStream ms = new MemoryStream(img);
                    if (i.ToString() == "1")
                    {
                        menuPictureBox1.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "2")
                    {
                        menuPictureBox2.Image = Image.FromStream(ms);
                    }

                    else if (i.ToString() == "3")
                    {
                        menuPictureBox3.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "4")
                    {
                        menuPictureBox4.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "5")
                    {
                        menuPictureBox5.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "6")
                    {
                        menuPictureBox6.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "7")
                    {
                        menuPictureBox7.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "8")
                    {
                        menuPictureBox8.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "9")
                    {
                        menuPictureBox9.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "10")
                    {
                        menuPictureBox10.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "11")
                    {
                        menuPictureBox11.Image = Image.FromStream(ms);
                    }
                    else if (i.ToString() == "12")
                    {
                        menuPictureBox12.Image = Image.FromStream(ms);
                    }
                }
                */
                #endregion
              //  int x = i;
                 //string a = i.ToString();
                picViewMenu(i.ToString());
                i++;
            }
        }
        private void ContactButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            signPanel.Visible = true;
           
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            login_panel.Visible = true;

        }
   /*     private void BengaliButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;
            foodItem_panel.Visible = true;
        }
        private void IndianButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;
            newUserPnael.Visible = true;
        }
        private void ContinentalButton_Click(object sender, EventArgs e)
        {
            AllPanelClose();
            menu_panel.Visible = true;
            user_panel.Visible = true;
        }*/
       
        #endregion
        #region Method
        public void Login(string TextBox)
        {
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
        public  void LoadDB()
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
        public void addDB()
        {
            try
            {
                picViewMenu(idTextBoxA.Text);
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
                cmd.ExecuteNonQuery();
                //  int x = cmd.ExecuteNonQuery();             
                //   MessageBox.Show(x.ToString() + "record(s) saved");
            }
            catch (Exception ex)
            {

            }
        }
        public void searchDB(string TextBox)
        {
            string query = "select * from Restaurant where name like '%" + searchTextBoxA.Text + "%'";
            SqlConnection conn = new SqlConnection(RestaurantUI.Properties.Settings.Default.ConnectionRestaurant);

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

#endregion
       
            private void EnterButton_Click(object sender, EventArgs e)
            {
                AllPanelClose();           
                Login("");
            }
            private void SignUpButton_Click(object sender, EventArgs e)
            {
                AllPanelClose();
               // signUp_panel.Visible = true;
            }
     /*       private void userTextBox_Click(object sender, EventArgs e)
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
               passTextBox.ForeColor = Color.Black;
               passTextBox.PasswordChar = '*';
               passTextBox.MaxLength = 10;
            }
            private void passTextBox_Leave(object sender, EventArgs e)
            {
                if (passTextBox.Text =="")
                {
                    passTextBox.Text = "Password";
                    passTextBox.ForeColor = Color.Silver;
                }
            }  */
            private void Restaurant_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }           
            private void adminPicBox_Click(object sender, EventArgs e)
            {
                Browse();
            }          
            private void addButtonA_Click(object sender, EventArgs e)
                {
                    addDB();
                    LoadDB();
                }               
            private void Restaurant_Load_1(object sender, EventArgs e)
                {
                    LoadDB();
                    timer1.Start();
                }
            #region      CLICK Pciture
          
#endregion         
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
            private void deleteButton_Click(object sender, EventArgs e)
            {
                deleteDB(idTextBoxA.Text);
            }
            public void textSend(string TextBox)
            {
                errorTextBoxA.Text = TextBox;
            }
            private void commentButton_Click(object sender, EventArgs e)
            {
                textSend(commentTextBox.Text);
            }
            private void commentTextBox_Click(object sender, EventArgs e)
            {
                commentTextBox.Clear();
                commentTextBox.ForeColor = Color.Black;
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                dateLabel.Text = DateTime.Now.ToLongDateString();
                timeLabel.Text = DateTime.Now.ToLongTimeString(); 
            }     
            private void searchTextBoxA_TextChanged(object sender, EventArgs e)
            {
                searchDB("");
            }
            
            private void signButton_Click(object sender, EventArgs e)
            {
                f3 = new Form3();
                f3.Show();
                
            }

            private void Registerbutton_Click(object sender, EventArgs e)
            {

            }

            private void menu_panel_Click(object sender, EventArgs e)
            {
                AllPanelClose();
                foodItem_panel.Visible = true;
                
            }

            

            private void menuPictureBox1_Click(object sender, EventArgs e)
            {
                //   Restaurant.id_1 = idLabel1B.Text;
                f2 = new Form2();
                f2.Show();
                f2.picView(idLabel1.Text);
            }

            private void menuPictureBox2_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idLabel2.Text);
            }

            private void menuPictureBox3_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idLabel3.Text);
            }
            private void menuPictureBox4_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idLabel4.Text);
            }
            private void menuPictureBox5_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel5.Text);
            }

            private void menuPictureBox6_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel6.Text);
            }

            private void menuPictureBox7_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel7.Text);
            }

            private void menuPictureBox8_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel8.Text);
            }

            private void menuPictureBox9_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel9.Text);
            }

            private void menuPictureBox10_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel10.Text);
            }

            private void menuPictureBox11_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel11.Text);
            }

            private void menuPictureBox12_Click(object sender, EventArgs e)
            {
                f2 = new Form2();
                f2.Show();
                f2.picView(idlabel12.Text);
            }

            private void userButtonA_Click(object sender, EventArgs e)
            {
                Form4 f4 = new Form4();
                f4.Show();
                f4.loadDataBase();
            }

            private void orderButton_Click(object sender, EventArgs e)
            {
                
                Form5 f5 = new Form5();
                f5.Show();
                f5.orderList();
              //  f2.LoginUser("");
            }

            private void login_panel_Paint(object sender, PaintEventArgs e)
            {

            }


    }
}
