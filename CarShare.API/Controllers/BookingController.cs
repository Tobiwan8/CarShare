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
        public async Task<IActionResult> Create(BookingDTO booking)
        {
            try
            {
                var bookingModel = await _context.Create(booking);
                return CreatedAtAction(nameof(GetById), new { id = bookingModel.ID }, bookingModel);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if necessary
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpGet]
        public async Task<List<BookingModel>> Get()
        {
            return await _context.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _context.GetBookingByID(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
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
        public async Task<IActionResult> Update(BookingUpdateDTO booking)
        {
            try
            {
                var updatedBooking = await _context.Update(booking);

                if (updatedBooking == null)
                {
                    return NotFound();
                }

                return Ok(updatedBooking);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex });
            }
        }

        [HttpDelete]
        public async Task Delete(int bookingID)
        {
            await _context.Delete(bookingID);
        }
    }
}
