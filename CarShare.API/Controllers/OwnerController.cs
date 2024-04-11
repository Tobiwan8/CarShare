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
        public void Create(OwnerModel owner)
        {
            _context.Create(owner);
        }

        [HttpGet]
        public List<OwnerModel> Get()
        {
            return _context.GetAll();
        }
    }
}
