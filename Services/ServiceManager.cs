using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Repository;
using klinika.Contracts.Service;

namespace klinika.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDoktorService> _lazyDoktorService;
        private readonly Lazy<IOdeljenjeService> _lazyOdeljenjeService;
        private readonly Lazy<IPacijentService> _lazyPacijentService;
        private readonly Lazy<IPregledService> _lazyPregledService;

        public ServiceManager(IManagerRepository repositoryManager)
        {
            _lazyDoktorService = new Lazy<IDoktorService>(() => new DoktorService(repositoryManager));
            _lazyOdeljenjeService = new Lazy<IOdeljenjeService>(() => new OdeljenjeService(repositoryManager));
            _lazyPacijentService = new Lazy<IPacijentService>(() => new PacijentService(repositoryManager));
            _lazyPregledService = new Lazy<IPregledService>(() => new PregledService(repositoryManager));
        }

        public IDoktorService DoktorService => _lazyDoktorService.Value;
        public IOdeljenjeService OdeljenjeService => _lazyOdeljenjeService.Value;
        public IPacijentService PacijentService => _lazyPacijentService.Value;
        public IPregledService PregledService => _lazyPregledService.Value;
    }  
    }