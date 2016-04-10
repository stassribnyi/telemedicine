using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Telemedicine.Domain.Interfaces.Common;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private TelemedicineContext _db = new TelemedicineContext();
        private IAnalyzeRepository _analyzeRepository;
        private IDoctorRepository _doctorRepository;
        private IHospitalRepository _hospitalRepository;
        private IPatientRepository _patientRepository;
        private ICommentRepository _commentRepository;
        private IECGRepository _ecgRepository;

        public IAnalyzeRepository Analyzes
        {
            get
            {
                if (_analyzeRepository == null)
                    _analyzeRepository = new AnalyzeRepository(_db);
                return _analyzeRepository;
            }
        }

        public IDoctorRepository Doctors
        {
            get
            {
                if (_doctorRepository == null)
                    _doctorRepository = new DoctorRepository(_db);
                return _doctorRepository;
            }
        }

        public IHospitalRepository Hospitals
        {
            get
            {
                if (_hospitalRepository == null)
                    _hospitalRepository = new HospitalRepository(_db);
                return _hospitalRepository;
            }
        }

        public IPatientRepository Patients
        {
            get
            {
                if (_patientRepository == null)
                    _patientRepository = new PatientRepository(_db);
                return _patientRepository;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_db);
                return _commentRepository;
            }
        }

        public IECGRepository ECGs
        {
            get
            {
                if (_ecgRepository == null)
                    _ecgRepository = new ECGRepository(_db);
                return _ecgRepository;
            }
        }

        public void Save()
        { 
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var message = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    message += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(message) ;
            }
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
    }
}
