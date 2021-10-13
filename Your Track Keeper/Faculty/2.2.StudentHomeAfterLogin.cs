using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty
{
    public partial class StudentHomeAfterLogin : Form
    {
      //  StudentProfile u;
        public StudentHomeAfterLogin()
      {
            InitializeComponent();
        }
     //   public StudentHomeAfterLogin(StudentProfile h)
      //  {
      ////      InitializeComponent();
       //     this.u = h;
      //  }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllDeptInfo p = new AllDeptInfo();
            p.Show();
            this.Hide();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentProfile f = new StudentProfile();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginStudent o = new LoginStudent();

            o.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FacultyResponse g = new FacultyResponse();
            g.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SendRequest k = new SendRequest();
            k.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        //    label2.Text = u.textBoxk.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
          //  label2.Text = u.textBoxk.Text;
        }

        private void StudentHomeAfterLogin_Load(object sender, EventArgs e)
        {
       //     label2.Text = u.textBoxk.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentProfile m = new StudentProfile();
            m.Show();
            this.Hide();
        }

        //  private void StudentHomeAfterLogin_Load(object sender, EventArgs e)
        //  {
        //     label2.Text = u.textBoxk.Text;



        //  }
    }
}
