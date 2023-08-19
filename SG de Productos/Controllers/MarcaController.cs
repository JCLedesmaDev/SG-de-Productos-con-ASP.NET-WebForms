using Microsoft.AspNetCore.Mvc;
using SG_de_Productos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_de_Productos.Controllers
{
    public class MarcaController
    {
        private IndexSP indexSP = new IndexSP();

        public ObjectResult ObtenerListadoMarca()
        {
            ObjectResult data = new ObjectResult(null);

            try
            {
                ObjectResult response = indexSP.Marca.ListarMarcas();

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