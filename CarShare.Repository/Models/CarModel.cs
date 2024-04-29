using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Owner")]
        public int OwnerID { get; set; }
        public List<PersonCarModel>? CarPersons { get; set;}
    }
}
