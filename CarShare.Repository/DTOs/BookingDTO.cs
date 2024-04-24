using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.DTOs
{
    public class BookingDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonID { get; set; }
        public int CarID { get; set; }
    }
}
