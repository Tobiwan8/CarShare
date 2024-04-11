﻿using CarShare.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserModel? User { get; set; }
        public List<CarModel>? PersonCars { get; set; }
    }
}