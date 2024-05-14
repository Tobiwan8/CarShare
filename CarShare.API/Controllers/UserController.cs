using CarShare.Repository.DTOs;
using CarShare.Repository.Interfaces;
using CarShare.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _context;
        //private readonly IGenericRepository<UserModel> _genericContext;

        public UserController(IUserRepository repo)
        {
            _context = repo;
        }

        //public UserController(IGenericRepository<UserModel> repo)
        //{
        //    _genericContext = repo;
        //}

        //[HttpPost("Generic")]
        //public async Task<ActionResult<T>> Create<T>(UserModel user)
        //{
        //    try
        //    {
        //        var createdUser = await _genericContext.CreateAsync(user);
        //        return CreatedAtAction("GetUserByID", new { id = createdUser.ID }, createdUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserModel>> Get()
        {
            var result = await _context.GetAll();
            return result;
        }

        [HttpGet("user")]
        public async Task<UserModel?> GetUser(string userName, string password)
        {
            return await _context.GetUser(userName, password);
        }

        [HttpGet("id")]
        public async Task<UserModel?> GetUser(int userID)
        {
            return await _context.GetUser(userID);
        }

        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserModel>> Get(int id)
        //{

        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost]
        public async Task<UserModel> Create(UserDTO user)
        {
            UserModel userModel = await _context.Create(user);
            return userModel;
        }

        [HttpPut]
        public async Task Update(UserModel user)
        {
            await _context.Update(user);
        }

        [HttpDelete]
        public async Task Delete([FromQuery]int userID)
        {
            await _context.Delete(userID); 
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
