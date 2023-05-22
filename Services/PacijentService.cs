using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Repository;
using klinika.Contracts.Service;
using klinika.Data.Dto;
using klinika.Data.Dto.Pacijent;
using klinika.models;
using Mapster;

namespace klinika.Services
{
        public class PacijentService : IPacijentService
    {
        private readonly IManagerRepository _repositoryManager;
        private ResponseDto _response;
        public PacijentService(IManagerRepository repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreatePacijent(PacijentCreateDto pacijentDto)
        {
            var pacijent = pacijentDto.Adapt<Pacijent>();
            _repositoryManager.PacijentRepository.CreatePacijent(pacijent);
            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Creating Pacijent";
            return _response;
        }
        
        public async Task<ResponseDto> UpdatePacijent(int pacijentId, PacijentUpdateDto pacijentDto)
        {
            var pacijentCheck = await _repositoryManager.PacijentRepository.GetPacijentById(pacijentId);
            if(pacijentCheck is null)
            {
                _response.Success = false;
                _response.DisplayMessage = "Category not found in Database";
                return _response;
            }
            var pacijent = pacijentDto.Adapt<Pacijent>();
            _repositoryManager.PacijentRepository.Update(pacijent);

            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Updating Category";
            return _response;
        }

        public async Task<bool> DeletePacijent(int pacijentID)
        {
            var pacijent = await _repositoryManager.PacijentRepository.GetPacijentById(pacijentID);
            if(pacijent is null)
            {
                return false;
            }
            _repositoryManager.PacijentRepository.DeletePacijent(pacijent);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<PacijentReadOnlyDto>> GetAllPacijente()
        {
            var pacijenti = await _repositoryManager.PacijentRepository.GetAllPacijenti();
            return pacijenti.Adapt<IEnumerable<PacijentReadOnlyDto>>();
        }

        public async Task<PacijentReadOnlyDto> GetPacijentById(int id)
        {
            var pacijent = await _repositoryManager.PacijentRepository.GetPacijentById(id);
            return pacijent.Adapt<PacijentReadOnlyDto>();
        }
    }
}