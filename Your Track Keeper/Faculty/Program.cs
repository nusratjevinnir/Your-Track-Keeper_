using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new ReceivedRequest());
          // Application.Run(new SendRequest());
           // Application.Run(new FacultyProfile());
            //Application.Run(new FacultyHomeAfterLogin());
            Application.Run(new MainHomePage());
            //Application.Run(new LoginStudent());
            //Application.Run(new AllDeptInfo());
            //Application.Run(new StudentProfile());
         //  Application.Run(new FacultyResponse());
          //  Application.Run(new StudentHomeAfterLogin());
            //Application.Run(new AllFacultylist());
          //  Application.Run(new SendRequest());
            //Application.Run(new Form1());

        }
    }
}
