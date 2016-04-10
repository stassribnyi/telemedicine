using System.Collections.Generic;
using System.Data.Entity;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Infrastructure.Data
{
    public class HospitalRepository : IHospitalRepository
    {
        private TelemedicineContext _db;

        public HospitalRepository(TelemedicineContext context)
        {
            _db = context;
        }

        public IEnumerable<Hospital> GetAll()
        {
            return _db.Hospitals;
        }

        public Hospital Get(int id)
        {
            return _db.Hospitals.Find(id);
        }

        public void Create(Hospital Hospital)
        {
            _db.Hospitals.Add(Hospital);
        }

        public void Update(Hospital Hospital)
        {
            _db.Entry(Hospital).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Hospital Hospital = _db.Hospitals.Find(id);
            if (Hospital != null)
                _db.Hospitals.Remove(Hospital);
        }
    }
}