using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaRestaurante.Modulos.Mesas_Salones
{
    public partial class Configurar_mesas_ok : Form
    {
        public Configurar_mesas_ok()
        {
            InitializeComponent();
        }
        private void Configurar_mesas_ok_Load(object sender, EventArgs e)
        {
            PanelBienvenida.Dock = DockStyle.Fill;
        }
    }
}
