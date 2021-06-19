using AutoMapper;
using Web.Truck.Domain.DTOs.Caminhao;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Domain.AutoMapper
{
    public class CaminhaoMapper : Profile
    {
        public CaminhaoMapper()
        {
            CreateMap<CaminhaoDTO, Caminhao>()
                .ConstructUsing(x => new Caminhao(x.Chassi, x.AnoFabricacao, x.AnoModelo));

            CreateMap<CaminhaoListDTO, Caminhao>()
                .ForPath(x => x.Modelo.Descricao, opts => opts.MapFrom(src => src.Modelo))
                .ReverseMap();
        }
    }
}
