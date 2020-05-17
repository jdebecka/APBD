using System;
using System.Runtime.InteropServices;

namespace Apbd_example_tutorial_10.DTOs.Request
{
    public class UpdateStudentRequest
    {
        
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? IdEnrollment { get; set; }
    }
}