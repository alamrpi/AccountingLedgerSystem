using AccountingLedgerSystem.Application.Features.Queries.Reports;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("trialbalance")]
        public async Task<ActionResult<Dictionary<string, decimal>>> GetTrialBalance()
        {
            return await _mediator.Send(new GetTrialBalanceQuery());
        }
    }
}
