using FluentValidation;
using FluentValidation.Results;
using System;

namespace Web.Truck.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            DataCadastroUtc ??= DateTime.UtcNow;
            Ativo ??= true;
        }

        public int Id { get; }
        public DateTime? DataCadastroUtc { get; private set; }
        public bool? Ativo { get; private set; }
        public bool Valido { get; private set; }

        public void Validar<T>(T entidade, AbstractValidator<T> validador)
        {
            ValidationResult validacao = validador.Validate(entidade);
            Valido = validacao.IsValid;
        }
    }
}
