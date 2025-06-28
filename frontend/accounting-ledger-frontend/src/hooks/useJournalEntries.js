import { useState, useEffect, useCallback } from 'react';
import { fetchJournalEntries, createJournalEntry } from '../api/accountingApi';
import { useNotification } from '../contexts/NotificationContext';

export const useJournalEntries = () => {
  const [entries, setEntries] = useState({ items: [] });
  const [isLoading, setIsLoading] = useState(false);
  const [validationErrors, setValidationErrors] = useState({});
  const { showNotification } = useNotification();

  const loadEntries = useCallback(async (params = {}) => {
    setIsLoading(true);
    setValidationErrors({}); // Clear previous errors
    try {
      const data = await fetchJournalEntries(params);
      setEntries(data);
    } catch (error) {
      showNotification({
        type: 'error',
        message: error.message || 'Failed to load journal entries'
      });
    } finally {
      setIsLoading(false);
    }
  }, [showNotification]);

  const addEntry = useCallback(async (entryData) => {
    setIsLoading(true);
    setValidationErrors({}); // Clear previous errors
    try {
      const newEntry = await createJournalEntry(entryData);
      showNotification({
        type: 'success',
        message: 'Journal entry created successfully'
      });
      return newEntry;
    } catch (error) {
      // Handle validation errors (400 status)
      if (error.status === 400 && error.errors) {
        setValidationErrors(error.errors);
        showNotification({
          type: 'error',
          message: 'Please fix the validation errors',
          duration: 5000 
        });
      } else {
        showNotification({
          type: 'error',
          message: error.message || 'Failed to create journal entry'
        });
      }
      throw error;
    } finally {
      setIsLoading(false);
    }
  }, [showNotification]);

  // Clear validation errors when unmounting
  useEffect(() => {
    return () => setValidationErrors({});
  }, []);

  return {
    entries,
    isLoading,
    validationErrors,
    loadEntries,
    addEntry,
    clearValidationErrors: () => setValidationErrors({}),
  };
};