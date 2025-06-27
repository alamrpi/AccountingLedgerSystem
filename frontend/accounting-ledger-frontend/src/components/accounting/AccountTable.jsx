import PropTypes from 'prop-types';
import { useState } from 'react';

const AccountTable = ({ accounts }) => {
  // Group accounts by type
  const groupedAccounts = accounts.reduce((acc, account) => {
    if (!acc[account.type]) {
      acc[account.type] = [];
    }
    acc[account.type].push(account);
    return acc;
  }, {});

  // State to track expanded types
  const [expandedTypes, setExpandedTypes] = useState({});

  const toggleType = (type) => {
    setExpandedTypes(prev => ({
      ...prev,
      [type]: !prev[type]
    }));
  };

  return (
    <div className="space-y-1">
      {Object.entries(groupedAccounts).map(([type, typeAccounts]) => (
        <div key={type} className="border border-gray-200 rounded">
          <button
            onClick={() => toggleType(type)}
            className="w-full px-4 py-2 text-left text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none flex justify-between items-center"
          >
            <span>
              {type} <span className="text-gray-500">({typeAccounts.length})</span>
            </span>
            <svg
              className={`w-4 h-4 transform transition-transform ${expandedTypes[type] ? 'rotate-180' : ''}`}
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 9l-7 7-7-7" />
            </svg>
          </button>
          
          {expandedTypes[type] && (
            <div className="border-t border-gray-200">
              <div className="px-4 py-2 space-y-1">
                {typeAccounts.map(account => (
                  <div key={account.id} className="flex justify-between text-sm">
                    <span className="text-gray-800 truncate">{account.name}</span>
                    <small className="text-gray-500 font-mono">{account.description}</small>
                  </div>
                ))}
              </div>
            </div>
          )}
        </div>
      ))}
    </div>
  );
};

AccountTable.propTypes = {
  accounts: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
      type: PropTypes.string.isRequired,
    })
  ).isRequired,
};

export default AccountTable;