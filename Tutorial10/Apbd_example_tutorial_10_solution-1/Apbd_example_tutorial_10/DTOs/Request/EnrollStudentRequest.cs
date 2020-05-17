using System;
using System.ComponentModel.DataAnnotations;

namespace Apbd_example_tutorial_10.DTOs.Request
{
    public class EnrollStudentRequest
    {
        public string IndexNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Studies { get; set; }
    }
}