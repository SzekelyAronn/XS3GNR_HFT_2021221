using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Data;
using XS3GNR_HFT_2021221.Logic;
using XS3GNR_HFT_2021221.Repository;

namespace XS3GNR_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<IFacultyLogic, FacultyLogic>();
            services.AddTransient<IUniversityLogic, UniversityLogic>();

            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IUniRepository, UniRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<UnistudfacDBContext, UnistudfacDBContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:46369"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
