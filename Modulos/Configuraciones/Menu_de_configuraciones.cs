using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaRestaurante.Modulos.Configuraciones
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
            Modulos.Punto_De_Venta.Visor_de_mesas frm = new Modulos.Punto_De_Venta.Visor_de_mesas();
            frm.ShowDialog();
        }
    }
}
