using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class DetalleDepreciacion
    {
        public int DetalleDepreciacionId { get; set; }
        public virtual Depreciacion DepreciacionId { get; set; }
        public virtual Gestion GestionId { get; set; }
        public virtual TipoBien TipoBienId { get; set; }
    }
}