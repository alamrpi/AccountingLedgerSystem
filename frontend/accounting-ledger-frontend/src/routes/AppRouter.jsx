import { BrowserRouter, Routes, Route } from 'react-router-dom'
import AccountsPage from '../pages/AccountsPage'
import JournalEntryPage from '../pages/JournalEntryPage'
import JournalEntriesPage from '../pages/JournalEntriesPage'
import TrialBalancePage from '../pages/TrialBalancePage'
import Layout from '../components/layout/Layout'

export default function AppRouter() {
  return (
    <Layout>
        <Routes>
          <Route path="/" element={<AccountsPage />} />
          <Route path="/accounts" element={<AccountsPage />} />
          <Route path="/journal-entries" element={<JournalEntriesPage />} />
          <Route path="/add-journal-entry" element={<JournalEntryPage />} />
          <Route path="/trial-balance" element={<TrialBalancePage />} />
        </Routes>
      </Layout>
  )
}