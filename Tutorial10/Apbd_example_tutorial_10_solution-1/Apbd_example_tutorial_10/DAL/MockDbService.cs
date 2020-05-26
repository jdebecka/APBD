using System;
using System.Collections.Generic;
using System.Linq;
using Apbd_example_tutorial_10.DTOs.Request;
using Apbd_example_tutorial_10.DTOs.Response;
using Apbd_example_tutorial_10.Entities;
using Apbd_example_tutorial_10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apbd_example_tutorial_10.DAL
{
    public class MockDbService : IDbService
    {
        private readonly apbdContext _studentContext;

        public MockDbService(apbdContext studentContext)
        {
            _studentContext = studentContext;
        }


        Student IDbService.CreateStudent([FromBody] EnrollStudentRequest request)
        {
            var idEnroll = _studentContext.Enrollment.Include(e => e.IdStudyNavigation)
                .Where(study => study.IdStudyNavigation.Name == request.Studies && study.Semester == 1)
                .Select(id => id.IdEnrolment).FirstOrDefault();

            var student = new Student
            {
                IndexNumber = request.IndexNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                IdEnrollment = idEnroll
            };

            _studentContext.Student.Add(student);
            _studentContext.SaveChanges();

            return student;
        }
        
        public bool DeleteStudent(string id)
        {
            var student = _studentContext.Student.First(s => s.IndexNumber == id);

            if (student != null)
            {
                _studentContext.Entry(student).State = EntityState.Detached;

                _studentContext.Attach(student);
                _studentContext.Entry(student).State = EntityState.Deleted;
                _studentContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateStudent(UpdateStudentRequest updateStudentRequest)
        {
            var student = _studentContext.Set<Student>().FirstOrDefault(s => s.IndexNumber == updateStudentRequest.IndexNumber);
            if (student != null)
            {
                _studentContext.Entry(student).State = EntityState.Detached;

                var updatedStudent = new Student
                {
                    IndexNumber = updateStudentRequest.IndexNumber,
                    FirstName = updateStudentRequest.FirstName ?? student.FirstName,
                    LastName = updateStudentRequest.LastName ?? student.LastName,
                    BirthDate = updateStudentRequest.BirthDate ?? student.BirthDate,
                    IdEnrollment = updateStudentRequest.IdEnrollment ?? student.IdEnrollment
                };

                _studentContext.Attach(updatedStudent);
                _studentContext.Entry(updatedStudent).State = EntityState.Modified;
                _studentContext.SaveChanges();

                return true;
            }

            return false;
        }

        // public EnrollStudentResponse EnrollStudent(EnrollStudentRequest enrollStudentRequest)
        // {
        //     int? enrollStudies = _studentContext.Enrollment
        //         .Include(e => e.IdStudyNavigation)
        //         .ThenInclude(s => s.IdStudy)
        //         .Where(e => e.Semester == 1 && enrollStudentRequest.Studies == e.IdStudyNavigation.Name)
        //         .Select(e => e.IdEnrolment).FirstOrDefault();
        //     
        //     if (enrollStudies.HasValue)
        //     {
        //         
        //
        //     }
        // }
        //


        // public EnrollStudentResponse PromoteStudent(PromoteStudentRequest request)
        // {
        //     using (_connection = new SqlConnection(connection_string))
        //     using (var command = new SqlCommand())
        //     {
        //         _connection.Open();
        //         command.CommandText = "SELECT IdEnrolment FROM Enrollment INNER JOIN Studies ON Enrollment.IdStudy = Studies.IdStudy where Studies.Name = @Name and Enrollment.Semester = 1;";
        //         command.Parameters.AddWithValue("Name", request.Studies);
        //         command.Connection = _connection;
        //         
        //         var trans = _connection.BeginTransaction();
        //         command.Transaction = trans;
        //         
        //         var dataReader = command.ExecuteReader();
        //         
        //         if (!dataReader.Read())
        //         {
        //             dataReader.Close();
        //             return null;
        //         }
        //         
        //         var id_study = int.Parse(dataReader["StudyExist"].ToString());
        //         dataReader.Close();
        //         
        //     }
        // }
        
        IEnumerable<GetStudentsResponse> IDbService.GetStudents()
        {
            var students = _studentContext.Student
                .Include(s => s.IdEnrollmentNavigation).ThenInclude(e => e.IdStudyNavigation)
                .Select(s => new GetStudentsResponse
                {
                    IndexNumber = s.IndexNumber,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    BirthDate = s.BirthDate.ToString(),
                    Semester = s.IdEnrollmentNavigation.Semester.Value,
                    Studies = s.IdEnrollmentNavigation.IdStudyNavigation.Name
                })
                .ToList();
            return students;
        }
    }
}