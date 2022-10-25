using EFPeliculas.Entidades;
using EFPeliculas.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


public class ApliccationDbContext : DbContext
    {

        public ApliccationDbContext(DbContextOptions<ApliccationDbContext> options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");


        }
        //para modificar tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeeDingModuloConsulta.Seed(modelBuilder);
        }
        //agregar como dbset
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaCine> SalaCines { get; set; }
        public DbSet<PeliculaActor> PeliculaActores { get; set; }
    }

