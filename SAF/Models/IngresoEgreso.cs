using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class IngresoEgreso
    {
        public int IngresoEgresoId { get; set; }
        public int IngresoTipo { get; set; }
        public int EgresoTipo { get; set; }
    }
}