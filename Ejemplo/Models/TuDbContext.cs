using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;  // Namespace para Entity Framework

namespace Ejemplo.Models  // Usa un namespace adecuado para tu proyecto
{
    public class TuDbContext : DbContext
    {
        // Constructor: usa la cadena de conexión definida en Web.config
        public TuDbContext() : base("name=MiConexion")
        {
        }

        // Define las tablas o entidades que quieres mapear
        public DbSet<DatosSensor> DatosSensor { get; set; }  // Cambia 'DatosSensor' por tu nombre de tabla/entidad
    }

    // Define la clase 'DatosSensor' que representa la estructura de tu tabla
    public class DatosSensor
    {
        public int Id { get; set; }
        public float Temperatura { get; set; }
        public DateTime Fecha { get; set; }
    }
}
