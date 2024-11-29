using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.SqlClient;
using Ejemplo.Models; // Asegúrate de que el namespace esté correcto

namespace Ejemplo.Controllers
{
    public class HomeController : Controller
    {
        private TuDbContext db = new TuDbContext();

        public ActionResult Index()
        {
            try
            {
                // Intentar obtener los datos de la base de datos
                var ultimoDato = db.DatosSensor.OrderByDescending(d => d.Fecha).FirstOrDefault();

                if (ultimoDato != null)
                {
                    // Si los datos están disponibles, asignarlos a ViewBag
                    ViewBag.Temperatura = ultimoDato.Temperatura;
                    ViewBag.EstadoVentilador = ultimoDato.Temperatura > 25 ? "Encendido" : "Apagado";
                }
                else
                {
                    // Si no hay datos, informar
                    ViewBag.Temperatura = "No hay datos disponibles";
                    ViewBag.EstadoVentilador = "No disponible";
                }
            }
            catch (SqlException ex)
            {
                // Mostrar el mensaje de error general
                ViewBag.Error = "No se pudo establecer la conexión con la base de datos. Detalles: " + ex.Message;

                // Agregar detalles más específicos sobre el error para depuración (esto imprimirá en la consola de depuración)
                System.Diagnostics.Debug.WriteLine("Detalles del error de SQL: " + ex.ToString());
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro tipo de error general
                ViewBag.Error = "Ocurrió un error inesperado: " + ex.Message;

                // Agregar detalles del error general para depuración
                System.Diagnostics.Debug.WriteLine("Detalles del error: " + ex.ToString());
            }

            return View();
        }


    }
}
