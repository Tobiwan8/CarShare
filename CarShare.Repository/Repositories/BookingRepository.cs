using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DatabaseContext _context;

        public BookingRepository(DatabaseContext data)
        {
            _context = data;
        }

        public BookingModel Create(BookingModel booking)
        {
            // context is our Database!!
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        public List<BookingModel> GetAll()
        {
            return _context.Bookings.ToList();
        }
    }
}
