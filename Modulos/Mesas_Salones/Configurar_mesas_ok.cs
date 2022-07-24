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

        public Configurar_mesas_ok()
        {
            InitializeComponent();
        }
        private void Configurar_mesas_ok_Load(object sender, EventArgs e)
        {
            PanelBienvenida.Dock = DockStyle.Fill;
            dibujarSalones();
        }
        private void dibujarSalones()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                Conexion.ConexionMaestra.conectar.Open();
                SqlCommand cmd = new SqlCommand("MostrarSalon", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscar", txtsalon.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    b.Text = rdr["salon"].ToString();
                    b.Name = rdr["id_salon"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Tag = rdr["estado"].ToString();

                    panelC1.Size = new System.Drawing.Size(290, 58);
                    panelC1.Name = rdr["id_salon"].ToString();
                    string estado;
                    estado = rdr["estado"].ToString();
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
                    flowLayoutPanel1.Controls.Add(panelC1);
                    b.Click += new EventHandler(miEvento_salon_button);
                }
                Conexion.ConexionMaestra.conectar.Close();

            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.conectar.Close();
                MessageBox.Show(ex.StackTrace);
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

            foreach (Panel PanelC1 in flowLayoutPanel1.Controls)
            {
                if (PanelC1 is Panel)
                {
                    foreach (Button boton in PanelC1.Controls)
                    {
                        if (boton is Button)
                        {
                            boton.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }

            string NOMBRE = Convert.ToString(((Button)sender).Name);

            foreach (Panel PanelC1 in flowLayoutPanel1.Controls)
            {
                if (PanelC1 is Panel)
                {
                    foreach (Button boton in PanelC1.Controls)
                    {
                        if (boton is Button)
                        {
                            if (boton.Name == NOMBRE)
                            {
                                boton.BackColor = Color.OrangeRed;
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
    }
}
