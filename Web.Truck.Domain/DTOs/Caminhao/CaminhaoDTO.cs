using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Truck.Domain.DTOs.Caminhao
{
    public class CaminhaoDTO
    {
        public int? Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool? Ativo { get; set; }
        public string Chassi { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }
}
