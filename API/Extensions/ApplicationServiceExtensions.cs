using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>(); // Scoped will be used for the lifetime of http request
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            _ = services.Configure<ApiBehaviorOptions>(options =>
              {
                  options.InvalidModelStateResponseFactory = actionContext =>
                  {
                      var errors = actionContext.ModelState
                                  .Where(e => e.Value.Errors.Count > 0)
                                  .SelectMany(x => x.Value.Errors)
                                  .Select(x => x.ErrorMessage).ToArray();

                      var errorResponse = new ApiValidationErrorResponse
                      {
                          Errors = errors
                      };

                      return new BadRequestObjectResult(errorResponse);
                  };
              });

            return services;
        }
    }
}
