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
	public class Editar
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
	}
}
