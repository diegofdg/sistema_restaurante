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
    public partial class Punto_de_venta : Form
    {
        public Punto_de_venta()
        {
            InitializeComponent();
        }

        int paginainicio = 1;
        int paginaMaxima = 9;
        private void Punto_de_venta_Load(object sender, EventArgs e)
        {
            dibujarGrupos();
        }
        public void dibujarGrupos()
        {
            Panel_grupos.Controls.Clear();
            try
            {
                Conexion.ConexionMaestra.abrir();
                string query = "PaginarGrupos";
                SqlCommand cmd = new SqlCommand(query, Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desde", paginainicio);
                cmd.Parameters.AddWithValue("@hasta", paginaMaxima);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    PictureBox I1 = new PictureBox();
                    b.Text = rdr["grupo"].ToString();
                    b.Name = rdr["id_line"].ToString();
                    b.Size = new System.Drawing.Size(119, 25);
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 11);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Fill;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(110, 75);
                    p1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    p1.BackColor = Color.Transparent;
                    p1.Name = rdr["id_line"].ToString();
                    p1.BackgroundImage = Properties.Resources.naranja;
                    p1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    I1.Size = new System.Drawing.Size(140, 50);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (byte[])rdr["icono"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Cursor = Cursors.Hand;
                    I1.Tag = rdr["id_line"].ToString();
                    I1.BackColor = Color.Transparent;

                    p1.Controls.Add(b);
                    if (rdr["estado_de_icono"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(I1);
                    }
                    b.BringToFront();
                    Panel_grupos.Controls.Add(p1);
                }
                Conexion.ConexionMaestra.Cerrar();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
