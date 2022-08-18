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

namespace RestCsharp.Presentacion.Empresaconfig
{
    public partial class Eempresa : Form
    {
        public Eempresa()
        {
            InitializeComponent();
        }
        string venderImpuesto;
        string notas;
        private void Eempresa_Load(object sender, EventArgs e)
        {
            ObtenerDatos();
        }
        private void ObtenerDatos()
        {
            var dt = new DataTable();
            var funcion = new Dempresa();
            funcion.mostrarempresa(ref dt);
            foreach(DataRow hobbit in dt.Rows)
            {
                txtempresa.Text = hobbit["Nombre_Empresa"].ToString();
                txtpais.Text = hobbit["Pais"].ToString();
                venderImpuesto = hobbit["Trabajas_con_impuestos"].ToString();
                validarImpuestos();
                txtimpuesto.Text = hobbit["Impuesto"].ToString();
                txtporcentaje.Text = hobbit["Porcentaje_impuesto"].ToString();
                notas = hobbit["Tiponotas"].ToString();
                validarNotas();
                txtRuta.Text = hobbit["Carpeta_para_copias_de_seguridad"].ToString();
                ImagenEmpresa.BackgroundImage = null;
                byte[] b = (byte[])(hobbit["Logo"]);
                MemoryStream ms = new MemoryStream(b);
                ImagenEmpresa.Image = Image.FromStream(ms);
            }
        }
        private void validarNotas()
        {
            if (notas == "General")
            {
                chGeneral.Checked = true;
            }
            else
            {   
                chPorpedido.Checked = true;
            }
        }
            
        private void validarImpuestos()
        {
            if (venderImpuesto == "SI")
            {
                panelImpuestos.Visible = true;
                si.Checked = true;
            }
            else
            {
                panelImpuestos.Visible = false;
                no.Checked = true;
            }
        }

        private void lbleditarLogo_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes BUMAM";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenEmpresa.BackgroundImage = null;
                ImagenEmpresa.Image = new Bitmap(dlg.FileName);
            }

        }

        private void Label9_Click(object sender, EventArgs e)
        {
            ObtenerRuta();
        }
        private void ObtenerRuta()
        {
            if (Fbd.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = Fbd.SelectedPath;
            }
        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            ObtenerRuta();
        }

        private void txtpais_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmoneda.SelectedIndex = txtpais.SelectedIndex;
        }

        private void si_CheckedChanged(object sender, EventArgs e)
        {
            panelImpuestos.Visible = true;
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            panelImpuestos.Visible = false;
        }

        private void chGeneral_CheckedChanged(object sender, EventArgs e)
        {
            notas = "General";
        }

        private void chPorpedido_CheckedChanged(object sender, EventArgs e)
        {
            notas = "Porpedido";
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtempresa.Text))
            {
                InsertarEmpresa();
            }
            else
            {
                MessageBox.Show("Ingrese un Nombre de Empresa", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void InsertarEmpresa()
        {
            var funcion = new Dempresa();
            var parametros = new Lempresa();
            parametros.Nombre_Empresa = txtempresa.Text;
            MemoryStream ms = new MemoryStream();
            ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);
            parametros.Logo = ms.GetBuffer();
            parametros.Impuesto = txtimpuesto.Text;
            parametros.Porcentaje_impuesto = Convert.ToDouble(txtporcentaje.Text);
            parametros.Moneda = txtmoneda.Text;
            if (si.Checked == true)
            {
                parametros.Trabajas_con_impuestos = "SI";
            }
            if (no.Checked == true)
            {
                parametros.Trabajas_con_impuestos = "NO";
            }
            parametros.Carpeta_para_copias_de_seguridad = txtRuta.Text;
            parametros.Pais = txtpais.Text;
            validarNotas();
            parametros.Tiponotas = notas;
            if (funcion.editarEmpresa(parametros) == true)
            {
                MessageBox.Show("Registros guardados");
                Dispose();
            }




        }
    }
}
