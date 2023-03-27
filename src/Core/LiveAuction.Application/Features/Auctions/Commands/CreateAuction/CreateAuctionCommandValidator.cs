using FluentValidation;
using LiveAuction.Application.Contracts.Persistence;

namespace LiveAuction.Application.Features.Auctions.Commands.CreateAuction;

public class CreateAuctionCommandValidator : AbstractValidator<CreateAuctionCommand>
{
    private readonly IAuctionRepository _auctionRepository;

    public CreateAuctionCommandValidator(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.CreatedDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);

        RuleFor(e => e)
            .MustAsync(AuctionNameAndDateUnique)
            .WithMessage("An auction wit the same name and date already exists");

        RuleFor(p => p.Price)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .GreaterThan(0);
    }

    private async Task<bool> AuctionNameAndDateUnique(CreateAuctionCommand e,
        CancellationToken cancellationToken)
        => !await _auctionRepository.IsAuctionNameAndDateUnique(e.Name, e.CreatedDate);
}