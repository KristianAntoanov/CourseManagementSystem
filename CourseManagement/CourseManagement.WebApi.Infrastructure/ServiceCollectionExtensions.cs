using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CourseManagement.Data;

namespace CourseManagement.WebApi.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }

    public static void RegisterUserDefinedServices(this IServiceCollection services, Assembly serviceAssembly)
    {
        Type[] serviceInterfaceTypes = serviceAssembly
            .GetTypes()
            .Where(t => t.IsInterface)
            .ToArray();
        Type[] serviceTypes = serviceAssembly
            .GetTypes()
            .Where(t => !t.IsInterface && !t.IsAbstract &&
                         t.Name.ToLower().EndsWith("service"))
            .ToArray();

        foreach (Type serviceInterfaceType in serviceInterfaceTypes)
        {
            Type? serviceType = serviceTypes
                .SingleOrDefault(t => "i" + t.Name.ToLower() == serviceInterfaceType.Name.ToLower());
            if (serviceType == null)
            {
                throw new NullReferenceException($"Service type could not be obtained for the service {serviceInterfaceType.Name}");
            }

            services.AddScoped(serviceInterfaceType, serviceType);
        }
    }
}