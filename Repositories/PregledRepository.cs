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
    public class PregledRepository : BaseRepository<Pregled>, IPregledRepository
    {
        public PregledRepository(DataContext context) : base(context) { }

        public void CreatePregled(Pregled pregled) => Create(pregled);
        public void DeletePregled(Pregled pregled) => Delete(pregled); 
        public void UpdatePregled(Pregled pregled) => Update(pregled);

        public async Task<IEnumerable<Pregled>> GetAllPregledi()
        {
            return await FindAll()
                .Include(doktor => doktor.Doktor)
                .Include(pacijent => pacijent.Pacijent)
                .ToListAsync();
        }

        public async Task<Pregled> GetPregledById(int id)
        {
            return await FindByCondition(pregled => pregled.PregledID == id)
                .Include(doktor => doktor.Doktor)
                .Include(pacijent => pacijent.Pacijent)
                .FirstOrDefaultAsync();
        }
    }
}