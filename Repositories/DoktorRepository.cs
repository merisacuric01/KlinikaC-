using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Repository;
using klinika.Data;
using klinika.models;
using Microsoft.EntityFrameworkCore;

namespace klinika.Repositories
{
    public class DoktorRepository : BaseRepository<Doktor>, IDoktorRepository
    {
        public DoktorRepository(DataContext context) : base(context) { }

        public void CreateDoktor(Doktor doktor) => Create(doktor);
        public void DeleteDoktor(Doktor doktor) => Delete(doktor); 
        public void UpdateDoktor(Doktor doktor) => Update(doktor);

        public async Task<IEnumerable<Doktor>> GetAllDoktori()
        {
            return await FindAll()
                .Include(o => o.Odeljenje)
                .ToListAsync();
        }

        public async Task<Doktor> GetDoktorById(int id)
        {
            return await FindByCondition(doktor => doktor.DoktorID == id)
                .Include(o => o.Odeljenje)
                .FirstOrDefaultAsync();
        }
    }
}