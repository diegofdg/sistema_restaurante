using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using RestCsharp.Logica;

namespace RestCsharp.Datos
{
   public class Dempresa
    {
        public bool editarRespaldos()
        {
            try
            {

                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarRespaldos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_date", DateTime.Now);
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
        public void GenerarCopiaBd(string Base_De_datos, string SubCarpeta)
        {
            try
            {
                string v_nombre_respaldo = Base_De_datos + ".bak";
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("BACKUP DATABASE " + Base_De_datos + " TO DISK = '" + SubCarpeta + @"\" + v_nombre_respaldo + "'", CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
              
            }
            catch (Exception)
            {


            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public bool Insertar_EMPRESA(Lempresa parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_EMPRESA", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.Nombre_Empresa);
                cmd.Parameters.AddWithValue("@Impuesto", parametros.Impuesto);
                cmd.Parameters.AddWithValue("@Porcentaje_impuesto", parametros.Porcentaje_impuesto);
                cmd.Parameters.AddWithValue("@Moneda", parametros.Moneda);
                cmd.Parameters.AddWithValue("@Trabajas_con_impuestos", parametros.Trabajas_con_impuestos);
                cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", parametros.Carpeta_para_copias_de_seguridad);
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_date", parametros.Ultima_fecha_de_copia_date);
                cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
                cmd.Parameters.AddWithValue("@Logo", parametros.Logo);
                cmd.Parameters.AddWithValue("@Tiponotas", parametros.Tiponotas);
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
        public void mostrarempresa(ref DataTable dt)
        {
            try
            {

                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select *, Impuesto + ' (' + convert(varchar(50),Porcentaje_impuesto) +'%):' as Impuestounido from EMPRESA", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
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
        public bool editarEmpresa(Lempresa parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarEmpresa", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.Nombre_Empresa);
                cmd.Parameters.AddWithValue("@Impuesto", parametros.Impuesto);
                cmd.Parameters.AddWithValue("@Porcentaje_impuesto", parametros.Porcentaje_impuesto);
                cmd.Parameters.AddWithValue("@Moneda", parametros.Moneda);
                cmd.Parameters.AddWithValue("@Trabajas_con_impuestos", parametros.Trabajas_con_impuestos);
                cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", parametros.Carpeta_para_copias_de_seguridad);
                cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
                cmd.Parameters.AddWithValue("@Logo", parametros.Logo);
                cmd.Parameters.AddWithValue("@Tiponotas", parametros.Tiponotas);

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
    }
}
