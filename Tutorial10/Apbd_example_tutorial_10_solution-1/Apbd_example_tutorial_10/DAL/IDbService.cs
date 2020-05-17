using System.Collections;
using System.Collections.Generic;
using Apbd_example_tutorial_10.DTOs.Request;
using Apbd_example_tutorial_10.DTOs.Response;
using Apbd_example_tutorial_10.Entities;
using Apbd_example_tutorial_10.Models;

namespace Apbd_example_tutorial_10.DAL
{
    public interface IDbService
    {
        public IEnumerable<GetStudentsResponse> GetStudents();
        public Student CreateStudent(EnrollStudentRequest request);
        public bool DeleteStudent(string id);
        public bool UpdateStudent(UpdateStudentRequest updateStudentRequest);
        // public EnrollStudentResponse EnrollStudent(EnrollStudentRequest enrollStudentRequest);

    }
}