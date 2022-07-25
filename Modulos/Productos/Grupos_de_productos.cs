using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaRestaurante.Modulos.Productos
{
    public partial class Grupos_de_productos : Form
    {
        public Grupos_de_productos()
        {
            InitializeComponent();
        }

        string ESTADO_IMAGEN;

        private void PanelEDICION_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Grupos_De_productos_Load(object sender, EventArgs e)
        {
            ESTADO_IMAGEN = "VACIO";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Insertar_Grupo_de_Productos();
            Dispose();
        }

        private void Insertar_Grupo_de_Productos()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("InsertarGrupoDeProductos", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@grupo", txtgrupo.Text);
                cmd.Parameters.AddWithValue("@por_defecto", "NO");
                cmd.Parameters.AddWithValue("@estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@estado_de_icono", ESTADO_IMAGEN);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenGrupo.Image.Save(ms, ImagenGrupo.Image.RawFormat);
                cmd.Parameters.AddWithValue("@icono", ms.GetBuffer());

                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenGrupo.BackgroundImage = null;
                ImagenGrupo.Image = new Bitmap(dlg.FileName);
                Panel1.Visible = false;
                ESTADO_IMAGEN = "LLENO";
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }
    }
}
