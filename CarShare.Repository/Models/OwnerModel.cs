using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Models
{
    public class OwnerModel
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public PersonModel? Person { get; set; }
        public List<CarModel>? Car { get; set; }
    }
}
