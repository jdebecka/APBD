using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Task3.Models;

namespace Task3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;
        private static IEnumerable<Studies> _studieses;
        private static IEnumerable<Enrollment> _enrollment;
        private static string connection_string = @"Server=localhost,1433\\Catalog=apbd;Database=apbd;User=sa;Password=Winter2019;";
        private static SqlConnection _connection;
        
        static MockDbService()
        {
            _connection = new SqlConnection(connection_string);
        }
        IEnumerable<Enrollment> IDbService.GetEnrollments(int id)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            using (_connection)
            {
                using(var command = new SqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandText = "SELECT * FROM Enrollment INNER JOIN student ON Enrollment.IdEnrolment = student.IdEnrollment where IdStudent = @id;";
                    command.Parameters.AddWithValue("id", id);
                    _connection.Open();
                    var dr = command.ExecuteReader();
                   
                    while (dr.Read())
                    {
                        var enrollment = new Enrollment();
                        enrollment.IdEnrolment = int.Parse(dr["IdEnrolment"].ToString());
                        enrollment.Semester = int.Parse(dr["Semester"].ToString());
                        enrollment.IdStudy = int.Parse(dr["IdStudy"].ToString());
                        enrollment.StartDate = DateTime.Parse(dr["StartDate"].ToString());
                        
                        enrollments.Add(enrollment);
                    }
                    _enrollment = enrollments;
                }
            }
            return _enrollment;
        }

        IEnumerable<Studies> IDbService.GetStudies()
        {
            List<Studies> _studiesesList = new List<Studies>();
            using (_connection)
            {
                using(var command = new SqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandText = "Select * from Studies";
                    _connection.Open();

                    var dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        var studies = new Studies();
                        studies.Name = dr["Name"].ToString();
                        studies.IdStudy = int.Parse(dr["IdStudy"].ToString());

                        _studiesesList.Add(studies);
                    }

                    _studieses = _studiesesList;
                }
            }
            return _studieses;
        }

        IEnumerable<Student> IDbService.GetStudents()
        {
            List<Student> _studentsList = new List<Student>();
            using (_connection)
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandText = "Select * from student";
                    _connection.Open();

                    var dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        var student = new Student();
                        student.IndexNumber = dr["IndexNumber"].ToString();
                        student.Name = dr["FirstName"].ToString();
                        student.LastName = dr["LastName"].ToString();
                        student.IdEnrollment = int.Parse(dr["IdEnrollment"].ToString());
                        student.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
                        _studentsList.Add(student);
                    }
                    _students = _studentsList;
                }
            }
            return _students;
        }
    }
}


/////////Task 3
// _students = new List<Student>
// {
//     new Student {IdStudent = 1, Name = "Julia", LastName = "Debecka"},
//     new Student {IdStudent = 1, Name = "Kamil", LastName = "Sikora"},
//     new Student {IdStudent = 1, Name = "Jan", LastName = "Witkowski"}
// };