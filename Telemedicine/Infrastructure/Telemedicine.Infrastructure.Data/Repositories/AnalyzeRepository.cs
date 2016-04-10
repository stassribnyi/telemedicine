using System.Collections.Generic;
using System.Data.Entity;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Infrastructure.Data
{
    public class AnalyzeRepository : IAnalyzeRepository
    {
        private TelemedicineContext _db;

        public AnalyzeRepository(TelemedicineContext context)
        {
            _db = context;
        }

        public IEnumerable<Analyze> GetAll()
        {
            return _db.Analyzes;
        }

        public Analyze Get(int id)
        {
            return _db.Analyzes.Find(id);
        }

        public void Create(Analyze Analyze)
        {
            _db.Analyzes.Add(Analyze);
        }

        public void Update(Analyze Analyze)
        {
            _db.Entry(Analyze).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Analyze Analyze = _db.Analyzes.Find(id);
            if (Analyze != null)
                _db.Analyzes.Remove(Analyze);
        }
    }
}