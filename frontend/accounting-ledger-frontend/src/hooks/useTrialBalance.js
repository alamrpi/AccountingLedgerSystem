import { useState, useEffect, useCallback } from 'react';
import { fetchTrialBalance } from '../api/accountingApi';
import { useNotification } from '../contexts/NotificationContext';

export const useTrialBalance = () => {
  const [trialBalance, setTrialBalance] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const { showNotification } = useNotification();

  const loadTrialBalance = useCallback(async () => {
    setIsLoading(true);
    try {
      const data = await fetchTrialBalance();
      setTrialBalance(data);
    } catch (error) {
      showNotification({
        type: 'error',
        message: error.message || 'Failed to load trial balance'
      });
    } finally {
      setIsLoading(false);
    }
  }, [showNotification]);

  useEffect(() => {
    loadTrialBalance();
  }, [loadTrialBalance]);

  return {
    trialBalance,
    isLoading,
    loadTrialBalance,
  };
};