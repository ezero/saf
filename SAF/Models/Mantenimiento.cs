using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class Mantenimiento
    {
        public int MantenimientoId { get; set; }
        public string MantenimientoDescripcion { get; set; }
        public string MantenimientoTipo { get; set; }
    }
}