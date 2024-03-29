﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.DomainModels
{
    [Table("Account")]
    public class Account
    {
        [Column("AccountId")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }


        [Required(ErrorMessage = "Account type is required")]
        public string AccountType { get; set; }


        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
