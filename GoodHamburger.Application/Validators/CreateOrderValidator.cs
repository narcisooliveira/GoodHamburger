using FluentValidation;
using GoodHamburger.Application.UseCases;

namespace GoodHamburger.Application.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("O pedido deve conter ao menos um item");

        RuleForEach(x => x.Items)
            .IsInEnum().WithMessage("Item inválido");
    }
}