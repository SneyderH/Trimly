using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimly.Application.DTOs
{
    public class CrearCitaDto
    {
        public DateTime FechaHora { get; set; }
        public int UserId { get; set; }
        public int BarberId { get; set; }
        public int ServiceId { get; set; }
    }
}
