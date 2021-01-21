using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ClinicSchedule.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}