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
                CONEXION.CONEXIONMAESTRA.abrir();
                string query = "Select * from SALON Where Estado='ACTIVO'";
                SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    Panel panelLATERAL = new Panel();
                    b.Text = rdr["Salon"].ToString();
                    b.Name = rdr["Id_salon"].ToString();
                    b.Tag = rdr["Estado"].ToString();
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
                    panelC1.Name = rdr["Id_salon"].ToString();

                    panelLATERAL.Size = new System.Drawing.Size(3, 58);
                    panelLATERAL.Dock = DockStyle.Left;
                    panelLATERAL.BackColor = Color.Transparent;
                    panelLATERAL.Name = rdr["Id_salon"].ToString();

                    panelC1.Controls.Add(b);
                    panelC1.Controls.Add(panelLATERAL);
                    FlowLayoutPanel1.Controls.Add(panelC1);
                    b.BringToFront();
                    panelLATERAL.SendToBack();

                    b.Click += new EventHandler(miEvento_salon_button);
                }
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento_salon_button(System.Object sender, EventArgs e)
        {
            try
            {
                PanelMesas.Visible = true;
                PanelMesas.Dock = DockStyle.Fill;
                id_salon = Convert.ToInt32 (((Button)sender).Name);
                PanelBienvienida.Visible = false;
                PanelBienvienida.Dock = DockStyle.None;
                dibujarMESAS();
                foreach (System.Windows.Forms.Control panelC2 in FlowLayoutPanel1.Controls)
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
                foreach (System.Windows.Forms.Control panelC1 in FlowLayoutPanel1.Controls)
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
                                    break;
                                }
                            }
                        }

                    }
                }
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
                CONEXION.CONEXIONMAESTRA.abrir();
                string query = "mostrar_mesas_por_salon";
                SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();

                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamanio_letra = Convert.ToInt32(rdr["Tamanio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);

                    panel.Tag = rdr["Id_mesa"].ToString();

                    b.Text = rdr["Mesa"].ToString();
                    b.Name = rdr["Id_mesa"].ToString();
                    b.Tag = rdr["Estado_de_Disponibilidad"].ToString();

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

                    if (Convert.ToString (b.Tag) =="LIBRE")
                    {
                        b.BackColor = Color.FromArgb(5, 179, 90);
                    }
                    else
                    {
                        b.BackColor = Color.Firebrick;
                    }

                    b.Click += new EventHandler(miEvento_buton_mesa);
                }
                CONEXION.CONEXIONMAESTRA.Cerrar();
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void miEvento_buton_mesa(System.Object sender, EventArgs e)
        {
            try
            {
                idmesa = Convert.ToInt32(  ((Button)sender).Name);
                nombre_mesa = ((Button)sender).Text;
                Dispose();
                MODULOS.PUNTO_DE_VENTA.Punto_de_venta frm = new MODULOS.PUNTO_DE_VENTA.Punto_de_venta();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                Estado_de_herramientas =1;
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
