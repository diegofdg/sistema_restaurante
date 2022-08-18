using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RestCsharp.Logica;
using System.Windows.Forms;

namespace RestCsharp.Datos
{
   public class Dclientes
    {
        public bool insertar_clientes(Lclientes parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_cliente", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal", parametros.IdentificadorFiscal);
                cmd.Parameters.AddWithValue("@Celular", parametros.Celular);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.Parameters.AddWithValue("@Cedula", parametros.Cedula);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void mostrarClienteEstandar(ref int idcliente)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("mostrarClienteEstandar", CONEXIONMAESTRA.conectar);

                idcliente = Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception)
            {
                idcliente = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }

    }
}
