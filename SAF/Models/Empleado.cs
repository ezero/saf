using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAF.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public virtual Cargo CargoId { get; set; }
        public virtual Departamento DepartamentoId { get; set; }
        public string EmpleadoNombre { get; set; }
        public int EmpleadoCi { get; set; }
        public string EmpleadoDireccion { get; set; }
    }
}