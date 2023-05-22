using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Repository;
using klinika.Data;

namespace klinika.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly Lazy<IDoktorRepository> _lazyDoktorRepository;
        private readonly Lazy<IOdeljenjeRepository> _lazyOdeljenjeRepository;
        private readonly Lazy<IPacijentRepository> _lazyPacijentRepository;
        private readonly Lazy<IPregledRepository> _lazyPregledRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public ManagerRepository(DataContext context)
        {
            _lazyDoktorRepository = new Lazy<IDoktorRepository>(() => new DoktorRepository(context));
            _lazyOdeljenjeRepository = new Lazy<IOdeljenjeRepository>(() => new OdeljenjeRepository(context));
            _lazyPacijentRepository = new Lazy<IPacijentRepository>(() => new PacijentRepository(context));
            _lazyPregledRepository = new Lazy<IPregledRepository>(() => new PregledRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IDoktorRepository DoktorRepository => _lazyDoktorRepository.Value;
        public IOdeljenjeRepository OdeljenjeRepository => _lazyOdeljenjeRepository.Value;
        public IPacijentRepository PacijentRepository => _lazyPacijentRepository.Value;
        public IPregledRepository PregledRepository => _lazyPregledRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

    }
    }
