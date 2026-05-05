using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimly.Application.Contracts;
using Trimly.Domain.Entities;

namespace Trimly.Application.Contracts
{
    public interface IServicioRepository
    {
        Task<Servicio?> GetByIdAsync(int id);
    }
}
