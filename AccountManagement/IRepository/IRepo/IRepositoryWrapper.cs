using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository.IRepo
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
