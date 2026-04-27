using PatientManagement.Api.Models;
using PatientManagement.Api.Repositories;

namespace PatientManagement.Api.Services
{
    public class PatientService(IPatientRepository patientRepository) : IPatientService
    {
        public Patient? GetPatientById(int patientId)
        {
            if (patientId <= 0) return null;

            return patientRepository.GetPatientById(patientId);
        }
    }
}
