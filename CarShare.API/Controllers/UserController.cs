using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _context;

        public UserController(IUserRepository repo)
        {
            _context = repo;
        }


        // GET: api/<UserController>
        [HttpGet]
        public List<UserModel> Get()
        {
            var result = _context.GetAll();
            return result;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Create(UserDTO user)
        {
            //UserModel userModel = new();
            //userModel.UserName = user.UserName;
            //userModel.Password = user.Password;

            _context.Create(user);
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
