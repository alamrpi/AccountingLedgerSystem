using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Application.Features.Queries.Reports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AccountingLedgerSystem.API.Controllers
{
    /// <summary>
    /// API endpoints for financial reporting
    /// </summary>
    [ApiController]
    [Route("api/reports")]
    [Produces("application/json")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(
            IMediator mediator,
            ILogger<ReportsController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Retrieves trial balance report
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/reports/trialbalance
        /// </remarks>
        /// <response code="200">Returns the trial balance data</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("trialbalance")]
        [ProducesResponseType(typeof(TrialBalanceDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTrialBalance()
        {
            try
            {
                _logger.LogInformation("Starting trial balance report generation");

                var result = await _mediator.Send(new GetTrialBalanceQuery());

                _logger.LogInformation("Successfully generated trial balance report");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating trial balance report");
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ProblemDetails
                    {
                        Title = "Error generating report",
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = "An error occurred while generating the trial balance report",
                        Instance = HttpContext.Request.Path
                    });
            }
        }
    }
}