using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimly.Domain.Entities
{
    public class Barbero
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Cita> Citas { get; set; }
    }
}
