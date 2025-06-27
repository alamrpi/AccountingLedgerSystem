using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Application.Features.Commands.JournalEntries;
using AccountingLedgerSystem.Application.Features.Queries.JournalEntries;
using AccountingLedgerSystem.Application.Validators;
using AccountingLedgerSystem.Shared.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Text.Json;

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
        /// Retrieves journal entries with pagination support
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/journal-entries?pageNumber=1&amp;pageSize=10
        /// </remarks>
        /// <param name="pageNumber">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 10)</param>
        /// <response code="200">Returns the paginated list of journal entries</response>
        /// <response code="400">If pagination parameters are invalid</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<JournalEntryWithLinesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            _logger.LogInformation("Fetching journal entries - Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);

            // Validate pagination parameters
            if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
            {
                _logger.LogWarning("Invalid pagination parameters - Page: {PageNumber}, Size: {PageSize}", pageNumber, pageSize);
                return BadRequest("Page number must be greater than 0 and page size must be between 1 and 100");
            }

            try
            {
                var result = await _mediator.Send(new GetJournalEntriesQuery(pageNumber, pageSize));

                _logger.LogInformation(
                    "Retrieved {Count} journal entries (Page {PageNumber} of {TotalPages})",
                    result.Items.Count(),
                    pageNumber,
                    result.TotalPages);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error fetching journal entries - Page {PageNumber}, Size {PageSize}",
                    pageNumber,
                    pageSize);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request");
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