using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimly.Application.DTOs;

namespace Trimly.Application.Contracts
{
    public interface ICitaService
    {
        Task<CitaResponseDto> CrearCitaAsync(CrearCitaDto dto);
    }
}
