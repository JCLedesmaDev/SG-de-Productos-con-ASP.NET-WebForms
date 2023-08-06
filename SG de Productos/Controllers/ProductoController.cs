﻿using System.Data;
using SG_de_Productos.BaseDatos;
using SG_de_Productos.BaseDatos.StoreProcedure;

namespace SG_de_Productos.Controllers
{
    public class ProductoController
    {

        private IndexSP indexSP = new IndexSP();

        public DataTable ObtenerListadoProductos()
        {
            return indexSP.Producto.ListarProductos();
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