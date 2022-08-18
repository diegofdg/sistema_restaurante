using RestCsharp.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestCsharp.Datos
{
    public class Dventas
    {
        public bool Insertar_ventas(Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_ventas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha_venta", parametros.fecha_venta);
                cmd.Parameters.AddWithValue("@Id_usuario", parametros.Id_usuario);
                cmd.Parameters.AddWithValue("@ACCION", parametros.ACCION);
                cmd.Parameters.AddWithValue("@Id_caja", parametros.Id_caja);
                cmd.Parameters.AddWithValue("@Id_mesa", parametros.Id_mesa);
                cmd.Parameters.AddWithValue("@Numero_personas", parametros.Numero_personas);
                cmd.Parameters.AddWithValue("@Donde_se_consumira", parametros.Donde_se_consumira);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
