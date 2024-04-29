using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Models
{
    public class PersonCarModel
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public PersonModel? Person { get; set; }
        public int CarID { get; set; }
        public CarModel? Car { get; set; }
    }
}
