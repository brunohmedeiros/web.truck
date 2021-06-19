using System.Collections.Generic;

namespace Web.Truck.Domain.Entities
{
    public class Modelo : BaseEntity
    {       
        public string Descricao { get; set; }

        public ICollection<Caminhao> Caminhaos { get; set; }
    }
}
