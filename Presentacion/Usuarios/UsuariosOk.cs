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

namespace RestCsharp.Usuarios
{
    public partial class UsuariosOk : Form
    {
        public UsuariosOk()
        {
            InitializeComponent();
        }
        int idusuario;
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnagregar_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitarPaneles();
            dibujarModulos();
        }
        private void habilitarPaneles()
        {
            panelregistro.Visible = true;
            lblanuncioIcono.Visible = true;
            panelIcono.Visible = false;
            panelregistro.Dock = DockStyle.Fill;
        }
        private void limpiar()
        {
            txtnombre.Clear();
            txtcontraseña.Clear();
            txtusuario.Clear();
            txtcorreo.Clear();
        }
        private void dibujarModulos()
        {
            Dmodulos funcion = new Dmodulos();
            DataTable dt = new DataTable();
            funcion.mostrar_Modulos(ref dt);
            datalistadoPermisos.DataSource = dt;
        }

        private void UsuariosOk_Load(object sender, EventArgs e)
        {

        }

        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cbxRol.SelectedIndex;
            foreach (DataGridViewRow row in datalistadoPermisos.Rows)
            {
                bool marcar = Convert.ToBoolean(row.Cells["Marcar"].Value);
                string Modulo = row.Cells["Modulo"].Value.ToString();
                if (indice == 0)
                {
                    if (Modulo == "Ventas") { row.Cells[0].Value = true; }
                    if (Modulo == "Compras") { row.Cells[0].Value = false; }
                    if (Modulo == "Caja") { row.Cells[0].Value = false; }
                }
                if (indice == 1)
                {
                    if (Modulo == "Ventas") { row.Cells[0].Value = true; }
                    if (Modulo == "Compras") { row.Cells[0].Value = false; }
                    if (Modulo == "Caja") { row.Cells[0].Value = true; }
                }
                if (indice == 2)
                {
                    row.Cells[0].Value = true;
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            insertarUsuarios();
        }
        private void insertarUsuarios()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Nombre = txtnombre.Text;
            parametros.Login = txtusuario.Text;
            parametros.Password = txtcontraseña.Text;
            MemoryStream ms = new MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();
            parametros.Correo = txtcorreo.Text;
            parametros.Rol = cbxRol.Text;
            if (funcion.InsertarUsuarios(parametros) == true)
            {
                ObtenerIdUsuario();
                insertarPermisos();

            }
        }
        private void ObtenerIdUsuario()
        {
            Dusuarios funcion = new Dusuarios();
            funcion.ObtenerIdUsuario(ref idusuario, txtusuario.Text);
        }
        private void insertarPermisos()
        {
            foreach (DataGridViewRow row in datalistadoPermisos.Rows)
            {
                int idModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                bool marcado = Convert.ToBoolean(row.Cells["Marcar"].Value);
                if (marcado == true)
                {
                    Lpermisos parametros = new Lpermisos();
                    Dpermisos funcion = new Dpermisos();
                    parametros.IdModulo = idModulo;
                    parametros.IdUsuario = idusuario;
                    if (funcion.Insertar_Permisos(parametros) == true)
                    {
                        MessageBox.Show("Registrado");
                    }
                }
            }


        }

        private void AgregarIcono_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
                ocultarPanelIconos();
            }
        }
        private void ocultarPanelIconos()
        {
            panelIcono.Visible = false;
            lblanuncioIcono.Visible = false;
            Icono.Visible = true;
        }
        private void lblanuncioIcono_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = true;
            panelIcono.Dock = DockStyle.Fill;
            panelIcono.BringToFront();
        }

        private void p8_Click(object sender, EventArgs e)
        {
            Icono.Image = p8.Image;
            ocultarPanelIconos();
        }

        private void p7_Click(object sender, EventArgs e)
        {
            Icono.Image = p7.Image;
            ocultarPanelIconos();
        }

        private void p6_Click(object sender, EventArgs e)
        {
            Icono.Image = p6.Image;
            ocultarPanelIconos();
        }

        private void p5_Click(object sender, EventArgs e)
        {
            Icono.Image = p5.Image;
            ocultarPanelIconos();
        }

        private void p4_Click(object sender, EventArgs e)
        {
            Icono.Image = p4.Image;
            ocultarPanelIconos();
        }

        private void p3_Click(object sender, EventArgs e)
        {
            Icono.Image = p3.Image;
            ocultarPanelIconos();
        }

        private void p2_Click(object sender, EventArgs e)
        {
            Icono.Image = p2.Image;
            ocultarPanelIconos();
        }

        private void p1_Click(object sender, EventArgs e)
        {
            Icono.Image = p1.Image;
            ocultarPanelIconos();
        }

        private void btnVolverIcono_Click(object sender, EventArgs e)
        {
            ocultarPanelIconos();
        }
    }
}
