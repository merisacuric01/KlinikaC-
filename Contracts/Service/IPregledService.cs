using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Data.Dto.Pregled;
using klinika.Data.Dto;

namespace klinika.Contracts.Service
{
    public interface IPregledService
    {
        Task<IEnumerable<PregledReadOnlyDto>> GetAllPreglede();
        Task<PregledReadOnlyDto> GetPregledById(int id);
        Task<ResponseDto> CreatePregled(PregledCreateDto pregledDto);
        Task<ResponseDto> UpdatePregled(int pregledId, PregledUpdateDto pregledDto);
        Task<bool> DeletePregled(int pregledID);
    }
}