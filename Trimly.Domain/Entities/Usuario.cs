using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimly.Domain.Enums;

namespace Trimly.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public RolUsuario Rol { get; set; }
        public Perfil? Perfil { get; set; }
        public ICollection<Cita>? CitasComoCliente { get; set; }
        public ICollection<Cita>? CitasComoBarbero { get; set; }
        public ICollection<BarberiasBarberos>? BarberiasBarberos { get; set; }

    }
}
