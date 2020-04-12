using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Task3.DAL;
using Task3.DTOs.Request;
using Task3.Models;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public EnrollmentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] EnrollStudentRequest request)
        {
            var response = _dbService.CreateStudent(request);
            if (response == null)
            {
                
                return BadRequest("Something went wrong");
            }
            return CreatedAtAction("CreateStudent", response);
        }

    }
}