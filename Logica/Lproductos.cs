using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestCsharp.Logica
{
   public class Lproductos
    {
        public int Id_Producto1 { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public int Id_grupo { get; set; }
        public double Precio_de_venta { get; set; }
        public double Precio_de_compra { get; set; }
        public string Estado_imagen { get; set; }
        public int Idcolor { get; set; }
        public string Estado { get; set; }

    }
}
