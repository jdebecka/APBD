using System.ComponentModel.DataAnnotations;

namespace Task3.DTOs.Request
{
    public class PromoteStudentRequest
    {
        [Required]
        public string Studies { get; set; }
        [Required]
        public int Semester  { get; set; }
    }
}