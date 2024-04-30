using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.DTOs
{
    public class CarUpdateDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? LicensePlate { get; set; }
    }
}
