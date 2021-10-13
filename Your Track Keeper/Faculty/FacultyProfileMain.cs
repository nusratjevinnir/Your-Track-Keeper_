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
    public partial class FacultyProfileMain : Form
    {
       

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
      
        public FacultyProfileMain()
        {
            InitializeComponent();
            BindGridView();
        }
        

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[7].Value);
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
            string query = "insert into FACULTYDETAILS values (@id,@name,@dept,@class,@cons,@build,@cubic,@img)";
             
               SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@id", textBox1.Text);
            cd.Parameters.AddWithValue("@name", textBox2.Text);
            cd.Parameters.AddWithValue("@dept", textBox3.Text);
            cd.Parameters.AddWithValue("@class", textBox5.Text);
            cd.Parameters.AddWithValue("@cons", textBox6.Text);
            cd.Parameters.AddWithValue("@build", textBox7.Text);
            cd.Parameters.AddWithValue("@cubic", textBox8.Text);
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
        void BindGridView(  )
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "select * from FACULTYDETAILS where id like  '" + textBox4.Text + "%'";


            SqlDataAdapter sda = new SqlDataAdapter(query, co);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Image Column 
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AutoSize Table column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Image Row Height 
            dataGridView1.RowTemplate.Height = 80;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection co = new SqlConnection(cs);
            string query = "delete from  FACULTYDETAILS  where id=@id";

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

            textBox5.Clear();

            textBox6.Clear();

            textBox7.Clear();
            pictureBox1.Image = Properties.Resources.download;
            //throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "update  FACULTYDETAILS set ID=@id, NAME=@name,DEPARTMENT=@dept,CLASS_TIME=@class,CONSULTING_TIME=@cons,BUILDING_NAME=@build, CUBICLE_NUMBER=@cubic,PICTURE=@img where ID=@id";

            SqlCommand cd = new SqlCommand(query, co);
            cd.Parameters.AddWithValue("@id", textBox1.Text);
            cd.Parameters.AddWithValue("@name", textBox2.Text);
            cd.Parameters.AddWithValue("@dept", textBox3.Text);
            cd.Parameters.AddWithValue("@class", textBox5.Text);
            cd.Parameters.AddWithValue("@cons", textBox6.Text);
            cd.Parameters.AddWithValue("@build", textBox7.Text);
            cd.Parameters.AddWithValue("@cubic", textBox8.Text);
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
            FacultyHomeAfterLogin h= new FacultyHomeAfterLogin();
            h.Show();
            this.Close();

        }

       // private void Form1_Load(object sender, EventArgs e)
      //  {
      //     textBox4.Text = f.id.Text;
        //    FacPro l = new FacPro();
     //    l.Show();
        //    this.Hide();
    //   }

        private void button7_TextChanged(object sender, EventArgs e)
        {



        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ReceivedRequest p = new ReceivedRequest();
          
          
            p.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
          

          
        }

        private void FacultyProfileMain_Load(object sender, EventArgs e)
        {
            textBox4.Text = LoginFaculty.value;
            BindGridView();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            FacultyProfileMain o = new FacultyProfileMain();
            o.Show();
            this.Hide();
        }
    }
}

