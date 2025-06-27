export const validateJournalEntry = (entry) => {
  const errors = {};
  let totalDebit = 0;
  let totalCredit = 0;

  // Validate each line
  const lineErrors = entry.journalEntryLines.map((line, index) => {
    const lineError = {};
    if (!line.accountId) {
      lineError.accountId = 'Account is required';
    }
    
    const debit = parseFloat(line.debit) || 0;
    const credit = parseFloat(line.credit) || 0;
    
    if (debit < 0 || credit < 0) {
      lineError.amount = 'Amount must be positive';
    }
    
    if (debit > 0 && credit > 0) {
      lineError.amount = 'Cannot have both debit and credit';
    }
    
    if (debit === 0 && credit === 0) {
      lineError.amount = 'Either debit or credit must be entered';
    }
    
    totalDebit += debit;
    totalCredit += credit;
    
    return Object.keys(lineError).length > 0 ? lineError : null;
  });

  if (lineErrors.some(error => error !== null)) {
    errors.lines = 'Some entry lines have errors';
  }

  // Validate totals
  if (totalDebit !== totalCredit) {
    errors.balance = 'Debit and credit totals must be equal';
  }

  // Validate description
  if (!entry.description?.trim()) {
    errors.description = 'Description is required';
  }

  return {
    isValid: Object.keys(errors).length === 0,
    errors,
    totalDebit,
    totalCredit,
  };
};