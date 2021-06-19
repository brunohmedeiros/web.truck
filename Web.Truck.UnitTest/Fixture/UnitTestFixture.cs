using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Web.Truck.Data.Context;
using Web.Truck.Data.UoW;
using Web.Truck.Domain.AutoMapper;
using Web.Truck.Domain.Interfaces.Data.UoW;
using Web.Truck.Domain.Interfaces.Services;
using Web.Truck.Domain.Interfaces.Utils;
using Web.Truck.Domain.Services;
using Web.Truck.Domain.Utils.Notification;

namespace Web.Truck.UnitTest.Fixture
{
    public class UnitTestFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public UnitTestFixture()
        {
            var serviceCollection = new ServiceCollection();

            // DI tests
            serviceCollection.AddDbContext<CaminhaoContext>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<ICaminhaoService, CaminhaoService>();
            serviceCollection.AddScoped<INotificationContext, NotificationContext>();
            serviceCollection.AddAutoMapper(Assembly.GetAssembly(typeof(CaminhaoMapper)));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
