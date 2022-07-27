using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Sistema_para_restaurante_en_CSHARP_codigo369.MODULOS.Mesas_salones
{
    public partial class Agregar_mesa_ok : Form
    {
        public Agregar_mesa_ok()
        {
            InitializeComponent();
        }

        private void Agregar_mesa_ok_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            txtmesaedicion.Text = Configurar_mesas_ok.nombre_mesa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmesaedicion.Text != "")
            {
                editar_mesa();
            }
        }
        private void editar_mesa()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editar_mesa", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mesa", txtmesaedicion.Text);
                cmd.Parameters.AddWithValue("@id_mesa", Configurar_mesas_ok.idmesa);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.Cerrar();
                Close();
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
