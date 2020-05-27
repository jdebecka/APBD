using CodeFirstWebApplication.DAL;
using CodeFirstWebApplication.DTOs.Request;
using CodeFirstWebApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstWebApplication.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorContoller : Controller
    {
        private readonly IDbService _dbService;
        public DoctorContoller(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        IActionResult GetDoctors()
        {
            return Ok(_dbService.GetDoctors());
        }

        [HttpPut]
        IActionResult UpdateDoctor([FromBody] DoctorUpdateRequest doctor)
        {
            var response = _dbService.UpdateDoctor(doctor);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Doctor with a given id not found");
        }

        [HttpDelete("{id}")]
        IActionResult DeleteDoctor(int id)
        {
            var wasDeleted = _dbService.DeleteDoctor(id);

            if (wasDeleted)
            {
                return Ok("Doctor was deleted");
            }

            return BadRequest("Doctor with a given ID does not exist");
        }

        [HttpPost]

        IActionResult AddDoctor(Doctor doctor)
        {
            var doctorResponse = _dbService.AddDoctor(doctor);

            if (doctorResponse != null)
            {
                return Ok(doctor);
            }

            return BadRequest("Couldn't add doctor");
        }

    }
}