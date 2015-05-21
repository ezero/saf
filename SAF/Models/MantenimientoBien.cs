using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class MantenimientoBien
    {
        public int MantenimientoBienId { get; set; }
        public string MantenimientoDescripcion { get; set; }
        public virtual TipoBien TipoBienId { get; set; }
        public virtual Mantenimiento MantenimientoID { get; set; }
    }
}