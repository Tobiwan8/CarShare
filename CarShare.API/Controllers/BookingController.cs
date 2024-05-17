using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _context;

        public BookingController(IBookingRepository repo)
        {
            _context = repo;
        }

        [HttpPost]
        public async Task Create(BookingDTO booking)
        {
            await _context.Create(booking);
        }

        [HttpGet]
        public async Task<List<BookingModel>> Get()
        {
            return await _context.GetAll();
        }

        [HttpGet("carID/{carID}")]
        public async Task<List<BookingPersonLidtReturnDTO?>> GetCarBookings(int carID)
        {
            return await _context.GetBookingsForSharedCars(carID);
        }

        [HttpGet("personID/{personID}")]
        public async Task<List<PersonBookingsReturnDTO?>> GetPersonBookings(int personID)
        {
            return await _context.GetBookingsForPerson(personID);
        }

        [HttpPut]
        public async Task Update(BookingUpdateDTO booking)
        {
            await _context.Update(booking);
        }

        [HttpDelete]
        public async Task Delete(int bookingID)
        {
            await _context.Delete(bookingID);
        }
    }
}
