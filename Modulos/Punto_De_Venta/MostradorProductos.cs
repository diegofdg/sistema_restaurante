using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaRestaurante.Modulos.Punto_De_Venta
{
    public partial class MostradorProductos : UserControl
    {
        public MostradorProductos()
        {
            InitializeComponent();
        }

        int paginainicio = 1;
        int paginaMaxima = 15;
        int cantidad_productos = 0;

        private void MostradorProductos_Load(object sender, EventArgs e)
        {
            dibujarProductos();
            contar_productos();
        }

        public void contar_productos()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand com = new SqlCommand("SELECT COUNT(id_producto) FROM producto", Conexion.ConexionMaestra.conectar);
                cantidad_productos = Convert.ToInt32(com.ExecuteScalar());
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                cantidad_productos = 0;
            }
        }

        public void dibujarProductos()
        {
            try
            {
                PanelProductos.Controls.Clear();
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("PaginarProductosPorGrupo", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_grupo", Punto_de_venta.id_grupo);
                cmd.Parameters.AddWithValue("@desde", paginainicio);
                cmd.Parameters.AddWithValue("@hasta", paginaMaxima);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    PictureBox I1 = new PictureBox();
                    b.Text = rdr["descripcion"].ToString();
                    b.Name = rdr["id_producto"].ToString();
                    b.Tag = rdr["precio_de_venta"].ToString();
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular | FontStyle.Bold);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Fill;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(147, 75);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.Transparent;
                    p1.BackgroundImage = Properties.Resources.azul;
                    p1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    I1.Dock = DockStyle.Top;
                    byte[] bi = (byte[])rdr["imagen"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Cursor = Cursors.Hand;
                    I1.Tag = rdr["precio_de_venta"].ToString();
                    I1.Name = rdr["id_producto"].ToString();
                    I1.BackColor = Color.Transparent;
                    p1.Controls.Add(b);
                    if (rdr["estado_imagen"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(I1);
                    }
                    b.BringToFront();
                    PanelProductos.Controls.Add(p1);
                }
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            if (paginainicio > 1)
            {
                paginainicio -= 15;
                paginaMaxima -= 15;
                dibujarProductos();
            }
        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
            contar_productos();
            if (cantidad_productos > paginaMaxima)
            {
                paginainicio += 15;
                paginaMaxima += 15;
                dibujarProductos();
            }
        }
    }
}
