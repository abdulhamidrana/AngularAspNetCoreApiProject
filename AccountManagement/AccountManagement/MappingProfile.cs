using AutoMapper;
using DataLayer.DataTransferObjects;
using DataLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<Account, AccountDto>();
            CreateMap<OwnerForCreatingDto, Owner>();
            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
