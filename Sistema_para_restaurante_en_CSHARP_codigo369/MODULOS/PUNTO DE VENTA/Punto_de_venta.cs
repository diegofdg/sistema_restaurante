using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Sistema_para_restaurante_en_CSHARP_codigo369.MODULOS.PUNTO_DE_VENTA
{

    public partial class Punto_de_venta : Form
    {
        public Punto_de_venta()
        {
            InitializeComponent();
        }
        int paginainicio=1;
        int paginaMaxima=10;
        public static int id_grupo;
        int cantidad_grupos;
        private Button PaginadorSiguiente = new Button();
        private Button PaginadorAtras = new Button();
        private void Punto_de_venta_Load(object sender, EventArgs e)
        {
            dibujarGrupos();
            contar_grupos();
        
        }
     
         void  contar_grupos()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("select count(Idline) from Grupo_de_Productos", CONEXION.CONEXIONMAESTRA.conectar);
                cantidad_grupos = Convert.ToInt32(com.ExecuteScalar());
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                cantidad_grupos = 0;
            }

        }
        public void dibujarGrupos()
        {
            Panel_grupos.Controls.Clear();
            try
            {
               CONEXION. CONEXIONMAESTRA.abrir();
                string query = "Paginar_grupos";
                SqlCommand cmd = new SqlCommand(query, CONEXION .CONEXIONMAESTRA.conectar );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Desde",paginainicio );
                cmd.Parameters.AddWithValue("@Hasta",paginaMaxima );
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    PictureBox I1 = new PictureBox();
                    b.Text = rdr["Grupo"].ToString();
                    b.Name = rdr["Idline"].ToString();
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
                    p1.Name = rdr["Idline"].ToString();
                    p1.BackgroundImage = Properties.Resources.naranja;
                    p1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    I1.Size = new System.Drawing.Size(140, 50);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (byte[])rdr["Icono"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Cursor = Cursors.Hand;
                    I1.Tag = rdr["Idline"].ToString();
                    I1.BackColor = Color.Transparent;

                    p1.Controls.Add(b);
                    if (rdr["Estado_de_icono"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(I1);
                    }
                    b.BringToFront();
                    Panel_grupos.Controls.Add(p1);
                    b.Click += new EventHandler (mieventoLabel);
                    I1.Click += new EventHandler(miEventoImagen);
                }
                CONEXION.CONEXIONMAESTRA.Cerrar();

            }
            catch (Exception ex)
            {

            }
        }

        private void miEventoImagen(object sender, EventArgs e)
        {
             try
            {
                id_grupo = Convert.ToInt32(((PictureBox)sender).Tag);
                Seleccionar_Deseleccionar_grupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void mieventoLabel(object sender, EventArgs e)
        {
           try
            {
                id_grupo = Convert.ToInt32(((Label)sender).Name);
                Seleccionar_Deseleccionar_grupos();

                PanelProductos.Controls.Clear();
                PUNTO_DE_VENTA.MostradorProductos  frm = new PUNTO_DE_VENTA.MostradorProductos();
                frm.Dock = DockStyle.Fill;
                PanelProductos.Controls.Add(frm);
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Seleccionar_Deseleccionar_grupos()
        {
            try
            {
                foreach (System.Windows.Forms.Control panelP1 in Panel_grupos.Controls )
                {
                    if (panelP1 is System.Windows.Forms.Panel )
                    {
                        foreach (var PanelSecundario in panelP1.Controls)
                        {
                            panelP1.BackColor = Color.Transparent;
                            panelP1.BackgroundImage = Properties.Resources.naranja;
                            panelP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            break;
                          
                        }
                    }
                }

                foreach (System.Windows.Forms.Control PanelP2 in Panel_grupos.Controls)
                {
                    if (PanelP2 is System.Windows.Forms.Panel)
                    {
                        if (PanelP2.Name ==id_grupo.ToString () )
                        {
                        PanelP2.BackColor = Color.Transparent;
                        PanelP2.BackgroundImage = Properties.Resources.azul;
                        PanelP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                        }
                       
                    }
                }


            }
            catch (Exception)
            {

                
            }
        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void btnGrupoadelante_Click(object sender, EventArgs e)
        {
            contar_grupos();
            if (cantidad_grupos>paginaMaxima )
            {
                
                paginainicio += 10;
                paginaMaxima += 10;
                dibujarGrupos();
            }
        }

        private void btngrupoAtras_Click(object sender, EventArgs e)
        {
            if (paginainicio >1)
            {
                
                paginainicio -= 10;
                paginaMaxima -= 10;
                dibujarGrupos();
            }
        }

        private void btnvermesas_Click(object sender, EventArgs e)
        {
            Dispose();
            MODULOS.PUNTO_DE_VENTA.Visor_de_mesas frm = new MODULOS.PUNTO_DE_VENTA.Visor_de_mesas();
            frm.ShowDialog();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            

        
        }
    }
}
