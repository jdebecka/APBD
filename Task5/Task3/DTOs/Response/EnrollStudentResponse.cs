using System;

namespace Task3.DTOs.Response
{
    public class EnrollStudentResponse
    {
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }

        public EnrollStudentResponse(int semester, DateTime startDate)
        {
            Semester = semester;
            StartDate = startDate;
        }

        public EnrollStudentResponse()
        {
        }
    }
}