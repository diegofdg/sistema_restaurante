using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Sistema_para_restaurante_en_CSHARP_codigo369.MODULOS.PRODUCTOS
{
    public partial class Registro_de_productos : Form
    {
        public Registro_de_productos()
        {
            InitializeComponent();
        }
        string ESTADO_IMAGEN;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtdescripcion.Text !="")
            {
                if (txtprecioventa.Text !="")
                {
                Insertar_Producto1();
                }

            }
           
        }
        private void Insertar_Producto1()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Producto", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@Id_grupo", Productos_rest.id_grupo );         
                cmd.Parameters.AddWithValue("@Precio_de_venta", txtprecioventa .Text);            
                cmd.Parameters.AddWithValue("@Estado_imagen",ESTADO_IMAGEN );
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenProducto.Image.Save(ms, ImagenProducto.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Imagen", ms.GetBuffer());
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.Cerrar();
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Registro_de_productos_Load(object sender, EventArgs e)
        {
            ESTADO_IMAGEN = "VACIO";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }
        private void agregar_imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenProducto .BackgroundImage = null;
                ImagenProducto.Image = new Bitmap(dlg.FileName);
                panel2.Visible = false;
                ESTADO_IMAGEN = "LLENO";
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }
    }
}
