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

namespace adminEstadio
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hora.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
        }

        private void salirToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            Program.ConnSql = new SqlConnection(@"Server=DESKTOP-H9R0K01\SQLEXPRESS; Database=adminEstadioAlt; Trusted_Connection=True;");
            Program.ConnSql.Open();
            /*hora.Text = String.Format("{0:HH:mm:ss}", DateTime.Now);
            fecha.Text = DateTime.Now.ToLongDateString();

            timer1.Interval = 1000;
            timer1.Start();*/
        }

        private void hora_Click(object sender, EventArgs e)
        {
            hora.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void empleados_Click(object sender, EventArgs e)
        {
            empleado Emp = new empleado();
            Emp.MdiParent = this;
            Emp.Show();
        }

        private void mainWindow_formClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleado frmem = new empleado();
            frmem.MdiParent = this;
            frmem.Show();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acercaDe Acerca = new acercaDe();
            Acerca.Show();
        }
    }
}
