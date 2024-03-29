﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DataTransferObjects
{
    public class OwnerForCreatingDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer be 60 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; }
    }
}
