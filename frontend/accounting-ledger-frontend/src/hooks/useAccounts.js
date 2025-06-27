import { useState, useEffect, useCallback } from 'react';
import { fetchAccounts, createAccount } from '../api/accountingApi';
import { useNotification } from '../contexts/NotificationContext';

export const useAccounts = () => {
  const [accounts, setAccounts] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const { showNotification } = useNotification();

  const loadAccounts = useCallback(async () => {
    setIsLoading(true);
    try {
      const data = await fetchAccounts();
      setAccounts(data);
    } catch (error) {
      showNotification({
        type: 'error',
        message: error.message || 'Failed to load accounts'
      });
    } finally {
      setIsLoading(false);
    }
  }, [showNotification]);

  const addAccount = useCallback(async (accountData) => {
    setIsLoading(true);
    try {
      const newAccount = await createAccount(accountData);
      setAccounts(prev => [...prev, newAccount]);
      showNotification({
        type: 'success',
        message: 'Account created successfully'
      });
      return newAccount;
    } catch (error) {
      showNotification({
        type: 'error',
        message: error.message || 'Failed to create account'
      });
      throw error;
    } finally {
      setIsLoading(false);
    }
  }, [showNotification]);

  useEffect(() => {
    loadAccounts();
  }, [loadAccounts]);

  return {
    accounts,
    isLoading,
    loadAccounts,
    addAccount,
  };
};