using ClaroTestBackend.Core.Domain.Interfaces.Repositories;
using ClaroTestBackend.Infrastructure.Persistence.Repositories.HttpClientRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaroTestBackend.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var baseApiUrl = configuration["ExternalApi:BaseUrl"]
                ?? throw new InvalidOperationException("External API base URL is missing.");

            services.AddHttpClient<IBookRepository, BookRepository>(client =>
            {
                client.BaseAddress = new Uri(baseApiUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            services.AddHttpClient<IAuthorRepository, AuthorRepository>(client =>
            {
                client.BaseAddress = new Uri(baseApiUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            return services;
        }
    }
}
