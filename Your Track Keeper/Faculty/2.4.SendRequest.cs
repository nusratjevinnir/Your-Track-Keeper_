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
    public partial class SendRequest : Form
    {
       // StudentHomeAfterLogin m;
      
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public SendRequest()
        {
            InitializeComponent();
          BindGridView();
        }
    //    public SendRequest(StudentHomeAfterLogin l)
     //   {
     //       InitializeComponent();
            // BindGridView();
      //      this.m = l;
//
     //   }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
       {
            //     textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        void ResetControl()
        {
            textBox7.Clear();
        //    label2.Clear();
           
            //label3.Clear();
          //  textBox5.Clear();
            richTextBox2.Clear();
            //throw new NotImplementedException();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "insert into AppointmentStudent  values (@fid,@sid,@name,@dept,@req) ";

            SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@fid", textBox7.Text);
            cd.Parameters.AddWithValue("@sid", textBox1.Text);
            cd.Parameters.AddWithValue("@name", textBox6.Text);
            cd.Parameters.AddWithValue("@dept", textBox5.Text);
            cd.Parameters.AddWithValue("@req", richTextBox2.Text);
            co.Open();
            int a = cd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Request Sent successfully !");
                BindGridView();
                ResetControl();


            }
            else
            {
                MessageBox.Show("Request Not Inserted !");
            }

            co.Close();
        }
        void BindGridView()
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "select * from STUDENTDETAILS where id like  '" + textBox1.Text + "%'";


            SqlDataAdapter sda = new SqlDataAdapter(query, co);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Image Column 
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AutoSize Table column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Image Row Height 
            dataGridView1.RowTemplate.Height = 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentHomeAfterLogin m = new StudentHomeAfterLogin();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void SendRequest_Load(object sender, EventArgs e)
        {
            textBox1.Text = LoginStudent.pass;
            BindGridView();
            SqlConnection co = new SqlConnection(cs);
            co.Open();
        
            string query = "select name,department from studentdetails where  id like  '" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, co);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox6.Text = (dr["NAME"].ToString());
                textBox5.Text = (dr["DEPARTMENT"].ToString());
            }
            else
            {
                textBox6.Text = "";
                textBox5.Text = "";
                MessageBox.Show("No Record!");
            }
            co.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StudentHomeAfterLogin b = new StudentHomeAfterLogin();
            b.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
