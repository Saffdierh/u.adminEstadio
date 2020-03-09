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
    public partial class empleado : Form
    {
        static string varFoto;
        public empleado()
        {
            InitializeComponent();
        }

        private void empleado_Load(object sender, EventArgs e)
        {
            Program.ConnSql = new SqlConnection(@"server=CC1-ISC-24-PC; Database=Empleados; Trusted_Connection = True;");
            Program.ConnSql.Open();
            llenarcategoria();
        }
        public void llenarcategoria()
        {
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Program.ConnSql;
            Comm.CommandText = "select idCategoria, nombreCat from Categoria Order by nombreCat";
            Comm.CommandType = CommandType.Text;
            SqlDataAdapter SqlAd = new SqlDataAdapter(Comm);
            DataTable tblCategoria = new DataTable();
            SqlAd.Fill(tblCategoria);

            categoria.ValueMember = "idCategoria";
            categoria.DisplayMember = "nombreCat";
            categoria.DataSource = tblCategoria;

        }

        private void agregar_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = Program.ConnSql;
            comm.CommandText = "insert into EMPLEADO(idUsuario, nombre, apellidoPat, apellidoMat, direccion, telefono, email, fechaNaciomiento, rfc, fechaIngreso, idCategoria, foto)"
                + "values(@idUsuario, @nombre, @apellidoPat, @apellidoMat, @direccion, @telefono, @email, @fechaNacimiento, @rfc, @fechaIngreso, @idCategoria, @foto)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add("@idUsuario", SqlDbType.VarChar, 50).Value = id.Text.ToString();
            comm.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre.Text.ToString();
            comm.Parameters.Add("@apellidoPat", SqlDbType.VarChar, 50).Value = apellidoPat.Text.ToString();
            comm.Parameters.Add("@apellidMat", SqlDbType.VarChar, 50).Value = apellidoMat.Text.ToString();
            comm.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = direccion.Text.ToString();
            comm.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = telefono.Text.ToString();
            comm.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email.Text.ToString();
            comm.Parameters.Add("@fechaNacimiento", SqlDbType.VarChar, 50).Value = fechaNac.Text.ToString();
            comm.Parameters.Add("@rfc", SqlDbType.VarChar, 50).Value = rfc.Text.ToString();
            comm.Parameters.Add("@fechaIngreso", SqlDbType.VarChar, 50).Value = fechaIng.Text.ToString();
            comm.Parameters.Add("@idCategoria", SqlDbType.VarChar, 50).Value = categoria.Text.ToString();
            comm.Parameters.Add("@foto", SqlDbType.VarChar, 50).Value = foto.Text.ToString();

        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Program.ConnSql;
            Comm.CommandText = "select EMPLEADO.*, ACCESO.login, ACCESSO.password From EMPLEADO inner join ACCESO"
                + "on EMPLEADO.idUsuario = ACCESSO.idUsuario Where EMPLEADO.idUsuario =@id";
            Comm.CommandType = CommandType.Text;
            Comm.Parameters.Add("@idUsuario ", SqlDbType.VarChar, 50).Value = id.Text.ToString();
            SqlDataReader DReader = Comm.ExecuteReader();
            if (DReader.HasRows)
            {
                while (DReader.Read())
                {
                    id.Text = DReader["Id_Usuario"].ToString();
                    categoria.SelectedValue = DReader["Id_Categoria"].ToString();
                    nombre.Text = DReader["Nombre"].ToString();
                    apellidoPat.Text = DReader["A_Paterno"].ToString();
                    apellidoMat.Text = DReader["A_Materno"].ToString();
                    direccion.Text = DReader["Direccion"].ToString();
                    telefono.Text = DReader["Telefono"].ToString();
                    email.Text = DReader["E-Mail"].ToString();
                    fechaNac.SelectedValue = DateTime.Parse(DReader["F_Nac"].ToString());
                    fechaIng.SelectedValue = DateTime.Parse(DReader["F_Ingreso"].ToString());
                    usuario.Text = DReader["Login"].ToString();
                    contraseña.Text = DReader["Password"].ToString();
                    if (DReader.IsDBNull(DReader.GetOrdinal("Foto")))
                    {
                        foto.Image = Image.FromFile(DReader["Foto"].ToString());
                    }
                    else
                    {
                        foto.Image = null;
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(10, 10, 400, 600));
            e.Graphics.DrawImage(foto.Image, 90, 30);

            Font Fuente = new Font("Arial", 14, FontStyle.Bold);

            e.Graphics.DrawString("Nombre: " + nombre.Text.Trim() + " " + apellidoPat.Text.Trim(), Fuente, Brushes.Black,
                new Point(50, 260));

            e.Graphics.DrawString("Categoria : " + categoria.Text, Fuente, Brushes.Black, new Point(58, 246));

            e.Graphics.DrawString("Empleado : ", Fuente, Brushes.Black, new Point(50, 460));

            Fuente = new Font("ABC C39 Medium Text", 16, FontStyle.Regular);
        }

        private void buscarFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString().Trim() != "")
            {
                varFoto = openFileDialog1.FileName.ToString();
                foto.Image = Image.FromFile(varFoto);
            }
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printPreviewDialog1.ShowDialog();
        }
    }
}