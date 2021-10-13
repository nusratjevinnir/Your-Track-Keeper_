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
using System.IO;
namespace Faculty
{
    public partial class ReceivedRequest : Form
    {
    
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    
        public ReceivedRequest( )
        {
            InitializeComponent();
            BindGridView();

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void BindGridView()
        {


            SqlConnection co = new SqlConnection(cs);
            string query = "select * from AppointmentStudent where faculty_id like  '" + label6.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, co);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Image Column 
            //    DataGridViewImageColumn dgv = new DataGridViewImageColumn();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Image Row Height 
            dataGridView1.RowTemplate.Height = 80;
            //ReceivedRequest p = new ReceivedRequest();

        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            SqlConnection co = new SqlConnection(cs);
            string query = "insert into Response  values (@fid,@name,@dept,@sid,@req) ";
       
            SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@fid", label6.Text);
           
            cd.Parameters.AddWithValue("@name", name.Text);
            cd.Parameters.AddWithValue("@dept", d.Text);
            cd.Parameters.AddWithValue("@sid", idd.Text);
            cd.Parameters.AddWithValue("@req", button1.Text);
            co.Open();
            int a = cd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Request Sent successfully !");
              //  BindGridView();

            }
            else
            {
                MessageBox.Show("Request Not Inserted !");
            }

            co.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "insert into Response  values (@fid,@name,@dept,@sid,@req)";

           SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@fid", label6.Text);
          
            cd.Parameters.AddWithValue("@name", name.Text);
            cd.Parameters.AddWithValue("@dept", d.Text);
            cd.Parameters.AddWithValue("@sid", idd.Text);
            cd.Parameters.AddWithValue("@req", button2.Text);

            co.Open();
            int a = cd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Request Not Approved  !");
                //BindGridView();

            }
            else
            {
                MessageBox.Show("Error !");
            }

            co.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FacultyProfileMain p = new FacultyProfileMain();
            p.Show();
            this.Hide();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          //  fid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            idd.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
          //  name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
          //  d.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "delete  from AppointmentStudent where Faculty_ID=@fid ";

            SqlCommand cd = new SqlCommand(query, co);
          cd.Parameters.AddWithValue("@fid", label6.Text);
    

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

        private void button5_Click(object sender, EventArgs e)
        {
           // BindGridView();
        }

       // private void ReceivedRequest_Load(object sender, EventArgs e)
     //   {
           // fid.Text = ff.textBox4.Text;
       // }

        private void button6_Click(object sender, EventArgs e)
        {
            FacultyHomeAfterLogin p = new FacultyHomeAfterLogin();
            p.Show();
            this.Hide();
        }
        void Show()
        {
            SqlConnection co = new SqlConnection(cs);
            co.Open();
            string query = "select name,department from facultydetails where id = " + int.Parse(label6.Text);
            SqlCommand cmd = new SqlCommand(query, co);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name.Text = (dr["NAME"].ToString());
                d.Text = (dr["DEPARTMENT"].ToString());
            }
            else
            {
                name.Text = "";
                d.Text = "";
                MessageBox.Show("No Record!");
            }
            co.Close();
        }
        private void ReceivedRequest_Load(object sender, EventArgs e)
        {
            label6.Text = LoginFaculty.value;

            BindGridView();
            Show();
         //   SqlConnection co = new SqlConnection(cs);
         //  string query = "select name from facultydetails where id like  '" + fid.Text + "%'";
         
            //   name.Text= Fa
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
