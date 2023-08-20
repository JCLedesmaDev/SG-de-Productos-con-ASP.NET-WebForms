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

        public ObjectResult InsertarProducto(Models.ProductoModel producto)
        {
            ObjectResult data = new ObjectResult(null);
            try
            {
                ObjectResult response = indexSP.Producto.InsertarProducto(producto);

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

        public ObjectResult EditarProducto(Models.ProductoModel producto)
        {
            ObjectResult data = new ObjectResult(null);

            try
            {
                ObjectResult response = indexSP.Producto.EditarProducto(producto);

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

        public ObjectResult EliminarProducto(int idProd)
        {
            ObjectResult data = new ObjectResult(null);

            try
            {
                ObjectResult response = indexSP.Producto.EliminarProducto(idProd);

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
    }
}