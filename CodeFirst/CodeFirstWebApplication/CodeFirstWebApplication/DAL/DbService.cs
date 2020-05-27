using System.Collections.Generic;
using System.Linq;
using CodeFirstWebApplication.DTOs.Request;
using CodeFirstWebApplication.DTOs.Response;
using CodeFirstWebApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstWebApplication.DAL
{
    public class DbService : IDbService
    {
        private readonly DoctorDbContext doctorDbContext;

        public DbService(DoctorDbContext doctorDbContext)
        {
            this.doctorDbContext = doctorDbContext;
        }
        
        public IEnumerable<Doctor> GetDoctors()
        {
            return doctorDbContext.Doctors;
        }

        public DoctorResponse UpdateDoctor([FromBody] DoctorUpdateRequest doctorUpdateRequest)
        {
            var doctor = doctorDbContext.Doctors.FirstOrDefault(p => p.IdDoctor == doctorUpdateRequest.Id);

            if (doctor != null)
            {
                doctor.Email = doctorUpdateRequest.Email;
                doctor.FirstName = doctorUpdateRequest.Name;
                doctor.LastName = doctorUpdateRequest.LastName;

                return new DoctorResponse {Email = doctor.Email, LastName = doctor.LastName, Name = doctor.FirstName};
            }
            return null;
        }

        public DoctorResponse AddDoctor(Doctor doctor)
        {
            doctorDbContext.Doctors.Add(doctor);
            doctorDbContext.SaveChanges();
            
            return new DoctorResponse {Email = doctor.Email, LastName = doctor.LastName, Name = doctor.FirstName};
        }

        public bool DeleteDoctor(int id)
        {
            var doctor = doctorDbContext.Doctors.FirstOrDefault(p => p.IdDoctor == id);
            
            if (doctor != null)
            {
                doctorDbContext.Doctors.Remove(doctor);
                doctorDbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}