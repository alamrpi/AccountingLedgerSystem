import { useTrialBalance } from '../hooks/useTrialBalance';
import PageHeader from '../components/common/PageHeader';
import TrialBalanceTable from '../components/accounting/TrialBalanceTable';
import LoadingSpinner from '../components/common/LoadingSpinner';

const TrialBalancePage = () => {
  const { trialBalance, isLoading } = useTrialBalance();

  return (
    <div>
      <PageHeader
        title="Trial Balance"
        description="View the trial balance of all accounts"
      />

      {isLoading ? (
        <LoadingSpinner />
      ) : (
        <TrialBalanceTable trialBalance={trialBalance} />
      )}
    </div>
  );
};

export default TrialBalancePage;