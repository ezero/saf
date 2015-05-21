using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class Responsable
    {
        public int ResponsableId { get; set; }
        public virtual Bien BienId { get; set; }
        public virtual Empleado EmpleadoId { get; set; }
    }
}