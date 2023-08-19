using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SG_de_Productos.BaseDatos.StoreProcedure
{
    public class MarcaSP : ConnectionBD
    {
        public ObjectResult ListarMarcas()
        {
            ObjectResult response = new ObjectResult(null);

            List<Models.MarcaModel> list = new List<Models.MarcaModel>();

            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpListarMarcas"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.reader = this.cmd.ExecuteReader(); // Almacenamos los resultados de nuestra peticion


                while (this.reader.Read())
                {
                    Models.MarcaModel prod = new Models.MarcaModel
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

        public string InsertarMarca(Models.MarcaModel marca)
        {
            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion

                this.cmd.CommandText = "SpAgregarMarcas"; /// Nombramos el procedimiento creado en el SqlServer

                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@descripcion", marca._Descripcion);

                this.cmd.ExecuteNonQuery();

                return "Se inserto correctamente";
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de insertar una marca.", e);
            }
            finally
            {
                this.cmd.Parameters.Clear();
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }
    }
}
