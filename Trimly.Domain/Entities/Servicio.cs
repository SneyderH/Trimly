using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimly.Domain.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }

        public ICollection<Cita> Citas { get; set; }
    }
}
