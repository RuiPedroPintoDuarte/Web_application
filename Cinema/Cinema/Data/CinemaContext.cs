using Cinema.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Data
{
    public class CinemaContext : IdentityDbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<Historico>() .HasKey(o => new { o.FilmeId, o.PerfilId});
            modelbuilder.Entity<Horario>().HasKey(o => new { o.SalaId});
            modelbuilder.Entity<Bilhete>().HasKey(o => new { o.FilmeId, o.HorarioId });
            base.OnModelCreating(modelbuilder);
        }

        public DbSet<Perfil> Perfils { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Cinema.Models.Sala> Sala { get; set; }

        public DbSet<Horario> Horario { get; set; }

        public DbSet<Cinema.Models.Historico> Historico { get; set; }

        public DbSet<Cinema.Models.Bilhete> Bilhete { get; set; }
    }
}
