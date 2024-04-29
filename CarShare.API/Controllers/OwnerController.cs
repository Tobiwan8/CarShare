using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _context;

        public OwnerController(IOwnerRepository repo)
        {
            _context = repo;
        }

        [HttpPost]
        public async Task Create(int personID)
        {
            await _context.Create(personID);
        }

        [HttpGet]
        public async Task<List<OwnerModel>> Get()
        {
            return await _context.GetAll();
        }
    }
}
