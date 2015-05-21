using Microsoft.AspNet.Identity.EntityFramework;

namespace SAF.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<SAF.Models.Mantenimiento> Mantenimientoes { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Apreciacion> Apreciacions { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Bien> Biens { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Cargo> Cargoes { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Departamento> Departamentoes { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Depreciacion> Depreciacions { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.DetalleApreciacion> DetalleApreciacions { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.DetalleDepreciacion> DetalleDepreciacions { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Empleado> Empleadoes { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Gestion> Gestions { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.TipoCambio> TipoCambios { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.TipoBien> TipoBiens { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Revision> Revisions { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Responsable> Responsables { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.Moneda> Monedas { get; set; }

        public System.Data.Entity.DbSet<SAF.Models.MantenimientoBien> MantenimientoBiens { get; set; }
    }
}