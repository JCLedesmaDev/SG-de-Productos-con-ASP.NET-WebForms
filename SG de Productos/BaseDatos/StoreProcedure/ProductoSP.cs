using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SG_de_Productos.BaseDatos.StoreProcedure
{
    public class ProductoSP: ConnectionBD
    {
        public DataTable ListarProductos()
        {
            DataTable Table = new DataTable();

            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpListarProductos"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.reader = this.cmd.ExecuteReader(); // Almacenamos los resultados de nuestra peticion

                Table.Load(this.reader); // Cargamos la tabla con los datos obtenidos

                return Table;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de obtener el listado.", e);
            }
            finally
            {
                this.reader.Close(); // Cerramos la lectura de datos
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }


        public string InsertarProducto(Models.ProductoModel producto)
        {
            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpAgregarProducto"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@idCategoria", producto._IdCategoria);
                this.cmd.Parameters.AddWithValue("@idMarca", producto._IdMarca);
                this.cmd.Parameters.AddWithValue("@descripcion", producto._Descripcion);
                this.cmd.Parameters.AddWithValue("@precio", producto._Precio);

                this.cmd.ExecuteNonQuery();

                return "Se inserto correctamente";
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de obtener el listado.", e);
            }
            finally
            {
                this.cmd.Parameters.Clear();
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }

        public string EditarProducto(Models.ProductoModel producto)
        {
            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion 
                this.cmd.CommandText = "SpEditarProducto"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@id", producto._Id);
                this.cmd.Parameters.AddWithValue("@idCategoria", producto._IdCategoria);
                this.cmd.Parameters.AddWithValue("@idMarca", producto._IdMarca);
                this.cmd.Parameters.AddWithValue("@descripcion", producto._Descripcion);
                this.cmd.Parameters.AddWithValue("@precio", producto._Precio);

                this.cmd.ExecuteNonQuery();

                return "Se edito correctamente";
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de editar un producto.", e);
            }
            finally
            {
                this.cmd.Parameters.Clear();
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }

        public string EliminarProducto(int idProd)
        {
            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpEliminarProducto"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@idProducto", idProd);

                this.cmd.ExecuteNonQuery();

                return "Se elimino correctamente";
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de obtener el listado.", e);
            }
            finally
            {
                this.cmd.Parameters.Clear();
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }

    }

}
