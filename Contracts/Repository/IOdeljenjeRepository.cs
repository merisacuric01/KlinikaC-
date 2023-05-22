using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.models;

namespace klinika.Contracts.Repository
{
    public interface IOdeljenjeRepository : IRepositoryBase<Odeljenje>
    {
        Task<IEnumerable<Odeljenje>> GetAllOdeljenja();
        Task<Odeljenje> GetOdeljenjeById(int id);
        void CreateOdeljenje(Odeljenje odeljenje);
        void DeleteOdeljenje(Odeljenje odeljenje);
        void UpdateOdeljenje(Odeljenje odeljenje);
    }
}