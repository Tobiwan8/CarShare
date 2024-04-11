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
        public void Create(BookingModel booking)
        {
            _context.Create(booking);
        }

        [HttpGet]
        public List<BookingModel> Get()
        {
            return _context.GetAll();
        }
    }
}
