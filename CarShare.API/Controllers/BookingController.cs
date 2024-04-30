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
