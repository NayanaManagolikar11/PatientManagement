using PatientManagement.Api.Repositories;
using PatientManagement.Api.Services;

namespace PatientManagement.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
