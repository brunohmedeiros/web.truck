using FluentValidation;
using System;
using Web.Truck.Domain.Entities;

namespace Web.Truck.Domain.Validations
{
    public class CaminhaoValidator : AbstractValidator<Caminhao>
    {
        public CaminhaoValidator()
        {
            RuleFor(x => x.AnoFabricacao)
                .NotEqual(DateTime.UtcNow.Year)
                .WithMessage("Ano de Fabricação deve ser o ano atual.");

            RuleFor(x => x.AnoModelo)
                .ExclusiveBetween(DateTime.UtcNow.Year, DateTime.UtcNow.Year + 1)
                .WithMessage("Ano do Modelo deve ser o ano atual ou subsequente.");
        }
    }
}
