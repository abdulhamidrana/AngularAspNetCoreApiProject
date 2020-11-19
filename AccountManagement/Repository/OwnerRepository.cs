using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.DomainModels;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository:RepositoryBase<Owner>,IOwnerRepository
    {
        public OwnerRepository(ApplicationDbContext context):base(context)
        {
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll().OrderBy(ow => ow.Name).ToList();
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(ow => ow.Id.Equals(ownerId)).FirstOrDefault();
        }

        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(ow => ow.Id.Equals(ownerId)).
                Include(a => a.Accounts).
                FirstOrDefault();
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }
    }
}
