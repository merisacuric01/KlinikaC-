using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Repository;
using klinika.Data;

namespace klinika.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context) => _context = context;
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}