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
        public empleado()
        {
            InitializeComponent();
        }

        private void empleado_Load(object sender, EventArgs e)
        {
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
    }
}