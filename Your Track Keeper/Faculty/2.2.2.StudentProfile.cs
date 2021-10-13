using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Faculty
{
    public partial class StudentProfile : Form
    {
      //  LoginStudent l;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public StudentProfile()
        {
            InitializeComponent();
            BindGridView();
           
        }
    //   public StudentProfile(LoginStudent m)
     //  {
     //       InitializeComponent();
      //    // BindGridView();
      //     this.l = m;
      //  }
    //
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oft = new OpenFileDialog();
            oft.Title = "SELECT IMAGE";
            //   oft.Filter = "PNG File (*.jpg) | *.jpg";
            //   oft.Filter="PNG File (*.png) | *.png";
            oft.Filter = "All Image File (*.*) | *.*";
            //  oft.ShowDialog();
            if (oft.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(oft.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "insert into STUDENTDETAILS values( @id,@name,@dept,@img)";

            SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@id", textBox1.Text);
            cd.Parameters.AddWithValue("@name", textBox2.Text);
            cd.Parameters.AddWithValue("@dept", textBox3.Text);
            cd.Parameters.AddWithValue("@img", SavePhoto());
            co.Open();
            int a = cd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted successfully !");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Inserted !");
            }

            co.Close();

        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            //  throw new NotImplementedException();
            return ms.GetBuffer();
        }
        void BindGridView()
        {

            SqlConnection co = new SqlConnection(cs);
            string query = "select * from STUDENTDETAILS where id like  '" + textBoxk.Text + "%'";


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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "delete from  STUDENTDETAILS  where id=@id";

            SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@id", textBox1.Text);

            co.Open();
            int a = cd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted successfully !");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Deleted !");
            }

            co.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = Properties.Resources.download;
            //throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "update  STUDENTDETAILS set id= @id, name=@name,DEPARTMENT=@dept,picture=@img where id=@id";

            SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@id", textBox1.Text);
            cd.Parameters.AddWithValue("@name", textBox2.Text);
            cd.Parameters.AddWithValue("@dept", textBox3.Text);
            cd.Parameters.AddWithValue("@img", SavePhoto());
            co.Open();
            int a = cd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Updated successfully !");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Updated !");
            }

            co.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginStudent h = new LoginStudent();
            h.Show();
            this.Close();

        }

       
        private void button7_TextChanged(object sender, EventArgs e)
        {

         
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

          //  textBoxk.Text = l.ids.Text;


        }

        private void button8_Click(object sender, EventArgs e)
        {
          
            StudentHomeAfterLogin h = new StudentHomeAfterLogin();
            h.Show();
            this.Hide();
        }

        private void StudentProfile_Load(object sender, EventArgs e)
        {
            textBoxk.Text = LoginStudent.pass;
            BindGridView();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            StudentProfile l = new StudentProfile();
            l.Show();
            this.Hide();
        }
    }
 }

