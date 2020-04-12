using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Task3.DTOs.Request;
using Task3.DTOs.Response;
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
        
        EnrollStudentResponse IDbService.CreateStudent([FromBody] EnrollStudentRequest request)
        {
            var newStudent = new EnrollStudentResponse();
            using (_connection = new SqlConnection(connection_string))
            using (var command = new SqlCommand())
            {
                _connection.Open();
                command.CommandText = "select IdStudy as StudyExist from Studies where Name = @Name";
                command.Parameters.AddWithValue("Name", request.Studies);
                command.Connection = _connection;
                
                var trans = _connection.BeginTransaction();
                command.Transaction = trans;
                
                var dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    dataReader.Close();
                    return null;
                }
                
                var id_study = int.Parse(dataReader["StudyExist"].ToString());
                dataReader.Close();
                
                command.CommandText = "select IdEnrolment from Enrollment where IdStudy=@id and Semester=1;";
                command.Parameters.AddWithValue("id", id_study);
                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                    dataReader.Close();
                    
                    var Date = DateTime.Now;
                    command.CommandText = "select max(isnull(IdEnrolment , 0)) as maxID from Enrollment;";
                    dataReader = command.ExecuteReader();
                    dataReader.Read();
                    var maxID = long.Parse(dataReader["maxID"].ToString()) + 1;
                    dataReader.Close();
                    
                    command.CommandText = "insert into Enrollment (IdEnrolment, Semester, IdStudy, StartDate) values (@id, 1, @id_s, @Date);";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("id", maxID);
                    command.Parameters.AddWithValue("id_s", id_study);
                    command.Parameters.AddWithValue("Date", Date);
                    var rows = command.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        dataReader.Close();
                        return null;
                    }
                }
                else
                {
                    var id_enroll = dataReader[0];
                    dataReader.Close();

                    command.CommandText = "select IndexNumber from student where IndexNumber = @IndexNumber;";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("IndexNumber", request.IndexNumber);
                    dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        dataReader.Close();
                        return null;
                    }
                    
                    dataReader.Close();
                    command.CommandText =
                        "insert into student (IndexNumber, FirstName, LastName, BirthDate, IdEnrollment) values (@IndexNumber, @Name, @LastName, @Birth, @id_enroll);";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("IndexNumber", request.IndexNumber);
                    command.Parameters.AddWithValue("Name", request.FirstName);
                    command.Parameters.AddWithValue("LastName", request.LastName);
                    command.Parameters.AddWithValue("Birth", request.BirthDate);
                    command.Parameters.AddWithValue("id_enroll", id_enroll);
                    command.ExecuteNonQuery();

                    command.CommandText = "select StartDate as start from Enrollment where IdEnrolment=@id_enroll;";
                    dataReader = command.ExecuteReader();
                    if (!dataReader.Read())
                    {
                        dataReader.Close();
                        return null;
                    }
                    var start = DateTime.Parse(dataReader["start"].ToString());
                    
                    newStudent.Semester = 1;
                    newStudent.StartDate = start;
                    dataReader.Close();
                }
                trans.Commit();
            }
            return newStudent;
        }

        public void saveLogData(string data)
        {
            using (var writer = new StreamWriter(@"/Users/juliadebecka/Documents/GitHub/APBD/Task5/Task3/Log/requestLog.txt", true))
            {
                writer.WriteLine(data);
            }
        }

        IEnumerable<Enrollment> IDbService.GetEnrollments(string id)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            using (_connection = new SqlConnection(connection_string))
            using(var command = new SqlCommand())
            {
                _connection.Open();
                command.Connection = _connection;
                command.CommandText = "SELECT * FROM Enrollment INNER JOIN student ON Enrollment.IdEnrolment = student.IdEnrollment where IndexNumber = @id;";
                command.Parameters.AddWithValue("id", id);
                    
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
                    dr.Close();
                    _enrollment = enrollments;
            }
            return _enrollment;
        }

        IEnumerable<Studies> IDbService.GetStudies()
        {
            List<Studies> _studiesesList = new List<Studies>();
            using (_connection = new SqlConnection(connection_string))
            using(var command = new SqlCommand())
                {
                    _connection.Open();
                    command.Connection = _connection;
                    command.CommandText = "Select * from Studies";
                    

                    var dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        var studies = new Studies();
                        studies.Name = dr["Name"].ToString();
                        studies.IdStudy = int.Parse(dr["IdStudy"].ToString());

                        _studiesesList.Add(studies);
                    }
                    dr.Close();
                    _studieses = _studiesesList;
                }
            return _studieses;
        }

        bool IDbService.CheckIndexExists(string indexNumber)
        {
            using (_connection = new SqlConnection(connection_string))
            using (var command = new SqlCommand())
            {
                _connection.Open();
                command.Connection = _connection;
                command.CommandText = "select IndexNumber from student where IndexNumber = @IndexNumber;";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("IndexNumber", indexNumber);
                
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    dataReader.Close();
                    return true;
                }
                dataReader.Close();
            }
            return false;
        }

        IEnumerable<Student> IDbService.GetStudents()
        {
            List<Student> _studentsList = new List<Student>();
            using (_connection = new SqlConnection(connection_string))
            using (var command = new SqlCommand())
            {
                    _connection.Open();
                    command.Connection = _connection;
                    command.CommandText = "Select * from student";
                    

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
                    dr.Close();
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