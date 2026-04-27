using PatientManagement.Api.Models;

namespace PatientManagement.Api.Services
{
    public interface IPatientService
    {
        // using synchronous as we are using in memory database
        // In real world scenario (with database, EF core), it should be Task<Patient?> 
        Patient? GetPatientById(int id);
    }
}
