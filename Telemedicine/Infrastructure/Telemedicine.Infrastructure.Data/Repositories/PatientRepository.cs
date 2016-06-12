using System.Collections.Generic;
using System.Data.Entity;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Infrastructure.Data
{
    public class PatientRepository : IPatientRepository
    {
        private TelemedicineContext _db;

        public PatientRepository(TelemedicineContext context)
        {
            _db = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _db.Patients;
        }

        public Patient Get(int id)
        {
            return _db.Patients.Find(id);
        }

        public void Create(Patient Patient)
        {
            _db.Patients.Add(Patient);
        }

        public void Update(Patient Patient)
        {
            _db.Entry(Patient).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Patient Patient = _db.Patients.Find(id);
            if (Patient != null)
                _db.Patients.Remove(Patient);
        }
    }
}