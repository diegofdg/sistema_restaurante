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

        private void InsertarSalon()
        {
            try
            {
                Conexion.ConexionMaestra.conectar.Open();
                SqlCommand cmd = new SqlCommand("InsertarSalon", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@salon", txtSalonedicion.Text);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.conectar.Close();
                Close();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.conectar.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
