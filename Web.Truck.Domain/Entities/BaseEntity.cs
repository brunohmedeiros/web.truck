using FluentValidation;
using FluentValidation.Results;
using System;

namespace Web.Truck.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            DataCadastro ??= DateTime.Now;
            Ativo ??= true;
        }

        public int Id { get; }
        public DateTime? DataCadastro { get; private set; }
        public bool? Ativo { get; private set; }
        public bool Valido { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public void Validar<T>(T entidade, AbstractValidator<T> validador)
        {
            ValidationResult = validador.Validate(entidade);
            Valido = ValidationResult.IsValid;
        }
    }
}
