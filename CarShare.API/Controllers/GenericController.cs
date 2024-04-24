using CarShare.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        public GenericController()
        {
                
        }
        //[HttpPost("Generic")]
        //public async Task<ActionResult<T>> Create<T>(T entity)
        //{
        //    try
        //    {
        //        var createdEntity = await _context.CreateAsync(entity);
        //        return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
