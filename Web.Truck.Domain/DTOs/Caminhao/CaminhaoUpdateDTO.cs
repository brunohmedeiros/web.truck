
namespace Web.Truck.Domain.DTOs.Caminhao
{
    public class CaminhaoUpdateDTO
    {
        public int? Id { get; set; }
        public string Chassi { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }
}
