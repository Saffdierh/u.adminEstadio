using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adminEstadio
{
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr1 = new Timer();

            //set time interval 3 sec
            tmr1.Interval = 100;

            //starts the timer
            tmr1.Start();

            tmr1.Tick += tmr_Tick;

        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr1.Stop();

            //display mainform
            login mf = new login();
            mf.Show();

            //hide this form
            this.Hide();

        }
        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit application when form is closed
            Application.Exit();
        }
    }
}
