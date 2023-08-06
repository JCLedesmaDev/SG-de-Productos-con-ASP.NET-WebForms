using System;
using System.Collections.Generic;
using System.Data;

namespace SG_de_Productos.BaseDatos.StoreProcedure
{
    public class UserSP : ConnectionBD
    {

        public bool CreateUser(Models.UserModel usuario)
        {
            try
            {
                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion 
                this.cmd.CommandText = "SpAgregarUsuario"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@email", usuario._Email);
                this.cmd.Parameters.AddWithValue("@password", usuario._Password);
                this.cmd.Parameters.AddWithValue("@nombreCompleto", usuario._NombreCompleto);
                this.cmd.Parameters.AddWithValue("@createDateUser", DateTime.Now);

                this.cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de crear un usuario.", e);
            }
            finally
            {
                this.cmd.Parameters.Clear();
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }

        public List<object> GetUser(Models.UserModel usuario)
        {
            try
            {

                List<object> UserFind = new List<object>();

                this.cmd.Connection = this.OpenConnection(); // Abrimos conexion
                this.cmd.CommandText = "SpObtenerUsuario"; /// Nombramos el procedimiento creado en el SqlServer
                this.cmd.CommandType = CommandType.StoredProcedure; // Indicamos que estamos utilizando procedimientos almacenados (Por lo de arriba) 

                this.cmd.Parameters.AddWithValue("@email", usuario._Email);
                this.cmd.Parameters.AddWithValue("@password", usuario._Password);

                this.reader = this.cmd.ExecuteReader(); // Almacenamos los resultados de nuestra peticion

                while (this.reader.Read())
                {
                    UserFind.Add(this.reader[0]);
                }

                return UserFind;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error a la hora de obtener un Usuario", e);
            }
            finally
            {
                this.cmd.Parameters.Clear();
                this.reader.Close(); // Cerramos la lectura de datos
                this.CloseConnection(); // Cerramos la conexion a la BD
            }
        }
    }
}
