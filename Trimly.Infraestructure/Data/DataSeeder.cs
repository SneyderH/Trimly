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
                new Usuario
                {
                    Name = "Sneyder Hoyos",
                    Email = "superadmin@trimly.com",
                    PhoneNumber = "3005715292",
                    Rol = RolUsuario.SuperAdmin
                },
                new Usuario
                {
                    Name = "Harold Bedoya",
                    Email = "haroldb@trimly.com",
                    PhoneNumber = "3001234567",
                    Rol = RolUsuario.AdminBarberia
                },
                new Usuario
                {
                    Name = "Yuri Vilela",
                    Email = "yuriv@trimly.com",
                    PhoneNumber = "3002569878",
                    Rol = RolUsuario.Barbero
                },
                new Usuario
                {
                    Name = "Hermes Garcias",
                    Email = "hermesg@trimly.com",
                    PhoneNumber = "3114785896",
                    Rol = RolUsuario.Cliente
                },
                new Usuario
                {
                    Name = "Davidson Arias",
                    Email = "davidsona@trimly.com",
                    PhoneNumber = "3012569874",
                    Rol = RolUsuario.Cliente
                }
            };
            await context.Usuarios.AddRangeAsync(usuarios);
            await context.SaveChangesAsync();

            // 2. Perfiles
            var perfiles = new List<Perfil>
            {
                new Perfil
                {
                    FotoUrl = "https://via.placeholder.com/150",
                    Bio = "Fundador de Trimly",
                    UsuarioId = usuarios[0].Id
                },
                new Perfil
                {
                    FotoUrl = "https://via.placeholder.com/150",
                    Bio = "Barbero y administrador con 10 años de experiencia",
                    UsuarioId = usuarios[1].Id
                },
                new Perfil
                {
                    FotoUrl = "https://via.placeholder.com/150",
                    Bio = "Especialista en cortes modernos",
                    UsuarioId = usuarios[2].Id
                },
                new Perfil
                {
                    FotoUrl = "https://via.placeholder.com/150",
                    Bio = "",
                    UsuarioId = usuarios[3].Id
                },
                new Perfil
                {
                    FotoUrl = "https://via.placeholder.com/150",
                    Bio = "",
                    UsuarioId = usuarios[3].Id
                }
            };
            await context.Pefiles.AddRangeAsync(perfiles);
            await context.SaveChangesAsync();

            //3. Barberías
            var barberias = new List<Barberia>
            {
                new Barberia
                {
                    Nombre = "Trimly Laureles",
                    Direccion = "Calle 35 # 70-50, Laureles",
                    Telefono = "6044567890",
                    AdminId = usuarios[1].Id
                },
                new Barberia
                {
                    Nombre = "Trimly El Poblado",
                    Direccion = "Calle 10 # 43D-20, El Poblado",
                    Telefono = "6044987654",
                    AdminId = usuarios[1].Id
                }
            };
            await context.Barberias.AddRangeAsync(barberias);
            await context.SaveChangesAsync();

            // 4. Barberos asignados a barberías
            var barberiasBarberos = new List<BarberiasBarberos>
            {
                // Miguel trabaja en ambas barberías
                new BarberiasBarberos { BarberoId = usuarios[1].Id, BarberiaId = barberias[0].Id },
                new BarberiasBarberos { BarberoId = usuarios[1].Id, BarberiaId = barberias[1].Id },
                // Juan trabaja solo en Laureles
                new BarberiasBarberos { BarberoId = usuarios[2].Id, BarberiaId = barberias[0].Id }
            };
            await context.BarberiasBarberos.AddRangeAsync(barberiasBarberos);
            await context.SaveChangesAsync();

            // 5. Servicios
            var servicios = new List<Servicio>
            {
                new Servicio { Name = "Corte clásico",       Duration = TimeSpan.FromMinutes(30), Price = 25000m },
                new Servicio { Name = "Corte + barba",       Duration = TimeSpan.FromMinutes(60), Price = 35000m },
                new Servicio { Name = "Arreglo de barba",    Duration = TimeSpan.FromMinutes(20), Price = 15000m }
            };
            await context.Servicios.AddRangeAsync(servicios);
            await context.SaveChangesAsync();

            // 6. Citas
            var citas = new List<Cita>
            {
                new Cita
                {
                    FechaHora = DateTime.UtcNow.AddDays(1),
                    Estado    = EstadoCita.Pendiente,
                    ClienteId    = usuarios[3].Id,
                    BarberoId  = usuarios[1].Id,
                    ServiceId = servicios[0].Id
                },
                new Cita
                {
                    FechaHora = DateTime.UtcNow.AddDays(1).AddHours(1),
                    Estado    = EstadoCita.Confirmada,
                    ClienteId    = usuarios[4].Id,
                    BarberoId  = usuarios[2].Id,
                    ServiceId = servicios[1].Id
                },
                new Cita
                {
                    FechaHora = DateTime.UtcNow.AddDays(3).AddHours(1),
                    Estado    = EstadoCita.Completada,
                    ClienteId    = usuarios[3].Id,
                    BarberoId  = usuarios[2].Id,
                    ServiceId = servicios[2].Id
                },
            };
            await context.Citas.AddRangeAsync(citas);
            await context.SaveChangesAsync();
        }
    }
}
