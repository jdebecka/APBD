using System.Collections;
using System.Collections.Generic;
using Task3.Models;

namespace Task3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student {IdStudent = 1, Name = "Julia", LastName = "Debecka"},
                new Student {IdStudent = 1, Name = "Kamil", LastName = "Sikora"},
                new Student {IdStudent = 1, Name = "Jan", LastName = "Witkowski"}
            };
        }

        IEnumerable<Student> IDbService.GetStudents()
        {
            return _students;
        }
    }
}