using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimly.Domain.Enums;

namespace Trimly.Domain.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public EstadoCita Estado { get; set; }
        public int UserId { get; set; }
        public int BarberId { get; set; }
        public int ServiceId { get; set; }

        public Usuario Usuario { get; set; }
        public Barbero Barbero { get; set; }
        public Servicio Servicio { get; set; }

    }
}
