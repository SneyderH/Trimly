using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trimly.Domain.Entities;
using Trimly.Domain.Enums;

namespace Trimly.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(TrimlyDbContext context)
        {
            if (await context.Usuarios.AnyAsync()) return;

            // 1. Usuarios
            var usuarios = new List<Usuario>
            {
                new Usuario { Name = "Sneyder Hoyos", Email = "sneyderhl2002@gmail.com", PhoneNumber = "3005715292"},
                new Usuario { Name = "Hermes Garcia", Email = "hermestino29@gmail.com", PhoneNumber = "3014589865"},
                new Usuario { Name = "Davidson Arias", Email = "dat2002@gmail.com", PhoneNumber = "3025478956"}
            };
            await context.Usuarios.AddRangeAsync(usuarios);
            await context.SaveChangesAsync();

            // 2. Barberos
            var barberos = new List<Barbero>
            {
                new Barbero { Name = "Harold Bedoya" },
                new Barbero { Name = "Yuri Vilela"  }
            };
            await context.Barberos.AddRangeAsync(barberos);
            await context.SaveChangesAsync();

            // 3. Servicios
            var servicios = new List<Servicio>
            {
                new Servicio { Name = "Corte clásico",       Duration = TimeSpan.FromMinutes(30), Price = 25000m },
                new Servicio { Name = "Corte + barba",       Duration = TimeSpan.FromMinutes(60), Price = 35000m },
                new Servicio { Name = "Arreglo de barba",    Duration = TimeSpan.FromMinutes(20), Price = 15000m }
            };
            await context.Servicios.AddRangeAsync(servicios);
            await context.SaveChangesAsync();

            // 4. Citas (referenciando los IDs generados)
            var citas = new List<Cita>
            {
                new Cita
                {
                    FechaHora = DateTime.UtcNow.AddDays(1),
                    Estado    = EstadoCita.Pendiente,
                    UserId    = usuarios[0].Id,
                    BarberId  = barberos[0].Id,
                    ServiceId = servicios[0].Id
                },
                new Cita
                {
                    FechaHora = DateTime.UtcNow.AddDays(2),
                    Estado    = EstadoCita.Confirmada,
                    UserId    = usuarios[1].Id,
                    BarberId  = barberos[1].Id,
                    ServiceId = servicios[1].Id
                },
                new Cita
                {
                    FechaHora = DateTime.UtcNow.AddDays(-3),
                    Estado    = EstadoCita.Completada,
                    UserId    = usuarios[2].Id,
                    BarberId  = barberos[0].Id,
                    ServiceId = servicios[2].Id
                },
                new Cita
                {
                    FechaHora = DateTime.UtcNow.AddDays(-1),
                    Estado    = EstadoCita.Cancelada,
                    UserId    = usuarios[0].Id,
                    BarberId  = barberos[1].Id,
                    ServiceId = servicios[1].Id
                }
            };
            await context.Citas.AddRangeAsync(citas);
            await context.SaveChangesAsync();
        }
    }
}
