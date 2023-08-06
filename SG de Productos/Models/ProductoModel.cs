using SG_de_Productos.Models.Common;


namespace SG_de_Productos.Models
{
    public class ProductoModel : IdComun
    {
        //ATRIBUTOS
        private int idCategoria;
        private int idMarca;
        private string descripcion;
        private double precio;

        //metodos get y set
        public int _IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        public int _IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }
        public string _Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public double _Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public CategoriaModel _Categoria { get; set; }

        public MarcaModel _Marca { get; set; }
    }
}