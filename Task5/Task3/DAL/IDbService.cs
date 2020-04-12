using System.Collections;
using System.Collections.Generic;
using Task3.DTOs.Request;
using Task3.DTOs.Response;
using Task3.Models;

namespace Task3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        IEnumerable<Enrollment> GetEnrollments(string id);
        IEnumerable<Studies> GetStudies();

        bool CheckIndexExists(string indexNumber);
        public EnrollStudentResponse CreateStudent(EnrollStudentRequest request);

        public void saveLogData(string data);
    }
}