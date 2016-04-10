using System;
using Telemedicine.Domain.Interfaces.Repositories;

namespace Telemedicine.Domain.Interfaces.Common
{
    public interface IUnitOfWork : IDisposable
    {
       IDoctorRepository Doctors { get; }
       IPatientRepository Patients { get; }
       IAnalyzeRepository Analyzes { get; }
       IECGRepository ECGs { get; }
       IHospitalRepository Hospitals { get; }
       ICommentRepository Comments { get; }

        void Save();
    }
}
