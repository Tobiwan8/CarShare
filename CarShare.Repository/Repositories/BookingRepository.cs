using CarShare.Repository.DTOs;
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

        public Task<BookingModel> Create(BookingDTO booking)
        {
            // context is our Database!!
            BookingModel model = new()
            {
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Person = _context.Persons.FirstOrDefault(p => p.ID == booking.PersonID),
                Car = _context.Cars.FirstOrDefault(c => c.ID == booking.CarID)
            };
            _context.Bookings.Add(model);
            _context.SaveChanges();
            return Task.Run(() => model);
        }

        public Task<List<BookingModel>> GetAll()
        {
            return Task.Run(() => _context.Bookings.ToList());
        }
    }
}
