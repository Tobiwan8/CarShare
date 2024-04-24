﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Models
{
    [Index(nameof(LicensePlate), IsUnique = true)]
    public class CarModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? LicensePlate { get; set; }
        public OwnerModel? Owner { get; set; }
        public List<PersonModel>? CarPersons { get; set;}
    }
}
