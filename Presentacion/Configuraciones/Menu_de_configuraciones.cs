﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestCsharp.Presentacion.Configuraciones
{
    public partial class Menu_de_configuraciones : Form
    {
        public Menu_de_configuraciones()
        {
            InitializeComponent();
        }

        private void Menu_de_configuraciones_Load(object sender, EventArgs e)
        {
            centrar_panel_contenedor();
        }
        private void centrar_panel_contenedor()
        {
        
            PanelContenedor.Location = new Point((panel1.Width - PanelContenedor.Width) / 2, (panel1.Height - PanelContenedor.Height) / 2);
        }

        private void Menu_de_configuraciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Presentacion.PUNTO_DE_VENTA.Visor_de_mesas frm = new Presentacion.PUNTO_DE_VENTA.Visor_de_mesas();          
            frm.ShowDialog();
            
        }

        private void btnmesas_Click(object sender, EventArgs e)
        {
            Presentacion.Mesas_salones.Configurar_mesas_ok frm = new Presentacion.Mesas_salones.Configurar_mesas_ok();
            frm.ShowDialog();
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            Presentacion.PRODUCTOS.Productos_rest frm = new Presentacion.PRODUCTOS.Productos_rest();
            frm.ShowDialog();
        }
    }
}
