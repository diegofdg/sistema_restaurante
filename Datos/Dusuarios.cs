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
	public class Dusuarios
	{
		public bool editar_Usuarios(Lusuarios parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("editar_Usuarios", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
				cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
				cmd.Parameters.AddWithValue("@Login", parametros.Login);
				cmd.Parameters.AddWithValue("@Password", parametros.Password);
				cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
				cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
				cmd.Parameters.AddWithValue("@Rol", parametros.Rol);

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
				CONEXIONMAESTRA.Cerrar();
			}

		}
		public bool eliminar_Usuarios(Lusuarios parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("eliminar_Usuarios", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);

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
				CONEXIONMAESTRA.Cerrar();
			}

		}
		public void mostrar_Usuarios(ref DataTable dt)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlDataAdapter da = new SqlDataAdapter("mostrar_Usuarios", CONEXIONMAESTRA.conectar);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace);
			}
			finally
			{
				CONEXIONMAESTRA.Cerrar();
			}
		}
		public void buscar_usuarios(ref DataTable dt, string buscador)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlDataAdapter da = new SqlDataAdapter("buscar_usuarios", CONEXIONMAESTRA.conectar);
				da.SelectCommand.CommandType = CommandType.StoredProcedure;
				da.SelectCommand.Parameters.AddWithValue("@buscador", buscador);
				da.Fill(dt);
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.StackTrace);
			}
			finally
			{
				CONEXIONMAESTRA.Cerrar();
			}
		}
		public bool InsertarUsuarios(Lusuarios parametros)
		{
			try
			{
				CONEXIONMAESTRA.abrir();
				SqlCommand cmd = new SqlCommand("insertar_Usuarios", CONEXIONMAESTRA.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
				cmd.Parameters.AddWithValue("@Login", parametros.Login);
				cmd.Parameters.AddWithValue("@Password", parametros.Password);
				cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
				cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
				cmd.Parameters.AddWithValue("@Rol", parametros.Rol);
				cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
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
				CONEXIONMAESTRA.Cerrar();
			}

		}
	}
}
