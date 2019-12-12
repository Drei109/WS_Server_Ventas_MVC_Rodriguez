using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WS_Server_Ventas_MVC_Rodriguez.Models;

namespace WS_Server_Ventas_MVC_Rodriguez.WebServices
{
    /// <summary>
    /// Descripción breve de WebServiceVentas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
    [System.Web.Script.Services.ScriptService]
    public class WebServiceVentas : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<CategoriaDTO> ListarCategorias()
        {
            using (Modelo_Ventas db = new Modelo_Ventas())
            {
                var query = (from categ in db.Categoria
                             select new CategoriaDTO()
                             {
                                 CategoriaId = categ.categoria_id,
                                 Nombre = categ.nombre
                             }).ToList();

                return query;
            }
        }

        [WebMethod]
        public List<CategoriaDTO> ListarCategoriasPorId(int id)
        {
            if (id == 0)
            {
                return ListarCategorias();
            }
            using (Modelo_Ventas db = new Modelo_Ventas())
            {
                var query = (from categ in db.Categoria
                             where categ.categoria_id.Equals(id)
                             select new CategoriaDTO()
                             {
                                 CategoriaId = categ.categoria_id,
                                 Nombre = categ.nombre
                             }).ToList();

                return query;
            }
        }

        [WebMethod]
        public List<CategoriaDTO> ListarCategoriasPorNombre(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                return ListarCategorias();
            }

            using (Modelo_Ventas db = new Modelo_Ventas())
            {
                var query = (from categ in db.Categoria
                             select new CategoriaDTO()
                             {
                                 CategoriaId = categ.categoria_id,
                                 Nombre = categ.nombre
                             }).Where(x => x.Nombre.Contains(nombre)).ToList();

                return query;
            }
        }

        [WebMethod]
        public List<ProductoDTO> ListarProductos(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                return Listar();
            }
            else
            {
                using (Modelo_Ventas db = new Modelo_Ventas())
                {
                    var query = (from prod in db.Producto
                                 join cate in db.Categoria on prod.categoria_id equals cate.categoria_id
                                 select new ProductoDTO()
                                 {
                                     Producto_id = prod.producto_id,
                                     Categoria_id = cate.nombre,
                                     Nombre = prod.nombre,
                                     Descripcion = prod.descripcion,
                                     Precio = prod.precio,
                                     Stock = prod.stock,
                                     Imagen = prod.imagen,
                                     Estado = prod.estado
                                 }).Where(x => x.Nombre.Contains(nombre)).ToList();

                    return query;
                }
            }
        }

        [WebMethod]
        public List<ProductoDTO> ListarProductosPorId(int id)
        {
            if (id == 0)
            {
                return Listar();
            }

            using (Modelo_Ventas db = new Modelo_Ventas())
            {
                var query = (from prod in db.Producto
                             where prod.producto_id.Equals(id)
                             join cate in db.Categoria on prod.categoria_id equals cate.categoria_id
                             select new ProductoDTO()
                             {
                                 Producto_id = prod.producto_id,
                                 Categoria_id = cate.nombre,
                                 Nombre = prod.nombre,
                                 Descripcion = prod.descripcion,
                                 Precio = prod.precio,
                                 Stock = prod.stock,
                                 Imagen = prod.imagen,
                                 Estado = prod.estado
                             }).ToList();

                return query;
            }
        }

        public List<ProductoDTO> Listar()
        {
            using (Modelo_Ventas db = new Modelo_Ventas())
            {
                var query = (from prod in db.Producto
                             join cate in db.Categoria on prod.categoria_id equals cate.categoria_id
                             select new ProductoDTO()
                             {
                                 Producto_id = prod.producto_id,
                                 Categoria_id = cate.nombre,
                                 Nombre = prod.nombre,
                                 Descripcion = prod.descripcion,
                                 Precio = prod.precio,
                                 Stock = prod.stock,
                                 Imagen = prod.imagen,
                                 Estado = prod.estado
                             }).ToList();

                return query;
            }
        }
    }
}