using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonCarController : ControllerBase
    {
        private readonly IPersonCarRepository _context;

        public PersonCarController(IPersonCarRepository repo)
        {
            _context = repo;
        }

        [HttpPost("{carId}/{personId}")]
        public async Task Create(int carID, int personID)
        {
            PersonCarDTO pcDTO = new()
            {
                PersonID = personID,
                CarID = carID
            };
            await _context.Create(pcDTO);
        }

        [HttpGet]
        public async Task<List<PersonCarModel>> Get()
        {
            return await _context.GetAll();
        }

        [HttpGet("byPersonID/{personID}")]
        public async Task<List<CarModel>> GetAllByPersonID(int personID)
        {
            return await _context.GetAllByPersonID(personID);
        }

        [HttpGet("byCarID/{carID}")]
        public async Task<List<PersonModel>> GetAllByCarID(int carID)
        {
            return await _context.GetAllByCarID(carID);
        }

        [HttpDelete("{carId}/{personId}")]
        public async Task Delete(int carID, int personID)
        {
            var pcDTO = new PersonCarDTO { CarID = carID, PersonID = personID };
            await _context.Delete(pcDTO);
        }
    }
}
