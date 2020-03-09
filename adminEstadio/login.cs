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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ok_click(object sender, EventArgs e)
        {
            if(usuario.Text == "uat" && contraseña.Text == "123")
            {
                login login = new login();
                login.Hide();
                mainWindow mainWindow = new mainWindow();
                mainWindow.Show();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void ok_Click_1(object sender, EventArgs e)
        {
            mainWindow mainWindow = new mainWindow();
            //frmEm.MdiParent = this;
            mainWindow.Show();
            Visible = false;
        }
    }
}
