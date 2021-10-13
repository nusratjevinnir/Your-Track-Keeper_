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
    public partial class AllFacultylist : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AllFacultylist()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentHomeAfterLogin g = new StudentHomeAfterLogin();
            g.Show();
            this.Hide();
        }
        void BindGridView()
        {
            SqlConnection co = new SqlConnection(cs);
            string query = "select * from FACULTYDETAILS";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            co.Open();
            string query = "select * from FACULTYDETAILS where id like '" + textBox1.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, co);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            co.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AllFacultylist_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentHomeAfterLogin n = new StudentHomeAfterLogin();
            n.Show();
            this.Hide();
        }
    }
}
