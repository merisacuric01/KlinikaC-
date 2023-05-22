using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.models;

namespace klinika.Contracts.Repository
{
    public interface IDoktorRepository : IRepositoryBase<Doktor>
    {
        Task<IEnumerable<Doktor>> GetAllDoktori();
        Task<Doktor> GetDoktorById(int id);
        void CreateDoktor(Doktor doktor);
        void DeleteDoktor(Doktor doktor);
        void UpdateDoktor(Doktor doktor);
    }
}