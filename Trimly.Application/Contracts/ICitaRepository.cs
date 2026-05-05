using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimly.Domain.Entities;

namespace Trimly.Application.Contracts
{
    public interface ICitaRepository
    {
        Task<List<Cita>> GetByBarberoAsync(int  barberId);
        Task AddAsync(Cita cita);
        Task<Cita?> GetByIdWithDetailsAsync(int id);
    }
}
