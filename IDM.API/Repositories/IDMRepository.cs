using IDM.API.Models;

namespace IDM.API.Repositories
{
    public class IDMRepository : IIDMRepository
    {
        private readonly IDMDataContext _context;
        private IIssuerRepository _issuerRepository;
        private IProviderRepository _providerRepository;

        private IUserRepository _userRepository;

        public IDMRepository(IDMDataContext context)
        {
            _context = context;
        }

        public IIssuerRepository Issuers {
            get {
                if (_issuerRepository == null)
                    _issuerRepository = new IssuerRepository(_context);

                return _issuerRepository;
            }
        }

        public IProviderRepository Providers {
            get {
                if (_providerRepository == null)
                    _providerRepository = new ProviderRepository(_context);

                return _providerRepository;
            }
        }

        public IUserRepository Users {
            get {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }
    }
}