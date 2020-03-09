using Microsoft.EntityFrameworkCore;
using System;

namespace DesafioWooza.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PlanoTelefonia> PlanoTelefonia { get; set; }
        public DbSet<PlanoTelefoniaDDD> PlanoTelefoniaDDD { get; set; }
        public DbSet<PlanoTelefoniaTipo> PlanoTelefoniaTipo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanoTelefoniaTipo>().HasData(
                new PlanoTelefoniaTipo
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Controle"

                }, new PlanoTelefoniaTipo
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Pós"
                }, new PlanoTelefoniaTipo
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Pré"
                });

            modelBuilder.Entity<PlanoTelefonia>()
                .HasMany(x => x.DDDs)
                .WithOne(y => y.Plano);
        }
    }
}