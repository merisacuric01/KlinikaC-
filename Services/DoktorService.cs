using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Service;
using klinika.Data.Dto;
using klinika.Data.Dto.Doktor;
using klinika.models;
using Mapster;
using klinika.Contracts.Repository;

namespace klinika.Services
{
    public class DoktorService : IDoktorService
    {
        private readonly IManagerRepository _repositoryManager;
        private ResponseDto _response;
        public DoktorService(IManagerRepository repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreateDoktor(DoktorCreateDto doktorDto)
        {
            var doktor = doktorDto.Adapt<Doktor>();
            _repositoryManager.DoktorRepository.CreateDoktor(doktor);
            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Creating Category";
            return _response;
        }
        
        public async Task<ResponseDto> UpdateDoktor(int doktorId, DoktorUpdateDto doktorDto)
        {
            var doktorCheck = await _repositoryManager.DoktorRepository.GetDoktorById(doktorId);
            if(doktorCheck is null)
            {
                _response.Success = false;
                _response.DisplayMessage = "Category not found in Database";
                return _response;
            }
            var doktor = doktorDto.Adapt<Doktor>();
            _repositoryManager.DoktorRepository.Update(doktor);

            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Updating Category";
            return _response;
        }

        public async Task<bool> DeleteDoktor(int doktorID)
        {
            var doktor = await _repositoryManager.DoktorRepository.GetDoktorById(doktorID);
            if(doktor is null)
            {
                return false;
            }
            _repositoryManager.DoktorRepository.DeleteDoktor(doktor);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<DoktorReadOnlyDto>> GetAllDoktore()
        {
            var doktore = await _repositoryManager.DoktorRepository.GetAllDoktori();
            return doktore.Adapt<IEnumerable<DoktorReadOnlyDto>>();
        }

        public async Task<DoktorReadOnlyDto> GetDoktorById(int id)
        {
            var doktor = await _repositoryManager.DoktorRepository.GetDoktorById(id);
            return doktor.Adapt<DoktorReadOnlyDto>();
        }
    }
}