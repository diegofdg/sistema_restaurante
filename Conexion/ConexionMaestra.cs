using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaRestaurante.Conexion
{
    class ConexionMaestra
    {
        public static string conexion = Convert.ToString(Librerias.Desencryptacion.checkServer());
    }
}
