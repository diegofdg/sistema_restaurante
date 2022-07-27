using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using RestCsharp.Datos;
namespace RestCsharp.MODULOS.PRODUCTOS
{
    public partial class Productos_rest : Form
    {
        public Productos_rest()
        {
            InitializeComponent();
        }
        public static int id_grupo;

        private void Productos_rest_Load(object sender, EventArgs e)
        {
            dibujarGrupos();
        }
        private void dibujarGrupos()
        {
            try
            {
                Panel_grupos.Controls.Clear();
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("select * from Grupo_de_Productos", CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read ())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox I1 = new PictureBox();

                    b.Text = rdr["Grupo"].ToString();
                    b.Name = rdr["Idline"].ToString();
                    b.Size = new System.Drawing.Size(119, 25);
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Fill;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(140, 133);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Bottom;
                    p1.BackColor = Color.FromArgb(43, 43, 43);
                    p1.Name = rdr["Idline"].ToString();

                    p2.Size = new System.Drawing.Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent;
                    p2.BorderStyle = BorderStyle.None;

                    I1.Size = new System.Drawing.Size(140, 76);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Icono"];
                    MemoryStream ms = new MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Cursor = Cursors.Hand;
                    I1.Tag = rdr["Idline"].ToString();

                    MenuStrip Menustrip = new MenuStrip();
                    Menustrip.BackColor = Color.Transparent;
                    Menustrip.AutoSize = false;
                    Menustrip.Size = new System.Drawing.Size(28, 24);
                    Menustrip.Dock = DockStyle.Right;
                    Menustrip.Name= rdr["Idline"].ToString();
                    ToolStripMenuItem ToolStripPRINCIPAL = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripEDITAR = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripELIMINAR = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripRESTAURAR = new ToolStripMenuItem();

                    ToolStripPRINCIPAL.Image = Properties.Resources.menuCajas_claro;
                    ToolStripPRINCIPAL.BackColor = Color.Transparent;

                    ToolStripEDITAR.Text = "Editar";
                    ToolStripEDITAR.Name = rdr["Grupo"].ToString();
                    ToolStripEDITAR.Tag = rdr["Idline"].ToString();

                    ToolStripELIMINAR.Text = "Eliminar";
                    ToolStripELIMINAR.Tag = rdr["Idline"].ToString();

                    ToolStripRESTAURAR.Text = "Restaurar";
                    ToolStripRESTAURAR.Tag = rdr["Idline"].ToString();

                    Menustrip.Items.Add(ToolStripPRINCIPAL);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripEDITAR);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripELIMINAR);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripRESTAURAR);

                    p2.Controls.Add(Menustrip);
                    p1.Controls.Add(b);
                    if (rdr["Estado_de_icono"].ToString ()!="VACIO")
                    {
                        p1.Controls.Add(I1);
                    }
                   

                    p1.Controls.Add(p2);
                    b.BringToFront();
                    p2.SendToBack();
                    Panel_grupos.Controls.Add(p1);
                    b.Click += new EventHandler(miEventoLabel);
                    I1.Click += new EventHandler(miEventoImagen);
                }
                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void miEventoLabel(System.Object sender, EventArgs e)
        {
            id_grupo = Convert.ToInt32(((Label)sender).Name);
            ver_productos_por_grupo();
            Seleccionar_Deseleccionar_grupos();
        }
        private void miEventoImagen(System.Object sender, EventArgs e)
        {
            id_grupo = Convert.ToInt32(((PictureBox )sender).Tag);
            ver_productos_por_grupo();
            Seleccionar_Deseleccionar_grupos();
        }
        private void Seleccionar_Deseleccionar_grupos()
        {


            //Sin seleccionar
            foreach (Panel panelP1 in Panel_grupos .Controls )
            {
                if (panelP1 is Panel )
                {
                   foreach (Label PanLateral2 in panelP1.Controls )
                    {
                         if(PanLateral2 is Label )
                        {
                            panelP1.BackColor = Color.FromArgb(43, 43, 43);
                            break;
                        }
                    }
                }
            }

            //Seleccionado
            foreach (Panel PanelP2 in Panel_grupos.Controls )
            {
                if (PanelP2 is Panel )
                {
                    if (PanelP2.Name ==Convert.ToString (  id_grupo) )
                    {
                        PanelP2.BackColor = Color.Black;
                    }
                }
            }
        }
        private void ver_productos_por_grupo()
        {
            PanelBienvienida.Visible = false;
            Panel7.Visible = true;
            Panel7.Dock = DockStyle.Fill;
            dibujarProductos();

        }

        private void dibujarProductos()
        {
            try
            {
                PanelProductos.Controls.Clear();
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_Productos_por_grupo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox I1 = new PictureBox();
                    b.Text = rdr["Descripcion"].ToString();
                    b.Name = rdr["Id_Producto1"].ToString();
                    b.Size = new System.Drawing.Size(119, 25);
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Fill;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(140, 133);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Bottom;
                    p1.BackColor = Color.FromArgb(43, 43, 43);

                    p2.Size = new System.Drawing.Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent;
                    p2.BorderStyle = BorderStyle.None;

                    I1.Size = new System.Drawing.Size(140, 76);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Imagen"];
                    MemoryStream ms = new MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Cursor = Cursors.Hand;
                    I1.Tag = rdr["Id_Producto1"].ToString();

                    MenuStrip Menustrip = new MenuStrip();
                    Menustrip.BackColor = Color.Transparent;
                    Menustrip.AutoSize = false;
                    Menustrip.Size = new System.Drawing.Size(28, 24);
                    Menustrip.Dock = DockStyle.Right;
                    Menustrip.Name = rdr["Id_Producto1"].ToString();
                    ToolStripMenuItem ToolStripPRINCIPAL = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripEDITAR = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripELIMINAR = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripRESTAURAR = new ToolStripMenuItem();
                    ToolStripPRINCIPAL.Image = Properties.Resources.menuCajas_claro;
                    ToolStripPRINCIPAL.BackColor = Color.Transparent;
                    ToolStripEDITAR.Text = "Editar";
                    ToolStripEDITAR.Name = rdr["Descripcion"].ToString();
                    ToolStripEDITAR.Tag = rdr["Id_Producto1"].ToString();

                    ToolStripELIMINAR.Text = "Eliminar";
                    ToolStripELIMINAR.Tag = rdr["Id_Producto1"].ToString();

                    ToolStripRESTAURAR.Text = "Restaurar";
                    ToolStripRESTAURAR.Tag = rdr["Id_Producto1"].ToString();
                    Menustrip.Items.Add(ToolStripPRINCIPAL);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripEDITAR);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripELIMINAR);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripRESTAURAR);
                    p2.Controls.Add(Menustrip);
                     p1.Controls.Add(b);
                    if (rdr["Estado_imagen"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(I1);
                    }
                  
                       
                    

                    p1.Controls.Add(p2);
                    b.BringToFront();
                    p2.SendToBack();
                    PanelProductos.Controls.Add(p1);
                }

                CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MODULOS.PRODUCTOS.Grupos_De_productos frm = new MODULOS.PRODUCTOS.Grupos_De_productos();
            frm.FormClosed += new FormClosedEventHandler(frmGrupos_FormClosed);
            frm.ShowDialog();
        }
        public void frmGrupos_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarGrupos();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MODULOS.PRODUCTOS.Registro_de_productos frm = new MODULOS.PRODUCTOS.Registro_de_productos();
            frm.FormClosed += new FormClosedEventHandler(frmRegistroProducto_FormClosed);
            frm.ShowDialog();
        }
        public void frmRegistroProducto_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarProductos ();
        }
    }

}
