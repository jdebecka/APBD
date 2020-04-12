using System.Collections;
using System.Collections.Generic;
using Task3.Models;

namespace Task3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        IEnumerable<Enrollment> GetEnrollments(int id);
        IEnumerable<Studies> GetStudies();
    }
}