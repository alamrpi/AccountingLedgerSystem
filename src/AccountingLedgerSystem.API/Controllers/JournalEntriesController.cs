using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Application.Features.Commands.JournalEntries;
using AccountingLedgerSystem.Application.Features.Queries.JournalEntries;
using AccountingLedgerSystem.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JournalEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<JournalEntryDto>>> Get()
        {
            return await _mediator.Send(new GetJournalEntriesQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(JournalEntryDto entryDto)
        {
            var validator = new JournalEntryValidator();
            var validationResult = await validator.ValidateAsync(entryDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return await _mediator.Send(new CreateJournalEntryCommand (entryDto));
        }
    }
}
