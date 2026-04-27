using PatientManagement.Api.Models;

namespace PatientManagement.Api.Repositories
{
    public interface IPatientRepository
    {
        Patient? GetPatientById(int id);
    }
}