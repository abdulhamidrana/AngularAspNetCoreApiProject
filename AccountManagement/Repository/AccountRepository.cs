using DataLayer;
using DataLayer.DomainModels;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AccountRepository:RepositoryBase<Account>,IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context):base(context)
        {

        }

        public IEnumerable<Account> AccountByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }
    }
}
