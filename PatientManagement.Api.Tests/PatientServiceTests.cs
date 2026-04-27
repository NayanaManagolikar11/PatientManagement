using FakeItEasy;
using PatientManagement.Api.Models;
using PatientManagement.Api.Repositories;
using PatientManagement.Api.Services;

namespace PatientManagement.Api.Tests
{
    public class PatientServiceTests
    {
        private readonly IPatientRepository _patientRepository = A.Fake<IPatientRepository>();
        private readonly IPatientService _patientService = A.Fake<IPatientService>();

        public PatientServiceTests()
        {
            _patientService = new PatientService(_patientRepository);
        }
        [Fact]
        public void GetPatientById_ReturnsPatient_WhenPatientExists()
        {
            // Arrange
            var patientId = 1;
            var patient = new Patient
            {
                Id = patientId,
                Name = "testPatient",
                NHSNumber = "1234567890",
                DateOfBirth = new DateTime(1970, 5, 12),
                GPPractice = "testPractice"
            };
            A.CallTo(() => _patientRepository.GetPatientById(patientId)).Returns(patient);

            // Act
            var result = _patientService.GetPatientById(patientId);

            // Assert
            A.CallTo(() => _patientRepository.GetPatientById(patientId)).MustHaveHappenedOnceExactly();
            Assert.NotNull(result);
            Assert.Equal(patientId, result.Id);
            Assert.Equal("testPatient", result.Name);
            Assert.Equal("1234567890", result.NHSNumber);
            Assert.Equal(new DateTime(1970, 5, 12), result.DateOfBirth);
            Assert.Equal("testPractice", result.GPPractice);
        }

        [Fact]
        public void GetPatientById_ReturnsNull_WhenPatientNotExists()
        {
            // Arrange
            var patientId = 99;            
            A.CallTo(() => _patientRepository.GetPatientById(patientId)).Returns(null);

            // Act
            var result = _patientService.GetPatientById(patientId);

            // Assert
            A.CallTo(() => _patientRepository.GetPatientById(patientId)).MustHaveHappenedOnceExactly();
            Assert.Null(result);
        }

        [Fact]
        public void GetPatientById_ReturnsNull_WhenPatientIdInvalid()
        {
            // Arrange
            var patientId = -1;
            A.CallTo(() => _patientRepository.GetPatientById(patientId)).Returns(null);

            // Act
            var result = _patientService.GetPatientById(patientId);

            // Assert
            A.CallTo(() => _patientRepository.GetPatientById(patientId)).MustNotHaveHappened();
            Assert.Null(result);
        }

    }
}
