using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimly.Application.Contracts;
using Trimly.Domain.Entities;
using Trimly.Infrastructure.Data;

namespace Trimly.Infrastructure.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly TrimlyDbContext _context;

        public ServicioRepository(TrimlyDbContext context) 
        { 
            _context = context;        
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

    }
}
