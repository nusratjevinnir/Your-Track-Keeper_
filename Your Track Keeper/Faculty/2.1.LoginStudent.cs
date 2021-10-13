using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Faculty

{
    public partial class LoginStudent : Form
    {
        public static string pass;
        //CS Connection string
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public LoginStudent()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void Login_Click(object sender, EventArgs e)
        {
            
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void LogStudent_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainHomePage a = new MainHomePage();
            a.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill the field first!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ids.Text) == true)
            {
                ids.Focus();
                errorProvider1.SetError(this.ids, "Please fill the field first!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ids.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from loginStudent where username = @user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", ids.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     StudentHomeAfterLogin s = new StudentHomeAfterLogin();
                     s.Show();
                    pass = ids.Text;
                  //  StudentProfile p = new StudentProfile();
                 //   p.Show();
                    this.Hide();
                    //   StudentProfile p = new StudentProfile(this);
                    //  p.Show();
                    //  this.Hide();

                }
                else
                {
                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                con.Close();

            }
            else
            {
                MessageBox.Show("Please fill both fields first!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;

                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }
    }
}
