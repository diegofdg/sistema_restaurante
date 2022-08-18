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
    public class Dcaja
    {
        string SerialPc;
        public void mostrarCajaSerial(ref int idcaja)
        {
            try
            {
                Bases.Obtener_serialPC(ref SerialPc);
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrarCajaSerial", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Serial", SerialPc);
                idcaja = Convert.ToInt32(da.ExecuteScalar());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

    }
}
