using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class DetalleApreciacion
    {
        public int DetalleApreciacionId { get; set; }
        public virtual Apreciacion ApreciacionId { get; set; }
        public virtual Gestion GestionId { get; set; }
        public virtual TipoBien TipoBienId { get; set; }

    }
}