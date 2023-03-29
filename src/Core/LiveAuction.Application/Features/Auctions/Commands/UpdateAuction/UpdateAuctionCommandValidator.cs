using FluentValidation;

namespace LiveAuction.Application.Features.Auctions.Commands.UpdateAuction;

public class UpdateAuctionCommandValidator : AbstractValidator<UpdateAuctionCommand>
{
    public UpdateAuctionCommandValidator()
    {

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.CreatedDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);

        RuleFor(p => p.Price)
           .NotEmpty().WithMessage("{PropertyName} is required.")
        .GreaterThan(0);
    }
}