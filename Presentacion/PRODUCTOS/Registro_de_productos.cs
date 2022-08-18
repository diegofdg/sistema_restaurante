using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RestCsharp.Datos;
using RestCsharp.Logica;
using System.IO;

namespace RestCsharp.Presentacion.PRODUCTOS
{
    public partial class Registro_de_productos : Form
    {
        public Registro_de_productos()
        {
            InitializeComponent();
        }
        string ESTADO_IMAGEN;
        public static int idproducto;
        public static string producto;
        public static string proceso;
        int Idcolor;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (Idcolor > 0)
            {
                if (txtdescripcion.Text != "")
                {
                    if (txtprecioventa.Text != "")
                    {
                        Insertar_Producto1();
                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione un color");
            }


        }
        private void Insertar_Producto1()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Producto", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@Id_grupo", Productos_rest.id_grupo);
                cmd.Parameters.AddWithValue("@Precio_de_venta", txtprecioventa.Text);
                cmd.Parameters.AddWithValue("@Precio_de_compra", txtpreciocompra.Text);
                cmd.Parameters.AddWithValue("@Estado_imagen", ESTADO_IMAGEN);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenProducto.Image.Save(ms, ImagenProducto.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Imagen", ms.GetBuffer());
                cmd.Parameters.AddWithValue("@Idcolor", Idcolor);
                cmd.ExecuteNonQuery();

                CONEXIONMAESTRA.cerrar();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Registro_de_productos_Load(object sender, EventArgs e)
        {
            ordenarcontroles();
            MostrarColores();
            validarProcesos();
        }
        private void validarProcesos()
        {
            if (proceso == "AGREGAR")
            {
                btnguardar.Visible = true;
                btnguardarcambios.Visible = false;
            }
            else if (proceso == "EDITAR")
            {

                ObtenerColorxproducto();
                txtdescripcion.Text = producto;
                btnguardar.Visible = false;
                btnguardarcambios.Visible = true;
            }
        }

        private void ObtenerColorxproducto()
        {
            var funcion = new Dcolores();
            var parametros = new Lproductos();
            var dt = new DataTable();
            parametros.Id_Producto1 = idproducto;
            funcion.mostrarColorxProducto(ref dt, parametros);
            Idcolor = Convert.ToInt32(dt.Rows[0][1]);
            btncolor.BackColor = ColorTranslator.FromHtml(dt.Rows[0][0].ToString());
            ESTADO_IMAGEN = (dt.Rows[0][3]).ToString();
            ImagenProducto.BackgroundImage = null;
            byte[] b = (byte[])((dt.Rows[0][2]));
            MemoryStream ms = new MemoryStream(b);
            ImagenProducto.Image = Image.FromStream(ms);
            txtprecioventa.Text = dt.Rows[0][5].ToString();
            txtpreciocompra.Text = dt.Rows[0][4].ToString();
            if (ESTADO_IMAGEN == "VACIO")
            {
                PanelIcono.Visible = true;
            }
            else
            {
                PanelIcono.Visible = false;

            }



        }

        private void ordenarcontroles()
        {
            PanelIcono.Size = new Size(ImagenProducto.Width, ImagenProducto.Height);
            FormBorderStyle = FormBorderStyle.None;
            ESTADO_IMAGEN = "VACIO";
        }
        private void MostrarColores()
        {
            var dt = new DataTable();
            var funcion = new Dcolores();
            funcion.mostrarcolores(ref dt);
            foreach (DataRow rdr in dt.Rows)
            {
                Button btn1 = new Button();
                btn1.Width = 30;
                btn1.Height = 30;
                btn1.FlatStyle = FlatStyle.Flat;
                btn1.BackColor = ColorTranslator.FromHtml(rdr["ColorHtml"].ToString());
                btn1.Name = rdr["ColorHtml"].ToString();
                btn1.Tag = rdr["Idcolor"].ToString();
                flowLayoutPanel1.Controls.Add(btn1);
                btn1.Click += Btn1_Click;
            }

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Idcolor = Convert.ToInt32(((Button)sender).Tag);
            string color;
            color = ((Button)sender).Name;
            btncolor.BackColor = ColorTranslator.FromHtml(color);



        }

        private void label4_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }
        private void agregar_imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenProducto.BackgroundImage = null;
                ImagenProducto.Image = new Bitmap(dlg.FileName);
                PanelIcono.Visible = false;
                ESTADO_IMAGEN = "LLENO";
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btncerrrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtdescripcion.Text))
            {
                if (!string.IsNullOrEmpty(txtprecioventa.Text))
                {
                    if (string.IsNullOrEmpty(txtpreciocompra.Text))
                    {
                        txtpreciocompra.Text = 0.ToString();
                        editarProductos();
                    }
                    else
                    {
                        editarProductos();
                    }
                }
                else
                {
                    MessageBox.Show("Agrege un precio de venta");
                }

            }
            else
            {
                MessageBox.Show("Agrege un nombre de producto");
            }

        }
        private void editarProductos()
        {
            var funcion = new Dproductos();
            var parametros = new Lproductos();
            parametros.Descripcion = txtdescripcion.Text;
            parametros.Precio_de_venta = Convert.ToDouble(txtprecioventa.Text);
            parametros.Precio_de_compra = Convert.ToDouble(txtpreciocompra.Text);
            parametros.Estado_imagen = ESTADO_IMAGEN;
            parametros.Idcolor = Idcolor;
            parametros.Id_Producto1 = idproducto;
            MemoryStream ms = new MemoryStream();
            ImagenProducto.Image.Save(ms, ImagenProducto.Image.RawFormat);
            parametros.Imagen = ms.GetBuffer();
            if (funcion.editarProductos(parametros) == true)
            {
                Close();
            }



        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            Bases.Separador_de_Numeros(txtprecioventa, e);
           
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtpreciocompra, e);
           
        }

        private void txtprecioventa_TextChanged(object sender, EventArgs e)
        {
            //Bases.Reemplazarcomas(txtpreciocompra, e);
        }

        private void txtpreciocompra_TextChanged(object sender, EventArgs e)
        {
            //Bases.Reemplazarcomas(txtpreciocompra, e);
        }
    }
}
