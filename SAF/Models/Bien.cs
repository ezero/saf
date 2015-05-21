using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class Bien
    {
        public int BienId { get; set; }
        public string BienNombre { get; set; }
        public float BienPrecioCompra { get; set; }
        public float BienPrecioActual { get; set; }
        public virtual IngresoEgreso IngresoId { get; set; }
        public virtual IngresoEgreso EgresoId { get; set; }
        public virtual TipoBien TipoBienId { get; set; }
        public DateTime BienFechaIngreso { get; set; }
        public DateTime BienFechaEgreso { get; set; }
    }
}