using MediatR;

namespace AccountingLedgerSystem.Application.Features.Queries.Reports
{
    public class GetTrialBalanceQuery : IRequest<Dictionary<string, decimal>> { }
}
