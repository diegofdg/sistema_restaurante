using RestCsharp.Datos;
using RestCsharp.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestCsharp.Presentacion.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        string login;
        int idusuario;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            centralPaneles();
            dibujarUsuarios();
        }
        private void centralPaneles()
        {
            PanelVisorDeUsuarios.Dock = DockStyle.Fill;            
            PanelIngresarContraseña.Location = new Point((panel6.Width - PanelIngresarContraseña.Width) / 2, (panel6.Height - PanelIngresarContraseña.Height) / 2);
        }
        private void dibujarUsuarios()
        {
            PanelMostradorUsuarios.Controls.Clear();

            DataTable dt = new DataTable();
            Dusuarios funcion = new Dusuarios();
            funcion.dibujarUsuarios(ref dt);
            foreach (DataRow rdr in dt.Rows)
            {
                Label l = new Label();
                Panel p = new Panel();
                PictureBox Pt = new PictureBox();
                l.Text = rdr["Login"].ToString();
                l.Name = rdr["IdUsuario"].ToString();
                l.Size = new Size(175, 25);
                l.Font = new Font("Microsoft Sans Serif", 13);
                l.BackColor = Color.Transparent;
                l.ForeColor = Color.White;
                l.Dock = DockStyle.Bottom;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Cursor = Cursors.Hand;

                p.Size = new Size(155, 167);
                p.BorderStyle = BorderStyle.None;
                p.BackColor = Color.FromArgb(20, 20, 20);

                Pt.BackgroundImage = null;
                byte[] bi = (Byte[])rdr["Icono"];
                MemoryStream ms = new MemoryStream(bi);
                Pt.Image = Image.FromStream(ms);
                Pt.Dock = DockStyle.Fill;
                Pt.SizeMode = PictureBoxSizeMode.Zoom;
                Pt.Tag = rdr["Login"].ToString();
                Pt.Cursor = Cursors.Hand;

                p.Controls.Add(l);
                p.Controls.Add(Pt);
                Pt.BringToFront();
                PanelMostradorUsuarios.Controls.Add(p);
                l.Click += L_Click;
                Pt.Click += Pt_Click;

            }

        }

        private void Pt_Click(object sender, EventArgs e)
        {
            login = ((PictureBox)sender).Tag.ToString();
            verPanelcontraseña();
        }

        private void L_Click(object sender, EventArgs e)
        {
            login = ((Label)sender).Text;
            verPanelcontraseña();


        }
        private void verPanelcontraseña()
        {
            PanelVisorDeUsuarios.Visible = false;
            PanelContraseña.Visible = true;
            PanelContraseña.Dock = DockStyle.Fill;
            PanelIngresarContraseña.Location = new Point((panel6.Width - PanelIngresarContraseña.Width) / 2, (panel6.Height - PanelIngresarContraseña.Height) / 2);
        }

        private void txtcontraseña_TextChanged(object sender, EventArgs e)
        {
            validarUsuarios();
        }
        private void validarUsuarios()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Password = Bases.Encriptar(txtcontraseña.Text);
            parametros.Login = login;
            funcion.validarUsuario(parametros, ref idusuario);
            if (idusuario > 0)
            {
                Dispose();
                PUNTO_DE_VENTA.Visor_de_mesas frm = new PUNTO_DE_VENTA.Visor_de_mesas();
                frm.ShowDialog();
            }
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "0";
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtcontraseña.Clear();
        }

        private void btnborrarderecha_Click(object sender, EventArgs e)
        {
            int contador;
            contador = txtcontraseña.Text.Count();
            if (contador > 0)
            {
                txtcontraseña.Text = txtcontraseña.Text.Substring(0, txtcontraseña.Text.Count() - 1);
            }

        }
    }
}
