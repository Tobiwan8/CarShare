using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _context;

        public PersonController(IPersonRepository repo)
        {
            _context = repo;
        }

        [HttpPost]
        public void Create(PersonDTO person)
        {
            _context.Create(person);
        }

        [HttpGet]
        public List<PersonModel> Get()
        {
            return _context.GetAll();
        }
    }
}
