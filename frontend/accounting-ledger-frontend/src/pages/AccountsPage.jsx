import { useAccounts } from '../hooks/useAccounts';
import PageHeader from '../components/common/PageHeader';
import AccountForm from '../components/accounting/AccountForm';
import AccountTable from '../components/accounting/AccountTable';
import LoadingSpinner from '../components/common/LoadingSpinner';

const AccountsPage = () => {
  const { accounts, isLoading, addAccount } = useAccounts();

  const handleSubmit = async (formData) => {
    await addAccount(formData);
  };

  return (
    <div>
      <PageHeader
        title="Accounts"
        description="Manage your chart of accounts"
      />

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
        <div>
          <h2 className="text-lg font-medium mb-4">Add New Account</h2>
          <AccountForm onSubmit={handleSubmit} isLoading={isLoading} />
        </div>

        <div>
          <h2 className="text-lg font-medium mb-4">Account List</h2>
          {isLoading && accounts.length === 0 ? (
            <LoadingSpinner />
          ) : (
            <AccountTable accounts={accounts} />
          )}
        </div>
      </div>
    </div>
  );
};

export default AccountsPage;