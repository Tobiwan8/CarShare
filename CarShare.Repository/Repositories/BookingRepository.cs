using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<BookingModel> Create(BookingDTO booking)
        {
            booking.StartDate = booking.StartDate.Date;
            booking.EndDate = booking.EndDate.Date.AddDays(1).AddTicks(-1);

            bool carOverlap = await _context.Bookings
                .AnyAsync(b => b.CarID == booking.CarID &&
                       ((booking.StartDate >= b.StartDate && booking.StartDate < b.EndDate) ||
                        (booking.EndDate > b.StartDate && booking.EndDate <= b.EndDate) ||
                        (booking.StartDate < b.StartDate && booking.EndDate > b.EndDate)));

            if (carOverlap)
            {
                throw new InvalidOperationException("The car is already booked for the specified time period.");
            }

            bool personOverlap = await _context.Bookings
                .AnyAsync(b => b.PersonID == booking.PersonID &&
                               ((booking.StartDate >= b.StartDate && booking.StartDate < b.EndDate) ||
                                (booking.EndDate > b.StartDate && booking.EndDate <= b.EndDate) ||
                                (booking.StartDate < b.StartDate && booking.EndDate > b.EndDate)));

            if (personOverlap)
            {
                throw new InvalidOperationException("The person already has a booking for the specified time period.");
            }


            BookingModel model = new()
            {
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Person = _context.Persons.FirstOrDefault(p => p.ID == booking.PersonID),
                Car = _context.Cars.FirstOrDefault(c => c.ID == booking.CarID)
            };
            _context.Bookings.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Task<List<BookingModel>> GetAll()
        {
            return Task.Run(() => _context.Bookings.ToList());
        }

        public async Task<BookingModel?> GetBookingByID(int ID) 
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.ID == ID);
        }

        public async Task<List<BookingPersonLidtReturnDTO?>> GetBookingsForSharedCars(int carID)
        {
            using(var context = _context)
            {
                var bookings = await _context.Bookings
                    .Where(b => b.CarID == carID)
                    .Select(b => new BookingPersonLidtReturnDTO
                    {
                        ID = b.ID,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate,
                        PersonFullName = b.Person!.FirstName + " " + b.Person.LastName
                    })
                    .ToListAsync();

                return bookings!;
            }
        }


        public async Task<List<PersonBookingsReturnDTO?>> GetBookingsForPerson(int personID)
        {
            using (var context = _context)
            {
                var bookings = await _context.Bookings
                    .Where(b => b.PersonID == personID)
                    .Select(b => new PersonBookingsReturnDTO
                    {
                        ID = b.ID,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate,
                        CarName = b.Car!.Name
                    })
                    .ToListAsync();

                return bookings!;
            }
        }

        // await _context.PersonCars.Where(b => b.PersonID == personID).Select(b => b.Car!).ToListAsync();
        public async Task<BookingModel?> Update(BookingUpdateDTO booking)
        {
            BookingModel? dbBooking = await _context.Bookings.FindAsync(booking.ID);

            if (dbBooking == null)
            {
                return dbBooking;
            }

            dbBooking.StartDate = booking.StartDate.Date;
            dbBooking.EndDate = booking.EndDate.Date.AddDays(1).AddTicks(-1);

            bool carOverlap = await _context.Bookings
                .AnyAsync(b => b.CarID == dbBooking.CarID &&
                       b.ID != dbBooking.ID &&
                       ((dbBooking.StartDate >= b.StartDate && dbBooking.StartDate < b.EndDate) ||
                        (dbBooking.EndDate > b.StartDate && dbBooking.EndDate <= b.EndDate) ||
                        (dbBooking.StartDate < b.StartDate && dbBooking.EndDate > b.EndDate)));

            if (carOverlap)
            {
                throw new InvalidOperationException("The car is already booked for the specified time period.");
            }

            bool personOverlap = await _context.Bookings
                .AnyAsync(b => b.PersonID == dbBooking.PersonID &&
                       b.ID != dbBooking.ID &&
                       ((dbBooking.StartDate >= b.StartDate && dbBooking.StartDate < b.EndDate) ||
                        (dbBooking.EndDate > b.StartDate && dbBooking.EndDate <= b.EndDate) ||
                        (dbBooking.StartDate < b.StartDate && dbBooking.EndDate > b.EndDate)));

            if (personOverlap)
            {
                throw new InvalidOperationException("The person already has a booking for the specified time period.");
            }

            await _context.SaveChangesAsync();

            return dbBooking;
            //BookingModel? dbBooking = await _context.Bookings.FindAsync(booking.ID);

            //if (dbBooking == null)
            //{
            //    return dbBooking;
            //}

            //dbBooking.StartDate = booking.StartDate;
            //dbBooking.EndDate = booking.EndDate;

            //await _context.SaveChangesAsync();

            //return dbBooking;
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
