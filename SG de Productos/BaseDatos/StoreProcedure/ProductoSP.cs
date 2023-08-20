using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SG_de_Productos.BaseDatos.StoreProcedure
{
    public class ProductoSP: ConnectionBD
    {
        public ObjectResult ListarProductos()
        {
            ObjectResult response = new ObjectResult(null);

            List<Models.ProductoModel> list = new List<Models.ProductoModel>();

            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpListarProductos"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.reader = this.cmd.ExecuteReader(); // Almacenamos los resultados de nuestra peticion

                while (this.reader.Read())
                {
                    Models.ProductoModel prod = new Models.ProductoModel {
                        _Id = (int)this.reader["Id"],
                        _Descripcion = this.reader["Descripcion"].ToString(),
                        _Precio = (double)this.reader["Precio"],
                        _IdCategoria = (int)this.reader["IdCategoria"],
                        _IdMarca = (int)this.reader["IdMarca"],
                        _Categoria = new Models.CategoriaModel { _Descripcion = this.reader["Categoria"].ToString() },
                        _Marca = new Models.MarcaModel { _Descripcion = this.reader["Marca"].ToString() }
                    };
           
                    list.Add(prod);
                }

                response.Value = list;
                return response;
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


        public ObjectResult InsertarProducto(Models.ProductoModel producto)
        {
            try
            {
                ObjectResult response = new ObjectResult(null);

                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpAgregarProducto"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@idCategoria", producto._IdCategoria);
                this.cmd.Parameters.AddWithValue("@idMarca", producto._IdMarca);
                this.cmd.Parameters.AddWithValue("@descripcion", producto._Descripcion);
                this.cmd.Parameters.AddWithValue("@precio", producto._Precio);

                this.cmd.ExecuteNonQuery();

                response.Value = "Se guardo correctamente";
                return response;
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

        public ObjectResult EditarProducto(Models.ProductoModel producto)
        {
            try
            {
                ObjectResult response = new ObjectResult(null);

                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion 
                this.cmd.CommandText = "SpEditarProducto"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@id", producto._Id);
                this.cmd.Parameters.AddWithValue("@idCategoria", producto._IdCategoria);
                this.cmd.Parameters.AddWithValue("@idMarca", producto._IdMarca);
                this.cmd.Parameters.AddWithValue("@descripcion", producto._Descripcion);
                this.cmd.Parameters.AddWithValue("@precio", producto._Precio);

                this.cmd.ExecuteNonQuery();

                response.Value =  "Se edito correctamente";
                return response;
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

        public ObjectResult EliminarProducto(int idProd)
        {
            try
            {
                ObjectResult response = new ObjectResult(null);

                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpEliminarProducto"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@idProducto", idProd);

                this.cmd.ExecuteNonQuery();

                response.Value = "Se elimino correctamente";
                return response;
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
