using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Repository;
using klinika.Contracts.Service;
using klinika.Data.Dto;
using klinika.Data.Dto.Odeljenje;
using klinika.models;
using Mapster;

namespace klinika.Services
{
    public class OdeljenjeService : IOdeljenjeService
    {
        private readonly IManagerRepository _repositoryManager;
        private ResponseDto _response;
        public OdeljenjeService(IManagerRepository repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreateOdeljenje(OdeljenjeCreateDto odeljenjeDto)
        {
            var odeljenje = odeljenjeDto.Adapt<Odeljenje>();
            _repositoryManager.OdeljenjeRepository.CreateOdeljenje(odeljenje);
            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Creating Category";
            return _response;
        }
        
        public async Task<ResponseDto> UpdateOdeljenje(int odeljenjeId, OdeljenjeUpdateDto odeljenjeDto)
        {
            var odeljenjeCheck = await _repositoryManager.OdeljenjeRepository.GetOdeljenjeById(odeljenjeId);
            if(odeljenjeCheck is null)
            {
                _response.Success = false;
                _response.DisplayMessage = "Category not found in Database";
                return _response;
            }
            var odeljenje = odeljenjeDto.Adapt<Odeljenje>();
            _repositoryManager.OdeljenjeRepository.Update(odeljenje);

            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result > 0) return _response;
            _response.Success = false;
            _response.DisplayMessage = "Error Updating Category";
            return _response;
        }

        public async Task<bool> DeleteOdeljenje(int odeljenjeID)
        {
            var odeljenje = await _repositoryManager.OdeljenjeRepository.GetOdeljenjeById(odeljenjeID);
            if(odeljenje is null)
            {
                return false;
            }
            _repositoryManager.OdeljenjeRepository.DeleteOdeljenje(odeljenje);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<OdeljenjeReadOnlyDto>> GetAllOdeljenja()
        {
            var odeljenja = await _repositoryManager.OdeljenjeRepository.GetAllOdeljenja();
            return odeljenja.Adapt<IEnumerable<OdeljenjeReadOnlyDto>>();
        }

        public async Task<OdeljenjeReadOnlyDto> GetOdeljenjeById(int id)
        {
            var odeljenje = await _repositoryManager.OdeljenjeRepository.GetOdeljenjeById(id);
            return odeljenje.Adapt<OdeljenjeReadOnlyDto>();
        }
    }
}