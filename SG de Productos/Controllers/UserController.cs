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
            ObjectResult data = new ObjectResult(null);

            try
            {
                var fndUser = indexSP.User.GetUser(usuario);

                if (fndUser.Value != null)
                {
                    throw new Exception("Usuario existente. Intentelo nuevamente");
                }

                var result = indexSP.User.CreateUser(usuario);

                data.Value = result;
                return data;
            }
            catch(Exception e)
            {
                data.StatusCode = 400;
                data.Value = e.Message;
                return data;
            }
        }
    }
}