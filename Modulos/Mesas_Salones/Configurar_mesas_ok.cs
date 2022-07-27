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
    public partial class Configurar_mesas_ok : Form
    {
        int id_salon;
        string estado;
        public static string nombre_mesa;
        public static int idmesa;

        public Configurar_mesas_ok()
        {
            InitializeComponent();
        }

        private void Configurar_mesas_ok_Load(object sender, EventArgs e)
        {
            PanelBienvenida.Dock = DockStyle.Fill;
            dibujarSalones();
        }

        private void dibujarMESAS()
        {
            try
            {
                PanelMesas.Controls.Clear();
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("MostrarMesasPorSalon", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();
                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamanio_letra = Convert.ToInt32(rdr["tamanio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);

                    panel.BackgroundImage = Properties.Resources.mesa_vacia;
                    panel.BackgroundImageLayout = ImageLayout.Zoom;
                    panel.Cursor = Cursors.Hand;
                    panel.Tag = rdr["id_mesa"].ToString();
                    panel.Size = new System.Drawing.Size(tamanio);

                    b.Text = rdr["mesa"].ToString();
                    b.Name = rdr["id_mesa"].ToString();

                    if (b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.BackColor = Color.FromArgb(5, 179, 90);
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", tamanio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        PanelMesas.Controls.Add(b);
                    }
                    else
                    {
                        PanelMesas.Controls.Add(panel);
                    }
                    b.Click += new EventHandler(miEvento);
                    panel.Click += new EventHandler(miEventopanel_click);
                }
                Conexion.ConexionMaestra.Cerrar();

            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void miEvento(System.Object sender, EventArgs e)
        {
            nombre_mesa = ((Button)sender).Text;
            idmesa = Convert.ToInt32(((Button)sender).Name);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();
            frm.FormClosed += new FormClosedEventHandler(frm_Agregar_mesa_ok_FormClosed);
            frm.ShowDialog();
        }

        private void miEventopanel_click(System.Object sender, EventArgs e)
        {
            idmesa = Convert.ToInt32(((Panel)sender).Tag);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();
            frm.FormClosed += new FormClosedEventHandler(frm_Agregar_mesa_ok_FormClosed);
            frm.ShowDialog();
        }

        private void frm_Agregar_mesa_ok_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarMESAS();
        }

        private void dibujarSalones()
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                Conexion.ConexionMaestra.abrir();
                string query = "MostrarSalon";
                SqlCommand cmd = new SqlCommand(query, Conexion.ConexionMaestra.conectar);
                cmd.CommandType = (System.Data.CommandType)4;
                cmd.Parameters.AddWithValue("@buscar", txtsalon.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    Panel panelLATERAL = new Panel();

                    b.Text = rdr["salon"].ToString();
                    b.Name = rdr["id_salon"].ToString();
                    b.Tag = rdr["estado"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);

                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Tag = rdr["estado"].ToString();

                    panelC1.Size = new System.Drawing.Size(244, 58);
                    panelC1.Name = rdr["id_salon"].ToString();

                    panelLATERAL.Size = new System.Drawing.Size(3, 58);
                    panelLATERAL.Dock = DockStyle.Left;
                    panelLATERAL.BackColor = Color.Transparent;
                    panelLATERAL.Name = rdr["id_salon"].ToString();

                    string estado = rdr["estado"].ToString();
                    if (estado == "ELIMINADO")
                    {
                        b.Text = rdr["salon"].ToString() + " - Eliminado";
                        b.ForeColor = Color.FromArgb(231, 63, 67);
                    }
                    else
                    {
                        b.ForeColor = Color.White;
                    }
                    panelC1.Controls.Add(b);
                    panelC1.Controls.Add(panelLATERAL);
                    flowLayoutPanel1.Controls.Add(panelC1);

                    b.BringToFront();
                    panelLATERAL.SendToBack();

                    b.Click += new EventHandler(miEvento_salon_button);
                }
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void miEvento_salon_button(System.Object sender, EventArgs e)
        {
            PanelBienvenida.Visible = false;
            PanelBienvenida.Dock = DockStyle.None;
            PanelMesas.Visible = true;
            PanelMesas.Dock = DockStyle.Fill;
            id_salon = Convert.ToInt32(((Button)sender).Name);
            estado = Convert.ToString(((Button)sender).Tag);
            dibujarMESAS();
            foreach (System.Windows.Forms.Control panelC2 in flowLayoutPanel1.Controls)
            {
                if (panelC2 is Panel)
                {
                    foreach (System.Windows.Forms.Control panelLATERAL2 in panelC2.Controls)
                    {
                        if (panelLATERAL2 is Panel)
                        {
                            panelLATERAL2.BackColor = Color.Transparent;
                            panelC2.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }

            string NOMBRE = ((Button)sender).Name;
            foreach (System.Windows.Forms.Control panelC1 in flowLayoutPanel1.Controls)
            {
                if (panelC1 is Panel)
                {
                    foreach (System.Windows.Forms.Control panelLATERAL in panelC1.Controls)
                    {
                        if (panelLATERAL is Panel)
                        {
                            if (panelLATERAL.Name == NOMBRE)
                            {
                                panelLATERAL.BackColor = Color.OrangeRed;
                                panelC1.BackColor = Color.FromArgb(43, 43, 43);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Salones frm = new Salones();
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.ShowDialog();
        }

        void frm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarSalones();
        }

        private void Configurar_mesas_ok_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            aumentar_tamaño_mesa();
        }

        internal void aumentar_tamaño_mesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("AumentarTamanioMesa", Conexion.ConexionMaestra.conectar);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.Cerrar();
                dibujarMESAS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        internal void disminuir_tamanio_mesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("DisminuirTamanioMesa", Conexion.ConexionMaestra.conectar);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.Cerrar();
                dibujarMESAS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void aumentar_tamanio_letra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("AumentarTamanioLetra", Conexion.ConexionMaestra.conectar);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.Cerrar();
                dibujarMESAS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            disminuir_tamanio_mesa();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            aumentar_tamanio_letra();
        }

        internal void disminuir_tamanio_letra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.ConexionMaestra.abrir();
                cmd = new SqlCommand("DisminuirTamanioLetra", Conexion.ConexionMaestra.conectar);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.Cerrar();
                dibujarMESAS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            disminuir_tamanio_letra();
        }
    }
}
