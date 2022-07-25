﻿using System;
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
    public partial class Productos_rest : Form
    {
        public Productos_rest()
        {
            InitializeComponent();
        }
        private void Productos_rest_Load(object sender, EventArgs e)
        {
            dibujarGrupos();
        }
        private void dibujarGrupos()
        {
            try
            {
                Panel_grupos.Controls.Clear();
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("SELECT * FROM grupo_de_productos", Conexion.ConexionMaestra.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox I1 = new PictureBox();

                    b.Text = rdr["grupo"].ToString();
                    b.Name = rdr["id_line"].ToString();
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
                    p1.Name = rdr["id_line"].ToString();

                    p2.Size = new System.Drawing.Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent;
                    p2.BorderStyle = BorderStyle.None;

                    I1.Size = new System.Drawing.Size(140, 76);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    //byte[] bi = (Byte[])rdr["icono"];
                    //MemoryStream ms = new MemoryStream(bi);
                    //I1.Image = Image.FromStream(ms);
                    //I1.SizeMode = PictureBoxSizeMode.Zoom;
                    //I1.Cursor = Cursors.Hand;
                    I1.Tag = rdr["id_line"].ToString();

                    MenuStrip Menustrip = new MenuStrip();
                    Menustrip.BackColor = Color.Transparent;
                    Menustrip.AutoSize = false;
                    Menustrip.Size = new System.Drawing.Size(28, 24);
                    Menustrip.Dock = DockStyle.Right;
                    Menustrip.Name = rdr["id_line"].ToString();
                    ToolStripMenuItem ToolStripPRINCIPAL = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripEDITAR = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripELIMINAR = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripRESTAURAR = new ToolStripMenuItem();

                    ToolStripPRINCIPAL.Image = Properties.Resources.menuCajas_claro;
                    ToolStripPRINCIPAL.BackColor = Color.Transparent;

                    ToolStripEDITAR.Text = "Editar";
                    ToolStripEDITAR.Name = rdr["grupo"].ToString();
                    ToolStripEDITAR.Tag = rdr["id_line"].ToString();

                    ToolStripELIMINAR.Text = "Eliminar";
                    ToolStripELIMINAR.Tag = rdr["id_line"].ToString();

                    ToolStripRESTAURAR.Text = "Restaurar";
                    ToolStripRESTAURAR.Tag = rdr["id_line"].ToString();

                    Menustrip.Items.Add(ToolStripPRINCIPAL);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripEDITAR);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripELIMINAR);
                    ToolStripPRINCIPAL.DropDownItems.Add(ToolStripRESTAURAR);

                    p2.Controls.Add(Menustrip);

                    if (rdr["estado_de_icono"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(I1);
                    }
                    else
                    {
                        p1.Controls.Add(b);
                    }

                    p1.Controls.Add(p2);
                    b.BringToFront();
                    p2.SendToBack();
                    Panel_grupos.Controls.Add(p1);

                }
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
