import { useJournalEntries } from '../hooks/useJournalEntries';
import { useAccounts } from '../hooks/useAccounts';
import { useNavigate } from 'react-router-dom';
import PageHeader from '../components/common/PageHeader';
import JournalEntryForm from '../components/accounting/JournalEntryForm';
import LoadingSpinner from '../components/common/LoadingSpinner';

const JournalEntryPage = () => {
  const { accounts, isLoading: isLoadingAccounts } = useAccounts();
  const { addEntry, isLoading: isSubmitting } = useJournalEntries();
  const navigate = useNavigate();
  
  const handleSubmit = async (formData) => {
    await addEntry(formData);
     navigate('/journal-entries');
  };

  return (
    <div>
      <PageHeader
        title="Add Journal Entry"
        description="Create a new journal entry following double-entry accounting principles"
      />

      {isLoadingAccounts ? (
        <LoadingSpinner />
      ) : (
        <JournalEntryForm
          accounts={accounts}
          onSubmit={handleSubmit}
          isLoading={isSubmitting}
        />
      )}
    </div>
  );
};

export default JournalEntryPage;