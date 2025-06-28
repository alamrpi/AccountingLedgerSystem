using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Application.Features.Commands.Accounts;
using AccountingLedgerSystem.Application.Features.Queries.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AccountingLedgerSystem.API.Controllers;

/// <summary>
/// Controller for managing account operations in the Accounting Ledger System
/// </summary>
[ApiController]
[Route("api/accounts")]
[Produces("application/json")]
public sealed class AccountsController(IMediator mediator, ILogger<AccountsController> logger) : ControllerBase
{
    private readonly ActivitySource _activitySource = new(nameof(AccountsController));

    /// <summary>
    /// Retrieves all accounts in the system
    /// </summary>
    /// <response code="200">Returns the list of accounts</response>
    /// <response code="500">Internal server error</response>
    [HttpGet(Name = "GetAllAccounts")]
    [ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAccounts()
    {
        using var activity = _activitySource.StartActivity(nameof(GetAllAccounts));
        using var scope = logger.BeginScope("GET {Endpoint}", nameof(GetAllAccounts));

        try
        {
            logger.LogDebug("Retrieving all accounts");
            var result = await mediator.Send(new GetAccountsQuery());
            logger.LogInformation("Retrieved {Count} accounts", result.Count);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving accounts");
            return Problem(
                title: "Error retrieving accounts",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Creates a new account in the system
    /// </summary>
    /// <param name="request">Account creation data</param>
    /// <response code="201">Account created successfully</response>
    /// <response code="400">Invalid request data</response>
    /// <response code="500">Internal server error</response>
    [HttpPost(Name = "CreateAccount")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequestDto request)
    {
        using var activity = _activitySource.StartActivity(nameof(CreateAccount));
        using var scope = logger.BeginScope("POST {Endpoint} for {AccountName}", nameof(CreateAccount), request.Name);

        if (!ModelState.IsValid)
            return InvalidModel(request);

        try
        {
            logger.LogDebug("Creating account {@AccountRequest}", request);
            var id = await mediator.Send(new CreateAccountCommand(request));

            logger.LogInformation("Account created with ID: {AccountId}", id);
            return CreatedAtRoute("GetAllAccounts", new { id }, id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating account {@Request}", request);
            return Problem(
                title: "Error creating account",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    private IActionResult InvalidModel(AccountCreateRequestDto request)
    {
        logger.LogWarning("Invalid request data {@Request}", request);
        return ValidationProblem(ModelState);
    }
}