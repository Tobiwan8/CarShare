using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _context;

        public CarController(ICarRepository repo)
        {
            _context = repo;
        }

        [HttpPost]
        public async Task Create(CarDTO car)
        {
            await _context.Create(car);
        }

        [HttpGet]
        public async Task <List<CarModel>> Get()
        {
            return await _context.GetAll();
        }

        [HttpPut]
        public async Task Update(CarUpdateDTO car)
        {
            await _context.Update(car);
        }

        [HttpDelete]
        public async Task Delete(int carID)
        {
            await _context.Delete(carID);
        }
    }
}
