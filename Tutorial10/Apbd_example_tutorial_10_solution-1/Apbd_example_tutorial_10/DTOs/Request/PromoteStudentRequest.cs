using System.ComponentModel.DataAnnotations;

namespace Apbd_example_tutorial_10.DTOs.Request
{
    public class PromoteStudentRequest
    {
        [Required]
        public string Studies { get; set; }
        [Required]
        public int Semester  { get; set; }
    }
}