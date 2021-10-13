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
    public partial class AdminEdit : Form
    {
        public AdminEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FacultyProfile t = new FacultyProfile();
            t.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StuProAdmin p = new StuProAdmin();
            p.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loginAdmin p = new loginAdmin();
            p.Show();
            this.Hide();
        }
    }
}
