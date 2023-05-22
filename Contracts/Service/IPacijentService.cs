using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Data.Dto.Pacijent;
using klinika.Data.Dto;

namespace klinika.Contracts.Service
{
    public interface IPacijentService
    {
        Task<IEnumerable<PacijentReadOnlyDto>> GetAllPacijente();
        Task<PacijentReadOnlyDto> GetPacijentById(int id);
        Task<ResponseDto> CreatePacijent(PacijentCreateDto pacijentDto);
        Task<ResponseDto> UpdatePacijent(int pacijentId, PacijentUpdateDto pacijentDto);
        Task<bool> DeletePacijent(int pacijentID);
    }
}