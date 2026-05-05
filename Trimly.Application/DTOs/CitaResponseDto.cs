using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimly.Application.DTOs
{
    public class CitaResponseDto
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Barbero { get; set; }
        public string Servicio { get; set; }
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
