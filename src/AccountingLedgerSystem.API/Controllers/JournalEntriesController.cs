using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Application.Features.Commands.JournalEntries;
using AccountingLedgerSystem.Application.Features.Queries.JournalEntries;
using AccountingLedgerSystem.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.ComponentModel.DataAnnotations;

namespace AccountingLedgerSystem.API.Controllers
{
    /// <summary>
    /// API endpoints for managing journal entries in the accounting ledger system
    /// </summary>
    [ApiController]
    [Route("api/journal-entries")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class JournalEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JournalEntryValidator _validator;
        private readonly ILogger<JournalEntriesController> _logger;

        public JournalEntriesController(
            IMediator mediator,
            JournalEntryValidator validator,
            ILogger<JournalEntriesController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Retrieves all journal entries from the ledger
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/journal-entries
        /// </remarks>
        /// <response code="200">Returns the list of journal entries</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<JournalEntryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Starting to fetch all journal entries");
            try
            {
                var entries = await _mediator.Send(new GetJournalEntriesQuery());
                _logger.LogInformation("Successfully retrieved {Count} journal entries", entries.Items.Count());
                return Ok(entries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching journal entries");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request");
            }
        }

        /// <summary>
        /// Creates a new journal entry in the ledger
        /// </summary>
        /// <param name="entryDto">Journal entry data transfer object</param>
        /// <response code="201">Returns the ID of the newly created journal entry</response>
        /// <response code="400">If the input data is invalid</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody][Required] JournalEntryRequestDto entryDto)
        {
            using var scope = _logger.BeginScope("Creating journal entry for account {AccountCode}", entryDto.Description);
            _logger.LogInformation("Starting journal entry creation");

            try
            {
                _logger.LogDebug("Validating journal entry data");
                var validationResult = await _validator.ValidateAsync(entryDto);

                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Validation failed with {ErrorCount} errors", validationResult.Errors.Count);
                    return BadRequest(new
                    {
                        Title = "Validation Error",
                        Status = StatusCodes.Status400BadRequest,
                        Errors = validationResult.Errors.Select(e => new
                        {
                            Field = e.PropertyName,
                            Message = e.ErrorMessage
                        })
                    });
                }

                _logger.LogDebug("Sending create journal entry command");
                var entryId = await _mediator.Send(new CreateJournalEntryCommand(entryDto));

                _logger.LogInformation("Successfully created journal entry with ID {EntryId}", entryId);

                return CreatedAtAction(
                    actionName: nameof(GetAll),
                    value: new { id = entryId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating journal entry");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ProblemDetails
                    {
                        Title = "Internal Server Error",
                        Status = StatusCodes.Status500InternalServerError,
                        Detail = "An unexpected error occurred while processing your request"
                    });
            }
        }
    }
}