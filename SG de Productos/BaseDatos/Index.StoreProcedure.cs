

using SG_de_Productos.BaseDatos.StoreProcedure;

namespace SG_de_Productos.BaseDatos
{
    public class IndexSP
    {
        public UserSP User { get; set; }
        public ProductoSP Producto { get; set; }
        public MarcaSP Marca { get; set; }
        public CategoriaSP Categoria { get; set; }  
    }
}

