using AutoMapper;
using LiveAuction.Application.Contracts.Infrastructure;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Application.Exceptions;
using LiveAuction.Application.Models.Mail;
using LiveAuction.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LiveAuction.Application.Features.Auctions.Commands.CreateAuction;

public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAuctionRepository _auctionRepository;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateAuctionCommandHandler> _logger;

    public CreateAuctionCommandHandler(
        IMapper mapper,
        IAuctionRepository auctionRepository,
        IEmailService emailService,
        ILogger<CreateAuctionCommandHandler> logger)
    {
        _mapper = mapper;
        _auctionRepository = auctionRepository;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateAuctionCommand request,
        CancellationToken cancellationToken)
    {
        var auction = _mapper.Map<Auction>(request);

        var validator = new CreateAuctionCommandValidator(_auctionRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        auction = await _auctionRepository.AddAsync(auction);

        //Sending email notification to admin address
        var email = new Email
        {
            To = "test@admin.test",
            Body = "test",
            Subject = "test"
        };

        try
        {
            await _emailService.SendEmailAsync(email);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Sending mail failed");
        }

        return auction.AuctionId;
    }
}