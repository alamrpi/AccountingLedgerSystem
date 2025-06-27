import PropTypes from 'prop-types';
import { formatCurrency } from '../../utils/formatters';

const TrialBalanceTable = ({ trialBalance }) => {
  return (
    <div className="overflow-x-auto">
      <table className="min-w-full divide-y divide-gray-200">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Account
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Type
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Debit
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Credit
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Net Balance
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Financial Statement
            </th>
          </tr>
        </thead>
        <tbody className="bg-white divide-y divide-gray-200">
          {trialBalance.map((account) => (
            <tr key={account.accountId}>
              <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                {account.accountName}
              </td>
              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                {account.accountType}
              </td>
              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                {formatCurrency(account.debitTotal)}
              </td>
              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                {formatCurrency(account.creditTotal)}
              </td>
              <td className="px-6 py-4 whitespace-nowrap text-sm font-medium">
                {account.balance > 0
                  ? `${formatCurrency(account.balance)} DR`
                  : `${formatCurrency(Math.abs(account.balance))} CR`}
              </td>
               <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                {account.financialStatement}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

TrialBalanceTable.propTypes = {
  trialBalance: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
      type: PropTypes.string.isRequired,
      debit: PropTypes.number.isRequired,
      credit: PropTypes.number.isRequired,
      netBalance: PropTypes.number.isRequired,
    })
  ).isRequired,
};

export default TrialBalanceTable;