using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public async Task<BookingModel?> Update(BookingUpdateDTO booking)
        {
            BookingModel? dbBooking = await _context.Bookings.FindAsync(booking.ID);

            if (dbBooking == null)
            {
                return dbBooking;
            }

            dbBooking.StartDate = booking.StartDate;
            dbBooking.EndDate = booking.EndDate;

            await _context.SaveChangesAsync();

            return dbBooking;
        }

        public async Task<BookingModel?> Delete(int bookingID)
        {
            BookingModel? dbBooking = await _context.Bookings.FindAsync(bookingID);

            if (dbBooking == null)
            {
                return dbBooking;
            }

            _context.Bookings.Remove(dbBooking);

            await _context.SaveChangesAsync();

            return dbBooking;
        }
    }
}
