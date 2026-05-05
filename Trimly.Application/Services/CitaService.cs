using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimly.Domain.Entities;
using Trimly.Application.Contracts;
using Trimly.Application.DTOs;
using Trimly.Domain.Entities;
using Trimly.Domain.Enums;


namespace Trimly.Application.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IServicioRepository _servicioRepository;

        public CitaService(ICitaRepository citaRepository, IServicioRepository servicioRepository)
        {
            _citaRepository = citaRepository;
            _servicioRepository = servicioRepository;
        }

        public async Task<CitaResponseDto> CrearCitaAsync(CrearCitaDto dto)
        {
            // Conversión a UTC
            //var fechaHoraUtc = dto.FechaHora.Kind == DateTimeKind.Utc
            //    ? dto.FechaHora
            //    : dto.FechaHora.ToUniversalTime();

            // 1. Verificar que el servicio solicitado existe
            var servicio = await _servicioRepository.GetByIdAsync(dto.ServiceId)
                ?? throw new Exception($"El servicio con ID {dto.ServiceId} no existe.");

            // 2. Calcular la franja horaria de la nueva cita
            var nuevaInicio = dto.FechaHora;
            var nuevaFin = dto.FechaHora + servicio.Duration;

            // 3. Obtener citas activas del barbero
            var citasDelBarbero = await _citaRepository.GetByBarberoAsync(dto.BarberId);

            // 4. Validar choques de horario
            var hayChoque = citasDelBarbero.Any(c =>
            {
                var existenteInicio = c.FechaHora;
                var existenteFin = c.FechaHora + c.Servicio!.Duration;

                return nuevaInicio < existenteFin && nuevaFin > existenteInicio;
            });

            if (hayChoque)
                throw new Exception(
                    $"El barbero no está disponible de {nuevaInicio:HH:mm} a {nuevaFin:HH:mm}. " +
                    $"Por favor elige otro horario.");

            // 5. Crear y guardar la cita
            var cita = new Cita
            {
                FechaHora = dto.FechaHora,
                Estado = EstadoCita.Pendiente,
                ClienteId = dto.UserId,
                BarberoId = dto.BarberId,
                ServiceId = dto.ServiceId
            };

            await _citaRepository.AddAsync(cita);

            var citaCompleta = await _citaRepository.GetByIdWithDetailsAsync(cita.Id)
                ?? throw new Exception("Error al recuperar la cita recién creada.");

            // 6. Retornar respuesta
            return new CitaResponseDto
            {
                Id = citaCompleta.Id,
                FechaHora = citaCompleta.FechaHora,
                FechaHoraFin = nuevaFin,
                Estado = citaCompleta.Estado.ToString(),
                Usuario = citaCompleta.Cliente?.Name,
                Barbero = citaCompleta.Barbero?.Name,
                Servicio = citaCompleta.Servicio?.Name,
                Precio = citaCompleta.Servicio!.Price,
                DuracionMinutos = (int)citaCompleta.Servicio.Duration.TotalMinutes
            };
        }


    }

}
