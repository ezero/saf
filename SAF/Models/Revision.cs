using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class Revision
    {
        public int RevisionId { get; set; }
        public virtual Bien BienId { get; set; }
        public virtual Gestion GestionId { get; set; }
        public virtual Empleado EmpleadoId { get; set; }
        public char RevisionTipo { get; set; }
    }
}