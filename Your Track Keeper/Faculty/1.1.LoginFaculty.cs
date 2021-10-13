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
    public partial class LoginFaculty : Form
    {
        public static string value;
        //CS Connection string
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public LoginFaculty()
        {
            InitializeComponent();
        }

     
        private void textBox4_Leave(object sender, EventArgs e)
        {
           

        }

        private void textBox3_Leave(object sender, EventArgs e)
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
            MainHomePage k = new MainHomePage();
            k.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (id.Text != "" && pass.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from facultydetails where id = @user and cubicle_number = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", id.Text);
                cmd.Parameters.AddWithValue("@pass", pass.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                     MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    value = id.Text;
                    FacultyHomeAfterLogin f = new FacultyHomeAfterLogin();
                    f.Show();
                 //   FacPro ff = new FacPro();
                //    ff.Show();
                    //   ReceivedRequest r = new ReceivedRequest(this);
                    //  r.Show();

                    //   FacPro fg = new FacPro(this);
                    // fg.ShowDialog();

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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox2.Checked;
            switch (status)
            {
                case true:
                    pass.UseSystemPasswordChar = false;
                    break;

                default:
                    pass.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pass.Text) == true)
            {
                pass.Focus();
                errorProvider2.SetError(this.pass, "Please fill the field first!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text) == true)
            {
                id.Focus();
                errorProvider1.SetError(this.id, "Please fill the field first!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
