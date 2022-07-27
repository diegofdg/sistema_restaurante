using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestCsharp.Datos
{
	public class Obtener
	{
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
	}
}
