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
namespace RestCsharp.Presentacion.PRODUCTOS
{
    public partial class Grupos_De_productos : Form
    {
        public Grupos_De_productos()
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
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Grupo_de_Productos",CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", txtgrupo .Text);
                cmd.Parameters.AddWithValue("@Por_defecto","NO");
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Estado_de_icono", ESTADO_IMAGEN);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenGrupo.Image.Save(ms, ImagenGrupo.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());

                cmd.ExecuteNonQuery();
               CONEXIONMAESTRA.cerrar();
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

        private void ImagenGrupo_Click(object sender, EventArgs e)
        {

        }
    }
}
