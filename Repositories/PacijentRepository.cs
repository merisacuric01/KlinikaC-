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
    public class PacijentRepository : BaseRepository<Pacijent>, IPacijentRepository
    {
        public PacijentRepository(DataContext context) : base(context) { }

        public void CreatePacijent(Pacijent pacijent) => Create(pacijent);
        public void DeletePacijent(Pacijent pacijent) => Delete(pacijent); 
        public void UpdatePacijent(Pacijent pacijent) => Update(pacijent);

        public async Task<IEnumerable<Pacijent>> GetAllPacijenti()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Pacijent> GetPacijentById(int id)
        {
            return await FindByCondition(pacijent => pacijent.PacijentID == id).FirstOrDefaultAsync();
        }
    }
}