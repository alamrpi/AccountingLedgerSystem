import { useState, useMemo } from 'react';
import PropTypes from 'prop-types';
import { PlusIcon, TrashIcon } from '@heroicons/react/outline';
import Button from '../common/Button';
import Input from '../common/Input';
import Select from '../common/Select';
import { formatCurrency } from '../../utils/formatters';
import { validateJournalEntry } from '../../utils/validators';

const JournalEntryForm = ({ accounts, onSubmit, isLoading }) => {
  const [entryData, setEntryData] = useState({
    date: new Date().toISOString().split('T')[0],
    description: '',
    journalEntryLines: [
      { accountId: '', debit: 0, credit: 0 },
      { accountId: '', debit: 0, credit: 0 },
    ],
  });

  const { isValid, errors, totalDebit, totalCredit } = useMemo(
    () => validateJournalEntry(entryData),
    [entryData]
  );

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEntryData(prev => ({ ...prev, [name]: value }));
  };

  const handleLineChange = (index, field, value) => {
    const updatedLines = [...entryData.journalEntryLines];
    updatedLines[index] = { ...updatedLines[index], [field]: value };
    
    // Reset the opposite field
    if (field === 'debit' && value > 0) {
      updatedLines[index].credit = 0;
    } else if (field === 'credit' && value > 0) {
      updatedLines[index].debit = 0;
    }

    setEntryData(prev => ({ ...prev, journalEntryLines: updatedLines }));
  };

  const addLine = () => {
    setEntryData(prev => ({
      ...prev,
      journalEntryLines: [...prev.journalEntryLines, { accountId: '', debit: 0, credit: 0 }],
    }));
  };

  const removeLine = (index) => {
    if (entryData.journalEntryLines.length <= 2) return;
    setEntryData(prev => ({
      ...prev,
      journalEntryLines: prev.journalEntryLines.filter((_, i) => i !== index),
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!isValid) return;
    
    const payload = {
      ...entryData,
      journalEntryLines: entryData.journalEntryLines.map(line => ({
        accountId: line.accountId,
        debit: parseFloat(line.debit),
        credit: parseFloat(line.credit),
      })),
    };

    onSubmit(payload);
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-6">
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        <Input
          label="Date"
          type="date"
          name="date"
          value={entryData.date}
          onChange={handleChange}
          required
        />

        <Input
          label="Description"
          name="description"
          value={entryData.description}
          onChange={handleChange}
          required
        />
      </div>

      <div className="space-y-4">
        <h3 className="font-medium">Entry Lines</h3>
        
        {entryData.journalEntryLines.map((line, index) => (
          <div key={index} className="grid grid-cols-12 gap-4 items-end">
            <div className="col-span-5">
              <Select
                label={`Account ${index + 1}`}
                value={line.accountId}
                onChange={(e) => handleLineChange(index, 'accountId', e.target.value)}
                options={accounts.map(acc => ({ value: acc.id, label: acc.name }))}
                required
              />
            </div>

            <div className="col-span-3">
              <Input
                label="Debit"
                type="number"
                min="0"
                step="0.01"
                value={line.debit}
                onChange={(e) => handleLineChange(index, 'debit', e.target.value)}
              />
            </div>

            <div className="col-span-3">
              <Input
                label="Credit"
                type="number"
                min="0"
                step="0.01"
                value={line.credit}
                onChange={(e) => handleLineChange(index, 'credit', e.target.value)}
              />
            </div>

            <div className="col-span-1">
              {entryData.journalEntryLines.length > 2 && (
                <button
                  type="button"
                  onClick={() => removeLine(index)}
                  className="text-red-500 hover:text-red-700"
                >
                  <TrashIcon className="h-5 w-5" />
                </button>
              )}
            </div>
          </div>
        ))}

       <Button
          type="button"
          variant="secondary"
          onClick={addLine}
        >
          <div className="flex items-center gap-2">
            <PlusIcon className="h-4 w-4" />
            <span>Add Line</span>
          </div>
        </Button>
      </div>

      <div className="flex justify-between items-center pt-4 border-t border-gray-200">
        <div className="space-x-4">
          <span className="font-medium">Total Debit: {formatCurrency(totalDebit)}</span>
          <span className="font-medium">Total Credit: {formatCurrency(totalCredit)}</span>
          {!isValid && (
            <span className="text-red-500 text-sm">
              {errors.lines || errors.balance}
            </span>
          )}
        </div>

        <Button type="submit" disabled={!isValid} isLoading={isLoading}>
          Post Journal Entry
        </Button>
      </div>
    </form>
  );
};

JournalEntryForm.propTypes = {
  accounts: PropTypes.array.isRequired,
  onSubmit: PropTypes.func.isRequired,
  isLoading: PropTypes.bool,
};

export default JournalEntryForm;