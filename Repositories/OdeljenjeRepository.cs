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
    public class OdeljenjeRepository : BaseRepository<Odeljenje>, IOdeljenjeRepository
    {
        public OdeljenjeRepository(DataContext context) : base(context) { }

        public void CreateOdeljenje(Odeljenje odeljenje) => Create(odeljenje);
        public void DeleteOdeljenje(Odeljenje odeljenje) => Delete(odeljenje); 
        public void UpdateOdeljenje(Odeljenje odeljenje) => Update(odeljenje);

        public async Task<IEnumerable<Odeljenje>> GetAllOdeljenja()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Odeljenje> GetOdeljenjeById(int id)
        {
            return await FindByCondition(odeljenje => odeljenje.OdeljenjeID == id).FirstOrDefaultAsync();
        }
    }
    }
