using ClaroTestBackend.Core.Application.Interfaces;
using ClaroTestBackend.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClaroTestBackend.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            return services;
        }
    }
}
