using System;

namespace Web.Truck.Domain.DTOs.Caminhao
{
    public class CaminhaoListDTO
    {
        public int Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool? Ativo { get; set; }
        public string Chassi { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }
}
