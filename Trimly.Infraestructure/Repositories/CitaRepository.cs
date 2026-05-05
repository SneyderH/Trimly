using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trimly.Application.Contracts;
using Trimly.Domain.Entities;
using Trimly.Infrastructure.Data;

namespace Trimly.Infrastructure.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly TrimlyDbContext _context;

        public CitaRepository(TrimlyDbContext context)
        { 
            _context = context;
        }

        public async Task<List<Cita>> GetByBarberoAsync(int barberId)
        {
            var ahora = DateTime.Now;

            return await _context.Citas
                .Include(c => c.Servicio)
                .Where(c => c.BarberoId == barberId &&
                            c.Estado != Domain.Enums.EstadoCita.Cancelada &&
                            c.FechaHora > ahora)
                .ToListAsync();
        }

        public async Task AddAsync(Cita cita)
        {
            await _context.Citas .AddAsync(cita);
            await _context.SaveChangesAsync();
        }

        public async Task<Cita?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Citas
                .Include (c => c.Cliente)
                .Include (c => c.Barbero)
                .Include (c => c.Servicio)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
