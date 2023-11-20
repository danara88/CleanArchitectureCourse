using GymManagement.Application.Subscriptions.Commands;
using GymManagement.Application.Subscriptions.Queries;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    // We can use ISender to have smaller interface here
    private readonly ISender _mediator;

    public SubscriptionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        // Presentation layer is responsible for converting data from the presentation to business Enums in our domain layer
        if (!DomainSubscriptionType.TryFromName(request.subscriptionType.ToString(), out var subscriptionType))
        {
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid subscription type");
        }

        var command = new CreateSubscriptionCommand(request.adminId, subscriptionType);

        var createSubscriptionResult = await _mediator.Send(command);

        return createSubscriptionResult.Match(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.subscriptionType)),
            error => Problem()
        );
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
        var query = new GetSubscriptionQuery(subscriptionId);

        var getSubscriptionResult = await _mediator.Send(query);

        return getSubscriptionResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id, Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name!))),
            error => Problem()
        );
    }
}
