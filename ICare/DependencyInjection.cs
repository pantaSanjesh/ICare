using ICare.Business.Business;
using ICare.Business.Business.SanctionScreeningBusiness;
using ICare.Business.Business.StaticValuesBusiness;
using ICare.Repository.Repository.Common;
using ICare.Repository.Repository.SanctionScreeningRepository;
using ICare.Repository.Repository.StaticValuesRepository;
using ICare.Repository.Repository.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddImplementationMethods(this IServiceCollection services)
        {
            services.AddScoped<ITestBusiness, TestBusiness>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IRepositoryDao, RepositoryDao>();                 
            services.AddScoped<ISanctionScreeningBusiness, SanctionScreeningBusiness>();
            services.AddScoped<ISanctionScreeningRepository, SanctionScreeningRepository>();
            services.AddScoped<IStaticValuesBusiness, StaticValuesBusiness>();
            services.AddScoped<IStaticValuesRepository, StaticValuesRepository>();
            
            return services;
        }
    }
}
