using Institute.Application;
using Institute.Domain;
using Institute.Services;
using Microsoft.Extensions.DependencyInjection;


class Program
{
    static void Main(string[] args)
    {

        var services = new ServiceCollection();

        services.AddTransient<PublicState>();
        services.AddTransient<PrivateState>();
        services.AddTransient<Func<InstituteType, IInstituteState>>(serviceProvider => type =>
        {
            return type == Institute.Domain.InstituteType.PublicSchool
                ? serviceProvider.GetRequiredService<PublicState>()
                : serviceProvider.GetRequiredService<PrivateState>();
        });
        services.AddScoped<SchoolEnrollment>();

        services.AddTransient<IEnrollService, EnrollService>();

        var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var schoolEnrollment = scope.ServiceProvider.GetService<SchoolEnrollment>();

        try
        {
            schoolEnrollment.EnrollSchool("Private HighSchool", 10000, Institute.Domain.InstituteType.PrivateSchool);
            schoolEnrollment.EnrollSchool("Public HighSchool", 10000, Institute.Domain.InstituteType.PublicSchool);
            Console.WriteLine("School enrollment completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}