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
    public partial class MainHomePage : Form
    {

        public MainHomePage()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            panelSub.Visible = false;
            
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
       

        private void button1_Click(object sender, EventArgs e)
        {

            hideSubMenu();
            LoginFaculty f = new LoginFaculty();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            hideSubMenu();
            LoginStudent f = new LoginStudent();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Media_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSub);
        }

        private void MainHomePage_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bunifuTransition3.HideSync(thirdUC1);
            bunifuTransition2.HideSync(secondUC1);           
            bunifuTransition1.ShowSync(firstUC1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(firstUC1);
            bunifuTransition3.HideSync(thirdUC1);
            bunifuTransition1.ShowSync(secondUC1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(secondUC1);
            bunifuTransition3.HideSync(firstUC1);
            bunifuTransition1.ShowSync(thirdUC1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loginAdmin l = new loginAdmin();
            l.Show();
            this.Hide();
            bunifuTransition2.HideSync(thirdUC1);
            bunifuTransition3.HideSync(secondUC1);
            bunifuTransition1.ShowSync(firstUC1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(firstUC1);
            bunifuTransition3.HideSync(thirdUC1);
            bunifuTransition1.ShowSync(secondUC1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(secondUC1);
            bunifuTransition3.HideSync(firstUC1);
            bunifuTransition1.ShowSync(thirdUC1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.office.com/?auth=2");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.aiub.edu/contact-us");
        }

        private void thirdUC1_Load(object sender, EventArgs e)
        {
         About_Us J = new  About_Us();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            About_Us o = new About_Us();
            o.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
