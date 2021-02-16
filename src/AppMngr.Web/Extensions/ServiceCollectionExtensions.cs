using Microsoft.Extensions.DependencyInjection;

namespace AppMngr.Web
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IFileSavingService, FileSavingService>();
            services.AddScoped<IFileGettingService, FileGettingService>();
        }
    }
}