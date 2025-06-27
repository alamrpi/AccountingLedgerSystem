import { Link } from 'react-router-dom'
import { HomeIcon, CalculatorIcon, BookOpenIcon, ScaleIcon } from '@heroicons/react/outline'

export default function Layout({ children }) {
  return (
    <div className="flex min-h-screen">
      {/* Sidebar */}
      <div className="w-64 bg-gray-800 text-white p-4">
        <h1 className="text-xl font-bold mb-8">Accounting Ledger</h1>
        <nav>
          <ul className="space-y-2">
            <li>
              <Link to="/accounts" className="flex items-center p-2 rounded hover:bg-gray-700">
                <HomeIcon className="w-5 h-5 mr-3" />
                Accounts
              </Link>
            </li>
            <li>
              <Link to="/add-journal-entry" className="flex items-center p-2 rounded hover:bg-gray-700">
                <CalculatorIcon className="w-5 h-5 mr-3" />
                Add Journal Entry
              </Link>
            </li>
            <li>
              <Link to="/journal-entries" className="flex items-center p-2 rounded hover:bg-gray-700">
                <BookOpenIcon className="w-5 h-5 mr-3" />
                Journal Entries
              </Link>
            </li>
            <li>
              <Link to="/trial-balance" className="flex items-center p-2 rounded hover:bg-gray-700">
                <ScaleIcon className="w-5 h-5 mr-3" />
                Trial Balance
              </Link>
            </li>
          </ul>
        </nav>
      </div>

      {/* Main Content */}
      <div className="flex-1 p-8">
        {children}
      </div>
    </div>
  )
}