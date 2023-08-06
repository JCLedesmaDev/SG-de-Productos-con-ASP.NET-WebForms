using SG_de_Productos.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_de_Productos.Models
{
    public class CategoriaModel : IdComun
    {
        private string descripcion;

        //metodos get y set
        public string _Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public List<ProductoModel> _Productos { get; set; }
    }
}