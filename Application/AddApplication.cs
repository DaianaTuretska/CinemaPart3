using Application.AllServices.ValidatorServices;
using Application.DTO.Request.ReservControllerRequest;
using Application.Interfaces.ServicesInterfaces;
using Application.Interfaces.ValidatorServicesInterfaces;
using Application.MappingProfiles.AutoMapperProfiles;
using Application.MappingProfiles.MongoDbProfiles;
using Application.Validators.PostValidators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{ 
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AddMongoProfiles.Configure();
            services.AddAutoMapper(typeof(ReservProfile), typeof(ReservProfile),typeof(ReservProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IReservValidatorService, ReservValidatorService>();
            services.AddScoped<IValidator<NewReservReqModel>, NewReservValidator>();
            return services;
        }
    }
}
