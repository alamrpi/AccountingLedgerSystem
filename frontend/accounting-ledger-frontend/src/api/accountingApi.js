import axios from 'axios';
import { withErrorHandling } from './apiUtils';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5000/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Accounts API
export const fetchAccounts = () => withErrorHandling(() => api.get('/accounts'));
export const createAccount = (data) => withErrorHandling(() => api.post('/accounts', data));

// Journal Entries API
export const fetchJournalEntries = (params = {}) => 
   // withErrorHandling(() => api.get('/journal-entries'));
  withErrorHandling(() => api.get('/journal-entries', { params }));

export const createJournalEntry = (data) => 
  withErrorHandling(() => api.post('/journal-entries', data));

// Trial Balance API
export const fetchTrialBalance = () => 
  withErrorHandling(() => api.get('/reports/trialbalance'));

export default api;