﻿using Web.Truck.Domain.Validations;

namespace Web.Truck.Domain.Entities
{
    public class Caminhao : BaseEntity
    {

        public Caminhao()
        {
            Validar(this, new CaminhaoValidator());
        }

        public string Chassi { get; set; }
        public int ModeloId { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }

        public virtual Modelo Modelo { get; }
    }
}