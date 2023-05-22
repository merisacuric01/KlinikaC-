using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Contracts.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}