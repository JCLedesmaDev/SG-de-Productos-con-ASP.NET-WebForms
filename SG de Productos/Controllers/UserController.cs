using Microsoft.AspNetCore.Mvc;
using SG_de_Productos.BaseDatos;
using System;
using System.Collections.Generic;


namespace SG_de_Productos.Controllers
{

    public class UserController
    {
        private IndexSP indexSP = new IndexSP();

        public ObjectResult Login(Models.UserModel usuario)
        {
            ObjectResult data = new ObjectResult(null);

            try
            {
                var response = indexSP.User.GetUser(usuario);

                if (response.Value == null )
                {
                    throw new Exception("Usuario inexistente. Intentelo nuevamente");
                }

                data.Value = response.Value;
                return data;
            } 
            catch (Exception e)
            {
                data.StatusCode = 400;
                data.Value = e.Message;
                return data;
            }
        }


        public ObjectResult Registrarse(Models.UserModel usuario)
        {
            ObjectResult response = new ObjectResult(null);

            try
            {
                bool result = indexSP.User.CreateUser(usuario);

                response.Value = result;
                return response;
            }
            catch(Exception e)
            {
                Console.WriteLine("Ocurrio un error", e.Message);
                return response;
            }
        }
    }
}