using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;

namespace Datos.BaseDatos
{
    public class ExamenContext : DbContext
    {
        public ExamenContext() : base("name=Examen2Rad")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Utilizamos using System.Data.Entity.ModelConfiguration.Conventions;
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //No queremos Nombres en plural
        }

        public DbSet<Clientes> Clientes { get; set;}
        public DbSet<Teatros> Teatros { get; set; }
        public DbSet<Reserva> reservas { get; set; }

    }
}
