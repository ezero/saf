using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class TipoBien
    {
        public int TipoBienID { get; set; }
        public string TipoBienDescripcion { get; set; }
        public virtual Categoria TipoBienCategoria { get; set; }
    }
}