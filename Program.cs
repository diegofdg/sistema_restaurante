using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRestaurante
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Conexion.ConexionManual());
            Application.Run(new Modulos.Mesas_Salones.Configurar_mesas_ok());
        }
    }
}
