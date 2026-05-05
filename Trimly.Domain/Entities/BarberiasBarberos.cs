using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimly.Domain.Entities
{
    public class BarberiasBarberos
    {
        public int BarberoId { get; set; }
        public int BarberiaId { get; set; }
        public Usuario? Barbero { get; set; }
        public Barberia? Barberia { get; set; }
    }
}
