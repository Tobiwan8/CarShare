﻿using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.DTOs
{
    public class CarDTO
    {
        public string? Name { get; set; }
        public string? LicensePlate { get; set; }
        public int PersonID { get; set; }
    }
}
