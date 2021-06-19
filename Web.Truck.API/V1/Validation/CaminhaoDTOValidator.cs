using FluentValidation;
using System;
using Web.Truck.Domain.DTOs.Caminhao;

namespace Web.Truck.API.V1.Validation
{
    public class CaminhaoDTOValidator : AbstractValidator<CaminhaoDTO>
    {
        public CaminhaoDTOValidator()
        {
            RuleFor(x => x)
                .Must(ValidarAnoFabricacao)
                .WithMessage("Ano de Fabricação deve ser o ano atual.");

            RuleFor(x => x)
                .Must(ValidarAnoModelo)
                .WithMessage("Ano do Modelo deve ser o ano atual ou subsequente.");
        }

        private static bool ValidarAnoFabricacao(CaminhaoDTO x)
        {
            return x.AnoFabricacao == DateTime.UtcNow.Year;
        }

        private static bool ValidarAnoModelo(CaminhaoDTO x)
        {
            return x.AnoModelo >= DateTime.UtcNow.Year && x.AnoModelo <= (DateTime.UtcNow.Year + 1);
        }

    }
}
