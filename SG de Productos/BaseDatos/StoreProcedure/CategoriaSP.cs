using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;

namespace SG_de_Productos.BaseDatos.StoreProcedure
{
    public class CategoriaSP: ConnectionBD
    {
        public ObjectResult ListarCategorias()
        {
            ObjectResult response = new ObjectResult(null);

            List<Models.CategoriaModel> list = new List<Models.CategoriaModel>();

            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpListarCategorias"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.reader = this.cmd.ExecuteReader(); // Almacenamos los resultados de nuestra peticion

                while (this.reader.Read())
                {
                    Models.CategoriaModel prod = new Models.CategoriaModel
                    {
                        _Id = (int)this.reader["Id"],
                        _Descripcion = this.reader["Descripcion"].ToString(),
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

        public string InsertarCategoria(Models.CategoriaModel categoria)
        {
            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion

                this.cmd.CommandText = "SpAgregarCategoria"; /// Nombramos el procedimiento creado en el SqlServer

                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 


                this.cmd.Parameters.AddWithValue("@descripcion", categoria._Descripcion);

                this.cmd.ExecuteNonQuery();

                return "Se inserto correctamente";
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de insertar una categoria.", e);
            }
            finally
            {
                this.cmd.Parameters.Clear();
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }
    }
}