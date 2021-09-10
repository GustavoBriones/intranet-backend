using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace BusinessLogic.Data
{
    public class SistemaDbContext : DbContext
    {
        public SistemaDbContext(DbContextOptions<SistemaDbContext> options) : base(options) { }
        public DbSet<Region> Region {get;set;}
        public DbSet<Provincia> Provincia {get;set;}
        public DbSet<Comuna> Comuna {get;set;}
        public DbSet<EncargadoTipo> EncargadoTipo {get;set;}
        public DbSet<Encargado> Encargado {get;set;}
        public DbSet<ZonaGrupoParticipacion> ZonaGrupoParticipacion {get;set;}
        public DbSet<ZonaParticipacion> ZonaParticipacion {get;set;}
        public DbSet<ZonaParticipacionTramo> ZonaParticipacionTramo {get;set;}
        public DbSet<Asociacion> Asociacion { get; set; }
        public DbSet<Comunidad> Comunidad { get; set; }
        public DbSet<DivisionCategoria> DivisionCategoria {get;set;}
        public DbSet<DivisionTipoAsociado> DivisionTipoAsociado {get;set;}
        public DbSet<Division> Division {get;set;}

        public DbSet<Meet> Meet{get;set;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}