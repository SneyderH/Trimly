using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimly.Domain.Entities
{
    public class Perfil
    {
        public int Id { get; set; }
        public string? FotoUrl { get; set; }
        public string? Bio { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
