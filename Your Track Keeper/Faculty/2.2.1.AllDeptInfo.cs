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
    public partial class AllDeptInfo : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AllDeptInfo()
        {
            InitializeComponent();
            hideSubMenu();
            BindGridView();
        }

        private void hideSubMenu()
        {
            PanelSub.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
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
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            co.Open();
            string querrry = "select * from FACULTYDETAILS where DEPARTMENT like 'CSE%'";
            SqlDataAdapter sda = new SqlDataAdapter(querrry, co);
            DataTable dttt = new DataTable();
            sda.Fill(dttt);
            dataGridView1.DataSource = dttt;
            co.Close();

        }

        private void AllDeptInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSub);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            co.Open();
            string querrry = "select * from FACULTYDETAILS where DEPARTMENT like 'BBA%'";
            SqlDataAdapter sda = new SqlDataAdapter(querrry, co);
            DataTable dttt = new DataTable();
            sda.Fill(dttt);
            dataGridView1.DataSource = dttt;
            co.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            co.Open();
            string querrry = "select * from FACULTYDETAILS where DEPARTMENT like 'EEE%'";
            SqlDataAdapter sda = new SqlDataAdapter(querrry, co);
            DataTable dttt = new DataTable();
            sda.Fill(dttt);
            dataGridView1.DataSource = dttt;
            co.Close();
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
     
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection(cs);
            co.Open();
            string querrry = "select * from FACULTYDETAILS where id like '" + textBox1.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(querrry, co);
            DataTable dttt = new DataTable();
            sda.Fill(dttt);
            dataGridView1.DataSource = dttt;
            co.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentHomeAfterLogin o = new StudentHomeAfterLogin();
            o.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {

           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label8.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

        }
    }
 
}
