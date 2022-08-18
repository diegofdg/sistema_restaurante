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
   public  class Dventas
    {
        int IdUsuario;
        int Idcaja;
        int Idmovcaja;
        private void mostrarInicioSesion()
        {
            DiniciosSesion funcion = new DiniciosSesion();
            var dt = new DataTable();
            funcion.mostrarInicioSesionTable(ref dt);
            IdUsuario = Convert.ToInt32(dt.Rows[0][2]);
        }
        private void mostrarCajaSerial()
        {
            Dcaja funcion = new Dcaja();
            funcion.mostrarCajaSerial(ref Idcaja);
        }
        private void mostrarMovCaja()
        {
            var funcion = new DmovimientoCaja();
            var dt = new DataTable();
            funcion.MostrarMovimientosCaja(ref dt);
            Idmovcaja =Convert.ToInt32( dt.Rows[0][0]);
        }
        public  void MostrarCantPersonas(ref int numeroPersonas, Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("MostrarCantidadPersonas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idventa", parametros.idventa);
                numeroPersonas =Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                numeroPersonas = 0;
                MessageBox.Show(ex.StackTrace);        
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool Insertar_ventas(Lventas parametros)
        {
            try
            {
                mostrarMovCaja();
                mostrarInicioSesion();
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_ventas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;          
                cmd.Parameters.AddWithValue("@fecha_venta", DateTime.Now);            
                cmd.Parameters.AddWithValue("@Id_usuario",IdUsuario);        
                cmd.Parameters.AddWithValue("@Idmovcaja", Idmovcaja);              
                cmd.Parameters.AddWithValue("@Id_mesa", parametros.Id_mesa);
                cmd.Parameters.AddWithValue("@Numero_personas", parametros.Numero_personas);
                cmd.Parameters.AddWithValue("@Nombrellevar", parametros.NombreLlevar );

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
        public void mostrarIdventaMesa(ref int Idventa, Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrarIdventaMesa", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Id_mesa", parametros.Id_mesa);
                Idventa = Convert.ToInt32(da.ExecuteScalar());

            }
            catch (Exception)
            {

                Idventa = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void mostrarIdventasMesa(ref DataTable dt, Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarIdventasMesa", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_mesa", parametros.Id_mesa);
                da.Fill(dt);

            }
            catch (Exception)
            {

            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool EditarEstadoVentasEspera(Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("EditarEstadoVentasEspera", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", parametros.idventa);
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
        public bool eliminarVentaIncompleta()
        {
            try
            {
                mostrarMovCaja();
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarVentaIncompleta", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idmovcaja", Idmovcaja);
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
        public bool Confirmar_venta(Lventas parametros)
        {
            try
            {
                mostrarMovCaja();
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Confirmar_venta", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", parametros.idventa);
                cmd.Parameters.AddWithValue("@fecha_venta", parametros.fecha_venta);
                cmd.Parameters.AddWithValue("@montototal", parametros.Monto_total);
                cmd.Parameters.AddWithValue("@Tipo_de_pago", parametros.Tipo_de_pago);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                cmd.Parameters.AddWithValue("@IGV", parametros.IGV);
                cmd.Parameters.AddWithValue("@Comprobante", parametros.Comprobante);
                cmd.Parameters.AddWithValue("@Fecha_de_pago", parametros.Fecha_de_pago);
                cmd.Parameters.AddWithValue("@Pago_con", parametros.Pago_con);
                cmd.Parameters.AddWithValue("@Referencia_tarjeta", parametros.Referencia_tarjeta);
                cmd.Parameters.AddWithValue("@Vuelto", parametros.Vuelto);
                cmd.Parameters.AddWithValue("@Efectivo", parametros.Efectivo);
                cmd.Parameters.AddWithValue("@Credito", parametros.Credito);
                cmd.Parameters.AddWithValue("@Tarjeta", parametros.Tarjeta);
                cmd.Parameters.AddWithValue("@PorcentajeImp", parametros.Porcentaje_IGV);
                cmd.Parameters.AddWithValue("@Idcliente", parametros.idclientev);
                cmd.Parameters.AddWithValue("@Idmovicaja", Idmovcaja);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void mostrarVentasNoTerminado(ref DataTable dt,Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarVentasNoTerminado", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idmesa", parametros.Id_mesa);
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
        public void mostrarVentasId(ref DataTable dt, Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarVentasId", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Idventa", parametros.idventa);
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
       private void mostrarIdmovcaja()
        {
            var funcion = new DmovimientoCaja();
            var dt = new DataTable();
            funcion.MostrarMovimientosCaja(ref dt);
            Idmovcaja =Convert.ToInt32( dt.Rows[0][0]);

        }
        public void RptVentasTurno(ref DataTable dt)
        {
            try
            {
                mostrarIdmovcaja();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("RptVentasTurno", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Idmovcaja", Idmovcaja);
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
        public bool eliminarVenta(Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarVenta", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idventa", parametros.idventa);     
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
        public bool editarNotas(Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarNotas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idventa", parametros.idventa);
                cmd.Parameters.AddWithValue("@Notas", parametros.Nota);

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
        public void mostrarNotasVentas(ref string nota, Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrarNotasVentas", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Idventa", parametros.idventa);
                nota = (da.ExecuteScalar()).ToString();

            }
            catch (Exception)
            {

                nota = "";
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void mostrarNotasVentasDt(ref DataTable dt, Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarNotasVentas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Idventa", parametros.idventa);
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
        public void RptComprobVenta(ref DataTable dt,Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("RptComprobVenta", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Idventa", parametros.idventa);
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
        public void RptPrecuenta(ref DataTable dt, Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("RptPrecuenta", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Idventa", parametros.idventa);
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
        public bool EditarDvCambioMesa(int IdmesaOrigen, int IdmesaDestino)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("EditarDvCambioMesa", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_mesa_destino", IdmesaDestino);
                cmd.Parameters.AddWithValue("@id_mesa_origen", IdmesaOrigen);

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
        public bool editaMesaenVentas(Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editaMesaenVentas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_mesa", parametros.Id_mesa);
                cmd.Parameters.AddWithValue("@Idventa", parametros.idventa);

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
        public void contarVentas(ref int cant, int idmesa)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("contarVentasMesa", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Idmesa", idmesa);
                cant = Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception)
            {
                cant = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public void mostrarMinPedido( Lventas parametros, int min)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrarMinPedido", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idventa", parametros.idventa);
                min = Convert.ToInt32(da.ExecuteScalar());

            }
            catch (Exception)
            {


            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void mostrarVentas(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("enumerarVentascocina", CONEXIONMAESTRA.conectar);
                da.Fill(dt);

            }
            catch (Exception)
            {


            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void MostrarVentasnuevas(ref int cant)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("MostrarVentasnuevas", CONEXIONMAESTRA.conectar);

                cant = Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception)
            {
                cant = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public void mostrarultimaventa(ref DataTable dt)
        {
            try
            {
                mostrarIdmovcaja();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter com = new SqlDataAdapter("mostrarultimaventa", CONEXIONMAESTRA.conectar);
                com.SelectCommand.CommandType = CommandType.StoredProcedure;
                com.SelectCommand.Parameters.AddWithValue("@idmovicaja", Idmovcaja);
                com.Fill(dt);
            }
            catch (Exception)
            {
             
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public void RptresumenventasHoy(ref DataTable dt)
        {
            try
            {
                mostrarIdmovcaja();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("RptresumenventasHoy", CONEXIONMAESTRA.conectar);
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
        public void RptresumenventasHoyUsuario(ref DataTable dt, Lventas parametros )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("RptresumenventasHoyUsuario", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Idusuario", parametros.Id_usuario);
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

        public void RptresumenventasFechas(ref DataTable dt, DateTime fi,DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("RptresumenventasFechas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);
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
        public void RptresumenventasFechasUsuarios(ref DataTable dt, DateTime fi, DateTime ff,Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("RptresumenventasFechasUsuarios", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);
                da.SelectCommand.Parameters.AddWithValue ("@Idusuario", parametros.Id_usuario);

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
        public void MostrarsolicitudImpr(ref int idventa)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrarSolicitudesImpr", CONEXIONMAESTRA.conectar);
                idventa = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                idventa = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public bool eliminarSolicitudImpr(Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarSolicitud", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("@idventa", parametros.idventa);
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
        public bool Insertarsolicitud(Lventas parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("InsertarSolicitud", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idventa", 0);
                cmd.Parameters.AddWithValue("@Tipo", parametros.Tiposolicitud);

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
        public bool eliminarSolicitudEsc()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarSolicitudEsc", CONEXIONMAESTRA.conectar);
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
        public void mostrarSolicitudesEsc(ref int idventa)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("mostrarSolicitudesEsc", CONEXIONMAESTRA.conectar);

                idventa = Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception)
            {
                idventa = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
    }
}
