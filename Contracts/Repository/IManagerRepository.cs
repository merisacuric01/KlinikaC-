using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Contracts.Repository
{
    public interface IManagerRepository
    {
        IDoktorRepository DoktorRepository { get; }
        IOdeljenjeRepository OdeljenjeRepository { get; }
        IPacijentRepository PacijentRepository { get; }
        IPregledRepository PregledRepository { get; }
        IUnitOfWork UnitOfWork { get;}
    }
}