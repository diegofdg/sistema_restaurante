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
    public class Dpermisos
    {
        public bool Insertar_Permisos(Lpermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Permisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdModulo", parametros.IdModulo);
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
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
                CONEXIONMAESTRA.Cerrar();
            }
        }
        public bool Editar_Permisos(Lpermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Permisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPermiso", parametros.IdPermiso);
                cmd.Parameters.AddWithValue("@IdModulo", parametros.IdModulo);
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
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
                CONEXIONMAESTRA.Cerrar();
            }
        }
        public bool Eliminar_Permisos(Lpermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Permisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPermiso", parametros.IdPermiso);
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
                CONEXIONMAESTRA.Cerrar();
            }
        }
        public void mostrar_Permisos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_Permisos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);

                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
