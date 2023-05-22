using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Repository;
using klinika.Contracts.Service;
using klinika.Data.Dto;
using klinika.Data.Dto.Pregled;
using klinika.models;
using Mapster;

namespace klinika.Services
{
    public class PregledService : IPregledService
    {
        private readonly IManagerRepository _repositoryManager;
        private ResponseDto _response;
        public PregledService(IManagerRepository repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreatePregled(PregledCreateDto pregledDto)
        {
            var pregled = pregledDto.Adapt<Pregled>();
            _repositoryManager.PregledRepository.CreatePregled(pregled);
            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Creating Product";
            return _response;
        }
        
        public async Task<ResponseDto> UpdatePregled(int pregledId, PregledUpdateDto pregledDto)
        {
            var pregledCheck = await _repositoryManager.PregledRepository.GetPregledById(pregledId);
            if(pregledCheck is null)
            {
                _response.Success = false;
                _response.DisplayMessage = "Product not found in Database";
                return _response;
            }
            var pregled = pregledDto.Adapt<Pregled>();
            _repositoryManager.PregledRepository.Update(pregled);

            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Updating Product";
            return _response;
        }

        public async Task<bool> DeletePregled(int pregledID)
        {
            var pregled = await _repositoryManager.PregledRepository.GetPregledById(pregledID);
            if(pregled is null)
            {
                return false;
            }
            _repositoryManager.PregledRepository.DeletePregled(pregled);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<PregledReadOnlyDto>> GetAllPreglede()
        {
            var pregledi = await _repositoryManager.PregledRepository.GetAllPregledi();
            return pregledi.Adapt<IEnumerable<PregledReadOnlyDto>>();
        }

        public async Task<PregledReadOnlyDto> GetPregledById(int id)
        {
            var pregled = await _repositoryManager.PregledRepository.GetPregledById(id);
            return pregled.Adapt<PregledReadOnlyDto>();
        }
    }
}