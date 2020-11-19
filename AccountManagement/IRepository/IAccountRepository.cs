using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.DomainModels;
using IRepository.IRepo;

namespace IRepository
{
    public interface IAccountRepository:IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountByOwner(Guid ownerId);
    }
}
