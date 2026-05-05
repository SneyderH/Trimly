using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimly.Domain.Entities
{
    public class Barberia
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int AdminId { get; set; }
        public Usuario? Admin { get; set; }
        public ICollection<BarberiasBarberos>? BarberiasBarberos { get; set; }
    }
}
