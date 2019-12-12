using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Server_Ventas_MVC_Rodriguez.Models
{
    public class ProductoDTO
    {

        public int Producto_id { get; set; }

        public string Categoria_id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Imagen { get; set; }

        public string Estado { get; set; }

    }
}