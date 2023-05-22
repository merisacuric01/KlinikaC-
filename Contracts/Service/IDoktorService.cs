using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Data.Dto.Doktor;
using klinika.Data.Dto;

namespace klinika.Contracts.Service
{
    public interface IDoktorService
    {
        Task<IEnumerable<DoktorReadOnlyDto>> GetAllDoktore();
        Task<DoktorReadOnlyDto> GetDoktorById(int id);
        Task<ResponseDto> CreateDoktor(DoktorCreateDto doktorDto);
        Task<ResponseDto> UpdateDoktor(int doktorId, DoktorUpdateDto doktorDto);
        Task<bool> DeleteDoktor(int doktorID);
    }
}