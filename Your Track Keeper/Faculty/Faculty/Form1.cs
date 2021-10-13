﻿using System;
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
    public partial class Form1 : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
       //     BindGridView();
        }

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
            string query = "insert into student values( @id,@name,@dept,@img)";

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
            string query = "select * from student";
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
            string query = "delete from  student  where id=@id";

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
            string query = "update  student set id= @id, name=@name,dept=@dept,picture=@img where id=@id";

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
            Home h = new Home();
            h.Show();
            this.Close();

        }
    }
 }

