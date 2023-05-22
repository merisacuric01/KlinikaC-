using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Contracts.Service
{
    public interface IServiceManager
    {
        IDoktorService DoktorService { get; }
        IOdeljenjeService OdeljenjeService { get; }
        IPacijentService PacijentService { get; }
        IPregledService PregledService { get; }
    }
}