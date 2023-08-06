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
            ObjectResult response = new ObjectResult(null);

            try
            {
                bool result = false;
                List<object> User = indexSP.User.GetUser(usuario);

                if (User.Count == 0)
                {
                    throw new Exception("Ocurrio un error a la hora de iniciar sesion");
                }

                response.Value = User[0];
                return response;
            } 
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error", e.Message);
                return response;
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