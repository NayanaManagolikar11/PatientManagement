using PatientManagement.Api.Models;

namespace PatientManagement.Api.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IReadOnlyList<Patient> _patients =
        [
            new Patient
            {
                Id = 1,
                NHSNumber = "6344534421",
                Name = "TestName1",
                DateOfBirth = new DateTime(1990, 3, 10),
                GPPractice = "TestPractice1"
            },
            new Patient
            {
                Id = 2,
                NHSNumber = "6745267934",
                Name = "TestName2",
                DateOfBirth = new DateTime(1993, 6, 15),
                GPPractice = "TestPractice2"
            },
            new Patient
            {
                Id = 3,
                NHSNumber = "2319873012",
                Name = "TestName3",
                DateOfBirth = new DateTime(1978, 1, 20),
                GPPractice = "TestPractice1"
            },
            new Patient
            {
                Id = 4,
                NHSNumber = "8750285092",
                Name = "TestName4",
                DateOfBirth = new DateTime(2000, 7, 18),
                GPPractice = "TestPractice3"
            },
        ];

        public Patient? GetPatientById(int PatientId)
        {
            return _patients.FirstOrDefault(p =>  p.Id == PatientId);
        }
    }
}
