using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.models;

namespace klinika.Contracts.Repository
{
    public interface IPacijentRepository : IRepositoryBase<Pacijent>
    {
        Task<IEnumerable<Pacijent>> GetAllPacijenti();
        Task<Pacijent> GetPacijentById(int id);
        void CreatePacijent(Pacijent pacijent);
        void DeletePacijent(Pacijent pacijent);
        void UpdatePacijent(Pacijent pacijent);
    }
}