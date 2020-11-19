using DataLayer.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906"),
                    Name = "Rana",
                    Address = "61 Kadamtali Road"
                },
                new Owner
                {
                    Id = Guid.Parse("261e1685-cf26-494c-b17c-3546e65f5620"),
                    Name = "Sohana",
                    Address = "27 Bari Dhara"
                },
                new Owner
                {
                    Id = Guid.Parse("a3c1880c-674c-4d18-8f91-5d3608a2c937"),
                    Name = "Marjia",
                    Address = "26 Chua Danga"
                },
                new Owner
                {
                    Id = Guid.Parse("f98e4d74-0f68-4aac-89fd-047f1aaca6b6"),
                    Name = "Naifha",
                    Address = "3 Hamid Buildings"
                }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = Guid.Parse("03e91478-5608-4132-a753-d494dafce00b"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("f98e4d74-0f68-4aac-89fd-047f1aaca6b6")
                },
                new Account
                {
                    Id = Guid.Parse("356a5a9b-64bf-4de0-bc84-5395a1fdc9c4"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("261e1685-cf26-494c-b17c-3546e65f5620")
                },
                new Account
                {
                    Id = Guid.Parse("371b93f2-f8c5-4a32-894a-fc672741aa5b"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906")
                },
                new Account
                {
                    Id = Guid.Parse("670775db-ecc0-4b90-a9ab-37cd0d8e2801"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906")
                },
                new Account
                {
                    Id = Guid.Parse("a3fbad0b-7f48-4feb-8ac0-6d3bbc997bfc"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("a3c1880c-674c-4d18-8f91-5d3608a2c937")
                },
                new Account
                {
                    Id = Guid.Parse("aa15f658-04bb-4f73-82af-82db49d0fbef"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906")
                },
                new Account
                {
                    Id = Guid.Parse("c6066eb0-53ca-43e1-97aa-3c2169eec659"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("261e1685-cf26-494c-b17c-3546e65f5620")
                },
                new Account
                {
                    Id = Guid.Parse("eccadf79-85fe-402f-893c-32d3f03ed9b1"),
                    DateCreated = DateTime.Parse("2020-06-16"),
                    AccountType = "Domestic",
                    OwnerId = Guid.Parse("a3c1880c-674c-4d18-8f91-5d3608a2c937")
                }
           );
        }
    }
}
