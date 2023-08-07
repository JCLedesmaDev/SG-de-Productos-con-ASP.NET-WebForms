

using SG_de_Productos.BaseDatos.StoreProcedure;

namespace SG_de_Productos.BaseDatos
{
    public class IndexSP
    {
        public UserSP User = new UserSP();
        public ProductoSP Producto = new ProductoSP();  
        public MarcaSP Marca = new MarcaSP();
        public CategoriaSP Categoria = new CategoriaSP();  
    }
}

