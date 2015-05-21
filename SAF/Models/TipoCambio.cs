using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class TipoCambio
    {
        public int TipoCambioId { get; set; }
        public virtual Gestion GestionId { get; set; }
        public virtual Moneda MonedaId { get; set; }
    }
}