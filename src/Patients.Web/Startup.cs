using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patients.Domain;
using Patients.Core.Extensions;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using FluentValidation.AspNetCore;

namespace Patients.Web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PatientReqValidator>()); 

            services.AddDbContext<PatientContext>(options => options.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddSwaggerExamplesFromAssemblyOf<PatientReqExample>();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info { Title = "Patient API", Version = "v1.0" });
                options.ExampleFilters();
            });
            MapperConfiguration.Configure();
        }

        public void ConfigureContainer(ContainerBuilder builder) {
            builder.AddMediator(new Assembly[] { typeof(CreatePatientHandler).Assembly });
            builder.RegisterAssemblyTypes(typeof(PatientContext).Assembly).AsImplementedInterfaces();
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Patient API v1.0");
                options.RoutePrefix = string.Empty;
            });
            app.UseMvc();
            
        }
    }
}
