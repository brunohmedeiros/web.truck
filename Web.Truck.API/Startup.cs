using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Web.Truck.Data.Context;
using Web.Truck.Data.Initializer;
using Web.Truck.Data.UoW;
using Web.Truck.Domain.AutoMapper;
using Web.Truck.Domain.Interfaces.Data.UoW;
using Web.Truck.Domain.Interfaces.Services;
using Web.Truck.Domain.Interfaces.Utils;
using Web.Truck.Domain.Services;
using Web.Truck.Domain.Utils.Notification;

namespace Web.Truck
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc(config => { })
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            // DI
            services.AddDbContext<CaminhaoContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICaminhaoService, CaminhaoService>();
            services.AddScoped<INotificationContext, NotificationContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.Truck", Version = "v1" });
            });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(CaminhaoMapper)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web.Truck v1"));

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var Scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = Scope.ServiceProvider.GetService<CaminhaoContext>();
            DbInitializer.Initialize(context);
        }
    }
}
