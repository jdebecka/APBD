using System;

namespace CodeFirstWebApplication.DTOs.Request
{
    public class DoctorUpdateRequest
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        
    }
}