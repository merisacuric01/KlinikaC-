using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Data.Dto.Odeljenje;
using klinika.Data.Dto;

namespace klinika.Contracts.Service
{
    public interface IOdeljenjeService
    {
        Task<IEnumerable<OdeljenjeReadOnlyDto>> GetAllOdeljenja();
        Task<OdeljenjeReadOnlyDto> GetOdeljenjeById(int id);
        Task<ResponseDto> CreateOdeljenje(OdeljenjeCreateDto odeljenjeDto);
        Task<ResponseDto> UpdateOdeljenje(int odeljenjeId, OdeljenjeUpdateDto odeljenjeDto);
        Task<bool> DeleteOdeljenje(int odeljenjeID);
    }
}