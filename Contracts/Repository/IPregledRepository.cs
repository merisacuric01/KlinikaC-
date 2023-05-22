using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.models;

namespace klinika.Contracts.Repository
{
    public interface IPregledRepository : IRepositoryBase<Pregled>
    {
        Task<IEnumerable<Pregled>> GetAllPregledi();
        Task<Pregled> GetPregledById(int id);
        void CreatePregled(Pregled pregled);
        void DeletePregled(Pregled pregled);
        void UpdatePregled(Pregled pregled);
    }
}