using System.Collections.Generic;
using System.Data.Entity;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Infrastructure.Data
{
    public class ECGRepository : IECGRepository
    {
        private TelemedicineContext _db;

        public ECGRepository(TelemedicineContext context)
        {
            _db = context;
        }

        public IEnumerable<ECG> GetAll()
        {
            return _db.ECGs;
        }

        public ECG Get(int id)
        {
            return _db.ECGs.Find(id);
        }

        public void Create(ECG ECG)
        {
            _db.ECGs.Add(ECG);
        }


        public ECG CreateNew()
        {
            return _db.ECGs.Create();
        }

        public void Update(ECG ECG)
        {
            _db.Entry(ECG).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ECG ECG = _db.ECGs.Find(id);
            if (ECG != null)
                _db.ECGs.Remove(ECG);
        }
    }
}