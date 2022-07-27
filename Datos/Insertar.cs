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
	public class Insertar
	{
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
