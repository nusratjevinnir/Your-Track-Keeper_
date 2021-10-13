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
  

    public partial class loginAdmin : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public loginAdmin()
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

        private void Login_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from loginFac where username = @user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                     MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminEdit s = new AdminEdit();
                    s.Show();
                    this.Hide();

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

        private void button1_Click(object sender, EventArgs e)
        {
            MainHomePage p = new MainHomePage();
            p.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the field first!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
