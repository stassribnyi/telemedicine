using System.Collections.Generic;
using Telemedicine.Business.Interfaces.CommonDto;

namespace Telemedicine.Business.Interfaces.Services.PatientService
{
    public interface IPatientService
    {
        /// <summary>
        /// Get all patients by doctor`s id, if id == null, return all patients
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<PatientDto> GetPatients(int? id);        
        PatientDto GetPatient(int id);
        PatientDto CreatePatient(PatientDto patient);
        void UpdatePatient(PatientDto patient);
        void RemovePatient(int id);
        /// <summary>
        /// Add comment by patient id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        CommentDto AddComment(int id, CommentDto comment);
    }
}
