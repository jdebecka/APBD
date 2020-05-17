using Apbd_example_tutorial_10.DAL;
using Apbd_example_tutorial_10.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace Apbd_example_tutorial_10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        
        private readonly IDbService _dbService;
        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_dbService.GetStudents());
        }
        
        [HttpPost]
        public IActionResult CreateStudent([FromBody] EnrollStudentRequest request)
        {
            var student = _dbService.CreateStudent(request);
            if ( student != null)
            {
                return Ok(student);
                
            }
            return BadRequest($"Student {request.IndexNumber} could not be created");
        }

        [HttpPut]
        public IActionResult UpdateStudent([FromBody] UpdateStudentRequest studentToUpdate)
        {
            if (_dbService.UpdateStudent(studentToUpdate))
            {
                return Ok($"Successfully updated {studentToUpdate.IndexNumber}");
            }
            return BadRequest($"Student with Index Number: {studentToUpdate.IndexNumber} doesn't exist");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            if(_dbService.DeleteStudent(id)){
                return Ok($"Successfully deleted {id}");
            }
            return BadRequest($"Student with Index Number: {id} doesn't exist");
        }
    }
}