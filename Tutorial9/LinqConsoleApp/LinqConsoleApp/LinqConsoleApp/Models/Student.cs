using System;
using System.Dynamic;
using System.Security.Cryptography;

namespace Task3.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public int IdEnrollment { get; set; }
    }

}