using System.Collections.Generic;
using System.Data.Entity;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Infrastructure.Data
{
    public class DoctorRepository : IDoctorRepository
    {
        private TelemedicineContext _db;

        public DoctorRepository(TelemedicineContext context)
        {
            _db = context;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _db.Doctors;
        }

        public Doctor Get(int id)
        {
            return _db.Doctors.Find(id);
        }

        public void Create(Doctor Doctor)
        {
            _db.Doctors.Add(Doctor);
        }

        public void Update(Doctor Doctor)
        {
            _db.Entry(Doctor).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Doctor Doctor = _db.Doctors.Find(id);
            if (Doctor != null)
                _db.Doctors.Remove(Doctor);
        }
    }
}