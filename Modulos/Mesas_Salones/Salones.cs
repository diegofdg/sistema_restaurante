using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaRestaurante.Modulos.Mesas_Salones
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
            InsertarSalon();
        }

        private void insertar_mesas_vacias()
        {
            for (int i = 1; i <= 80; i++)
            {
                try
                {
                    Conexion.ConexionMaestra.abrir();
                    SqlCommand cmd = new SqlCommand("InsertarMesa", Conexion.ConexionMaestra.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mesa", "NULO");
                    cmd.Parameters.AddWithValue("@id_salon", idsalon);
                    cmd.ExecuteNonQuery();
                    Conexion.ConexionMaestra.Cerrar();
                }
                catch (Exception ex)
                {
                    Conexion.ConexionMaestra.Cerrar();
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        private void mostrar_id_salon_recien_ingresado()
        {
            SqlCommand com = new SqlCommand("MostrarIdSalonRecienIngresado", Conexion.ConexionMaestra.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@salon", txtSalonedicion.Text);
            try
            {
                Conexion.ConexionMaestra.abrir();
                idsalon = Convert.ToInt32(com.ExecuteScalar());
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void InsertarSalon()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("InsertarSalon", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@salon", txtSalonedicion.Text);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.conectar.Close();
                mostrar_id_salon_recien_ingresado();
                insertar_mesas_vacias();
                Close();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
