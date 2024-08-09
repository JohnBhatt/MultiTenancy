using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Data;
using MultiTenancy.Data.DTOs;
using MultiTenancy.Services;

namespace MultiTenancy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _context;
        public PersonsController(IPersonService context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        { 
            var list = _context.GetAllPersons();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post(CreatePersonRequest request)
        { 
            var person = _context.CreatePerson(request);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var personDeleted = _context.DeletePerson(id);
            return Ok(personDeleted);
        }
    }
}
