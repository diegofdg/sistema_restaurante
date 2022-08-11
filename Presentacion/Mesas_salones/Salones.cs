using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RestCsharp.Datos;
namespace RestCsharp.Presentacion.Mesas_salones
{
    public partial class Salones : Form
    {
        int idsalon;
        public Salones()
        {
            InitializeComponent();
        }

        private void Salones_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            txtSalonedicion.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertar_salon();
        }
        private void insertar_mesas_vacias()
        {
            for (int i=1;i<=80; i++)
            {
                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertar_mesa", CONEXIONMAESTRA.conectar );
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mesa", "NULO");
                    cmd.Parameters.AddWithValue("@idsalon", idsalon);
                    cmd.ExecuteNonQuery();
                    CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    CONEXIONMAESTRA.cerrar();
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        private void mostrar_id_salon_recien_ingresado()
        {
            SqlCommand com = new SqlCommand("mostrar_id_salon_recien_ingresado", CONEXIONMAESTRA.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Salon", txtSalonedicion.Text);
            try
            {
                CONEXIONMAESTRA.abrir();
                idsalon = Convert.ToInt32 (com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertar_salon()
        {
            try
            {
                CONEXIONMAESTRA.abrir ();
                SqlCommand cmd = new SqlCommand("insertar_Salon", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Salon", txtSalonedicion.Text);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar ();
                mostrar_id_salon_recien_ingresado();
                insertar_mesas_vacias();
                Close();
            }
            catch (Exception ex)
            {

                CONEXIONMAESTRA.conectar.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
