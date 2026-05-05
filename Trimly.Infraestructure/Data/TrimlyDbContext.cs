using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trimly.Domain.Entities;

namespace Trimly.Infrastructure.Data
{
    public class TrimlyDbContext : DbContext
    {
        public TrimlyDbContext(DbContextOptions<TrimlyDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Barbero> Barberos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                // Le dices explícitamente a EF cuál es la FK de cada relación
                entity.HasOne(c => c.Barbero)
                      .WithMany(b => b.Citas)
                      .HasForeignKey(c => c.BarberId);

                entity.HasOne(c => c.Usuario)
                      .WithMany(u => u.Citas)
                      .HasForeignKey(c => c.UserId);

                entity.HasOne(c => c.Servicio)
                      .WithMany(s => s.Citas)
                      .HasForeignKey(c => c.ServiceId);
            });
        }
    }
}
