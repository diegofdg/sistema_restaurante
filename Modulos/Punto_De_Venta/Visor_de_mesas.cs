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
    public partial class Visor_de_mesas : Form
    {
        public Visor_de_mesas()
        {
            InitializeComponent();
        }

        int id_salon;
        string estado;
        string Union_de_mesas;
        int Paso = 0;
        int idmesa_Origen;
        int idmesa_Destino;
        int idmesa;
        string nombre_mesa;
        string estado_de_mesa;
        int id_venta_mesa_origen;
        int id_venta_mesa_destino;
        int Estado_de_herramientas = 0;

        private void Visor_de_mesas_Load(object sender, EventArgs e)
        {
            dibujarSalones();
            Union_de_mesas = "INACTIVO";
            PanelBienvienida.Visible = true;
            PanelBienvienida.Dock = DockStyle.Fill;
            PanelMesas.Visible = false;
            PanelMesas.Dock = DockStyle.None;
        }
        void dibujarSalones()
        {
            FlowLayoutPanel1.Controls.Clear();
            try
            {
                Conexion.ConexionMaestra.abrir();
                string query = "SELECT * FROM salon WHERE estado='ACTIVO'";
                SqlCommand cmd = new SqlCommand(query, Conexion.ConexionMaestra.conectar);
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
                    b.ForeColor = Color.White;

                    panelC1.Size = new System.Drawing.Size(244, 58);
                    panelC1.Name = rdr["id_salon"].ToString();

                    panelLATERAL.Size = new System.Drawing.Size(3, 58);
                    panelLATERAL.Dock = DockStyle.Left;
                    panelLATERAL.BackColor = Color.Transparent;
                    panelLATERAL.Name = rdr["id_salon"].ToString();

                    panelC1.Controls.Add(b);
                    panelC1.Controls.Add(panelLATERAL);
                    FlowLayoutPanel1.Controls.Add(panelC1);
                    b.BringToFront();
                    panelLATERAL.SendToBack();

                    b.Click += new EventHandler(miEvento_salon_button);
                }
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void miEvento_salon_button(System.Object sender, EventArgs e)
        {
            try
            {
                PanelMesas.Visible = true;
                PanelMesas.Dock = DockStyle.Fill;
                id_salon = Convert.ToInt32(((Button)sender).Name);
                PanelBienvienida.Visible = false;
                PanelBienvienida.Dock = DockStyle.None;
                dibujarMESAS();
            }
            catch (Exception ex)
            {

            }
        }

        void dibujarMESAS()
        {
            PanelMesas.Controls.Clear();
            try
            {
                Conexion.ConexionMaestra.abrir();
                string query = "MostrarMesasPorSalon";
                SqlCommand cmd = new SqlCommand(query, Conexion.ConexionMaestra.conectar);
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

                    panel.Tag = rdr["id_mesa"].ToString();

                    b.Text = rdr["mesa"].ToString();
                    b.Name = rdr["id_mesa"].ToString();
                    b.Tag = rdr["estado_de_Disponibilidad"].ToString();

                    panel.Size = new System.Drawing.Size(tamanio);

                    if (b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", tamanio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        PanelMesas.Controls.Add(b);
                        b.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        PanelMesas.Controls.Add(panel);
                    }

                    if (Convert.ToString(b.Tag) == "LIBRE")
                    {
                        b.BackColor = Color.FromArgb(5, 179, 90);
                    }
                    else
                    {
                        b.BackColor = Color.Firebrick;
                    }

                    b.Click += new EventHandler(miEvento_buton_mesa);
                }
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void miEvento_buton_mesa(System.Object sender, EventArgs e)
        {

        }

        private void btnHerramientas_Click(object sender, EventArgs e)
        {
            if (Estado_de_herramientas == 1)
            {
                PanelHerramientas.Visible = false;
                Estado_de_herramientas = 0;
            }
            else if (Estado_de_herramientas == 0)
            {

                PanelHerramientas.Location = new Point(PanelBienvienida.Location.X, Panelbotones.Location.Y + btnHerramientas.Location.Y);
                PanelHerramientas.Visible = true;
                PanelHerramientas.BringToFront();

                Estado_de_herramientas = 1;
            }
        }

        private void btnadministrar_Click(object sender, EventArgs e)
        {
            Dispose();
            Configuraciones.Menu_de_configuraciones frm = new Configuraciones.Menu_de_configuraciones();
            frm.ShowDialog();
        }
    }
}
