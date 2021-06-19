using FluentValidation;
using System;
using Web.Truck.Domain.DTOs.Caminhao;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Domain.Validations
{
    public class CaminhaoValidator : AbstractValidator<Caminhao>
    {
        public CaminhaoValidator()
        {
            RuleFor(x => x)
                .Must(ValidarAnoFabricacao)
                .WithMessage("Ano de Fabricação deve ser o ano atual.");

            RuleFor(x => x)
                .Must(ValidarAnoModelo)
                .WithMessage("Ano do Modelo deve ser o ano atual ou subsequente.");
        }

        private static bool ValidarAnoFabricacao(Caminhao x)
        {
            return x.AnoFabricacao == DateTime.UtcNow.Year;
        }

        private static bool ValidarAnoModelo(Caminhao x)
        {
            return x.AnoModelo >= DateTime.UtcNow.Year && x.AnoModelo <= (DateTime.UtcNow.Year + 1);
        }
    }
}
