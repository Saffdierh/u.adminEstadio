using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace adminEstadio
{
    static class Program
    {

        public static SqlConnection ConnSql;
        public static EmpleadoStructure emConfig;
        public struct EmpleadoStructure
        {
            public string userId, nombre, apaterno, amaterno, nomCategoria;
        }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainWindow());
        }
    }
}
