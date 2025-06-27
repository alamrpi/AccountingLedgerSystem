import PropTypes from 'prop-types';
import { formatDate, formatCurrency } from '../../utils/formatters';
import { useEffect } from 'react';

const JournalEntryTable = ({ entries }) => {
  return (
    <div className="overflow-x-auto">
      <table className="min-w-full divide-y divide-gray-200">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Date
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Description
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Account
            </th>
             <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider text-right">
              Amount
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider text-right">
              Debit
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider text-right">
              Credit
            </th>
           
          </tr>
        </thead>
        <tbody className="bg-white divide-y divide-gray-200">
          {entries.map((entry) => (
            <tr key={entry.id}>
              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                {formatDate(entry.date)}
              </td>
              <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                {entry.description}
              </td>
              <td className="px-6 py-4 text-sm text-gray-500">
                {entry.name}
              </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500 text-right">
                { formatCurrency(entry.amount) }
              </td>
              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500 text-right">
                 {entry.debit > 0 ? formatCurrency(entry.debit) : '-'}
              
              </td>
              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500 text-right">
                {entry.credit > 0 ? formatCurrency(entry.credit) : '-'}
              </td>
             
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

JournalEntryTable.propTypes = {
  entries: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.string.isRequired,
      date: PropTypes.string.isRequired,
      description: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
      debit: PropTypes.number.isRequired,
      credit: PropTypes.number.isRequired,
      amount: PropTypes.number.isRequired,
      // Add other fields as necessary
    })
  ).isRequired,
};

export default JournalEntryTable;