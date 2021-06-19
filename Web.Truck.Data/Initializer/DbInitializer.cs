using System.Linq;
using Web.Truck.Data.Context;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Data.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(CaminhaoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Modelo.Any())
            {
                return;
            }

            var modelos = new Modelo[]
            {
                new Modelo{Descricao = "FH"},
                new Modelo{Descricao = "FM"},
                new Modelo{Descricao = "PS"},
                new Modelo{Descricao = "TH"}
            };

            foreach (var item in modelos)
            {
                context.Modelo.Add(item);
            }

            context.SaveChanges();
        }
    }
}
