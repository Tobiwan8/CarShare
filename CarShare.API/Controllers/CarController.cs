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
        public void Create(CarDTO car)
        {
            _context.Create(car);
        }

        [HttpGet]
        public List<CarModel> Get()
        {
            return _context.GetAll();
        }
    }
}
