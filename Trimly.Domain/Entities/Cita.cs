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
        public int ClienteId { get; set; }
        public int BarberoId { get; set; }
        public int ServiceId { get; set; }
        public Usuario? Cliente { get; set; }
        public Usuario? Barbero { get; set; }
        public Servicio? Servicio { get; set; }

    }
}
