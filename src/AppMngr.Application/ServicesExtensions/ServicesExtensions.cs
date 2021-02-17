using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AppMngr.Application
{
    public static class ServicesExtensions
    {
        public static void AddApplicationLayerServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}