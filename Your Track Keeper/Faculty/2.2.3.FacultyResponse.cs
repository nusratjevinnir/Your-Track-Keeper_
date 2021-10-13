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
    public partial class FacultyResponse : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public FacultyResponse()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "select * from response where student_id like '" + textBox1.Text + "%'";
            //     SqlCommand cd = new SqlCommand(query, co);
            // cd.Parameters.AddWithValue("@fid", .Text);
            SqlDataAdapter sda = new SqlDataAdapter(query, co);
          

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Image Column 
        //    DataGridViewImageColumn dgv = new DataGridViewImageColumn();

            //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Image Row Height 
            dataGridView1.RowTemplate.Height= 80;
          


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentHomeAfterLogin o = new StudentHomeAfterLogin();
            o.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           FacultyResponse f = new FacultyResponse();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "delete from response where Student_Id=@fid  ";

           SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@fid", textBox1.Text);


            co.Open();
            int a = cd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Cleared Successfully  !");
                BindGridView();

            }
            else
            {
                MessageBox.Show("Error !");
            }

            co.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
           textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection co = new SqlConnection(cs);
            co.Open();
            string query = "select * from response where student_id like '" + textBox1.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, co);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            co.Close();
        }

        private void FacultyResponse_Load(object sender, EventArgs e)
        {
            textBox1.Text = LoginStudent.pass;
            BindGridView();
        }
    }
}
