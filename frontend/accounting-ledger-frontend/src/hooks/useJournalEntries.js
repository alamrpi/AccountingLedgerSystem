import { useState, useEffect, useCallback } from 'react';
import { fetchJournalEntries, createJournalEntry } from '../api/accountingApi';
import { useNotification } from '../contexts/NotificationContext';

export const useJournalEntries = () => {
  const [entries, setEntries] = useState({ items: [] });
  const [isLoading, setIsLoading] = useState(true);
  const { showNotification } = useNotification();

  const loadEntries = useCallback(async (params = {}) => {
    setIsLoading(true);
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
    try {
      const newEntry = await createJournalEntry(entryData);
      //setEntries(prev => [...prev, newEntry]);
      showNotification({
        type: 'success',
        message: 'Journal entry created successfully'
      });
      return newEntry;
    } catch (error) {
      showNotification({
        type: 'error',
        message: error.message || 'Failed to create journal entry'
      });
      throw error;
    } finally {
      setIsLoading(false);
    }
  }, [showNotification]);

  // useEffect(() => {
  //   loadEntries();
  // }, [loadEntries]);

  return {
    entries,
    isLoading,
    loadEntries,
    addEntry,
  };
};