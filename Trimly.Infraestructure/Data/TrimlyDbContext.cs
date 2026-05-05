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
        public DbSet<Perfil> Pefiles { get; set; }
        public DbSet<Barberia> Barberias { get; set; }
        public DbSet<BarberiasBarberos> BarberiasBarberos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Perfil)
                .HasForeignKey<Perfil>(p => p.UsuarioId);
            
            modelBuilder.Entity<Barberia>()
                .HasOne(b => b.Admin)
                .WithMany()
                .HasForeignKey(b => b.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BarberiasBarberos>()
                .HasKey(bb => new { bb.BarberoId, bb.BarberiaId });

            modelBuilder.Entity<BarberiasBarberos>()
                .HasOne(bb => bb.Barbero)
                .WithMany(u => u.BarberiasBarberos)
                .HasForeignKey(bb => bb.BarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BarberiasBarberos>()
                .HasOne(bb => bb.Barberia)
                .WithMany(u => u.BarberiasBarberos)
                .HasForeignKey(bb => bb.BarberiaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Cliente)
                .WithMany(u => u.CitasComoCliente)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Barbero)
                .WithMany(u => u.CitasComoBarbero)
                .HasForeignKey(c => c.BarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Servicio)
                .WithMany(u => u.Citas)
                .HasForeignKey(c => c.ServiceId);
        }
    }
}
