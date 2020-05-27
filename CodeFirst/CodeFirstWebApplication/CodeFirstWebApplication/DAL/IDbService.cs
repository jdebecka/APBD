using System.Collections;
using System.Collections.Generic;
using CodeFirstWebApplication.DTOs.Request;
using CodeFirstWebApplication.DTOs.Response;
using CodeFirstWebApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstWebApplication.DAL
{
    public interface IDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public DoctorResponse UpdateDoctor(DoctorUpdateRequest doctorUpdateRequest);
        public DoctorResponse AddDoctor(Doctor doctor);
        public bool DeleteDoctor(int id);
    }
}