//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Activosfijos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalledepreciacion
    {
        public int iddetalledepreciacion { get; set; }
        public int iddepreciacion { get; set; }
        public int idgestion { get; set; }
        public int idtipobien { get; set; }
    
        public virtual depreciacion depreciacion { get; set; }
        public virtual gestion gestion { get; set; }
        public virtual tipobien tipobien { get; set; }
    }
}
