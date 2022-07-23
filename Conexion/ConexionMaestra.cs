using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SistemaRestaurante.Conexion
{
    class ConexionMaestra
    {
        public static string conexion = Convert.ToString(Librerias.Desencryptacion.checkServer());
        public static SqlConnection conectar = new SqlConnection(conexion);

        internal void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        internal void Cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
