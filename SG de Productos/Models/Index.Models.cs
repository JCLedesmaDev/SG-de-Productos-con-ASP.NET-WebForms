using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_de_Productos.Models
{
    public class Models
    {
        public UserModel User { get; set; }
        public CategoriaModel Categoria { get; set; }
        public MarcaModel Marca { get; set; }   
        public ProductoModel Producto { get; set; } 
    }
}