using DataLayer;
using IRepository;
using IRepository.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _db;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public RepositoryWrapper(ApplicationDbContext db)
        {
            _db = db;
        }

        public IOwnerRepository Owner { 
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_db);
                }
                return _owner;
            }        
        }

        public IAccountRepository Account {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_db);
                }
                return _account;
            }        
        }        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
