using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Models
{
    public class BookingModel
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonID { get; set; }
        public int CarID { get; set; }
        public PersonModel? Person { get; set; }
        public CarModel? Car { get; set; }
    }
}
