using PatientManagement.Api.Services;
using PatientManagement.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PatientManagement.Api.EndPoints
{
    public static class PatientEndpoints
    {
        public static WebApplication AddPatientEndpoints(this WebApplication app)
        {
            app.MapGroup("/api")
                .AddGetPatientEndpoints();

            return app;
        }

        private static RouteGroupBuilder AddGetPatientEndpoints(this RouteGroupBuilder group)
        {
            var patientGroup = group
                .MapGroup("/patients")
                .WithTags("Patients");

            patientGroup.MapGet("{patientId:int}", GetPatientById)
                .Produces<Patient>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithName("GetPatientById");

            return group;
        }

        private static Results<Ok<Patient>, ProblemHttpResult> GetPatientById(IPatientService service, int patientId)
        {
            var patient = service.GetPatientById(patientId);

            return patient is not null
                ? TypedResults.Ok(patient)
                : TypedResults.Problem(
                    title: "Patient not found",
                    detail: $"The Requested Patient was not found.",
                    statusCode: StatusCodes.Status404NotFound);
        }
    }
}
