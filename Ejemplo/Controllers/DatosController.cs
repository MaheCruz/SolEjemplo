using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;  // Asegúrate de usar este namespace para Web API
using System.Data.SqlClient;
using System.Configuration;

namespace Ejemplo.Controllers
{
    public class DatosController : ApiController
    {
        // Acción para recibir los datos del ESP32
        [System.Web.Http.HttpPost]  // Especifica el atributo HttpPost de Web API
        public IHttpActionResult RecibirDatos([FromBody] Datos datos)
        {
            if (datos == null)
            {
                return BadRequest("Datos no válidos");
            }

            // Guardar los datos en la base de datos SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DatosSensor (Temperatura) VALUES (@Temperatura)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Temperatura", datos.Temperatura);
                    cmd.ExecuteNonQuery();
                }
            }


            return Ok("Datos recibidos correctamente");
        }

        public class Datos
        {
            public float Temperatura { get; set; }
        }
    }
}

