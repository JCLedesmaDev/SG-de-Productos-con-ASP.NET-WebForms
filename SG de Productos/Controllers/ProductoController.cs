using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using SG_de_Productos.BaseDatos;
using SG_de_Productos.BaseDatos.StoreProcedure;

namespace SG_de_Productos.Controllers
{
    public class ProductoController
    {

        private IndexSP indexSP = new IndexSP();


        public ObjectResult ObtenerListadoProductos()
        {
            ObjectResult data = new ObjectResult(null);

            try
            {
                ObjectResult response = indexSP.Producto.ListarProductos();

                data.Value = response.Value;
                return data;
            }
            catch (Exception e)
            {
                data.StatusCode = 400;
                data.Value = e.Message;
                return data;
            }
        }

        public string InsertarProducto(Models.ProductoModel producto)
        {
            return indexSP.Producto.InsertarProducto(producto);
        }

        public string EditarProducto(Models.ProductoModel producto)
        {
            return indexSP.Producto.EditarProducto(producto);
        }

        public string EliminarProducto(int idProd)
        {
            return indexSP.Producto.EliminarProducto(idProd);
        }

    }
}