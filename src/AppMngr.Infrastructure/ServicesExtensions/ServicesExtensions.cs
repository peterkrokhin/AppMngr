using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddInfrastructureLayerServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IAppDbContext, AppDbContext>(options => options.UseSqlite(connectionString));
            services.AddScoped<IAppRepo, AppRepo>();
            services.AddScoped<IAppTypeRepo, AppTypeRepo>();
            services.AddScoped<IStatusRepo, StatusRepo>();
            services.AddScoped<INumFieldRepo, NumFieldRepo>();
            services.AddScoped<IStringFieldRepo, StringFieldRepo>();
            services.AddScoped<IDateFieldRepo, DateFieldRepo>();
            services.AddScoped<ITimeFieldRepo, TimeFieldRepo>();
            services.AddScoped<IFileMetaDataRepo, FileMetaDataRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUOW, UOW>();
        }
    }
}