using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SG_de_Productos.BaseDatos
{
    public class ConnectionBD
    {
        /* NOTA MUCHO MUY IMPORTANTE. Crear BaseDatos Productos con Tabla Producto en el SQL Server */

        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader reader;
        protected SqlConnection ConnectionSql { get; set; }

        protected string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Productos;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";


        public ConnectionBD()
        {
            this.ConnectionSql = new SqlConnection(ConnectionString);
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                if (ConnectionSql.State == ConnectionState.Broken ||
                    ConnectionSql.State == ConnectionState.Closed)
                {
                    ConnectionSql.Open();
                }

                return this.ConnectionSql;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de abrir la conexion", ex);
            }
        }

        public SqlConnection CloseConnection()
        {
            try
            {
                if (ConnectionSql.State == ConnectionState.Open)
                {
                    ConnectionSql.Close();
                }
                return this.ConnectionSql;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de cerrar la conexion", ex);
            }
        }

    }
}
