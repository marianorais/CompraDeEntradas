using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Compra_de_Entradas.Models;

namespace Compra_de_Entradas
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> Options)//
           : base(Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Peliculas>(entity => {
               entity.ToTable("Peliculas");
               entity.HasKey(entity => entity.Id_pelicula)
                   .HasName("Id_pelicula");

            });
            builder.Entity<Usuarios>(entity => {
                entity.ToTable("Usuarios");
                entity.HasKey(entity => entity.Id_usuario)
                   .HasName("Id_usuario");
            });

            builder.Entity<Entradas>(entity => {
                entity.ToTable("Entradas");
                entity.HasKey(entity => entity.Id_entrada);
                //entity.Property(entity => entity.Id_pelicula).HasColumnName("Id_pelicula");
               entity.HasOne(b => b.Peliculas).WithOne(ab=>ab.Entradas)
                   .HasForeignKey<Peliculas>(c => c.Id_pelicula);
                entity.HasOne(eb => eb.Usuarios).WithMany(ab => ab.Entrada)
                .HasForeignKey(ep => ep.Id_usuario);
            });
            builder.Entity<Movie_fav>(entity => {
                entity.ToTable("Movie_fav");
                entity.HasKey(entity => entity.Id_pelicula)
                   .HasName("Id_pelicula");
                entity.HasOne(eb => eb.Usuarios).WithMany(ab => ab.MovieFav)
                .HasForeignKey(ep => ep.Id_usuario).IsRequired(false);
            });
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Entradas> Entradas { get; set; }
        public DbSet<Movie_fav> Movie_fav { get; set; }
    }
}



