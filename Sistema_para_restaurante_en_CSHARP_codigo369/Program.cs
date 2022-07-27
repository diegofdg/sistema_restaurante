using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_para_restaurante_en_CSHARP_codigo369
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CONEXION.CONEXION_MANUAL());
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MODULOS.PUNTO_DE_VENTA.Visor_de_mesas frm = new MODULOS.PUNTO_DE_VENTA.Visor_de_mesas();            
            frm.FormClosed += frm_closed;
            frm.ShowDialog();
            Application.Run();
            
        }

        private static void frm_closed(object sender, FormClosedEventArgs e)
        {         
           Application.ExitThread();
           Application.Exit();         
        }
    }
}
