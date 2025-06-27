import { HomeIcon, CalculatorIcon, BookOpenIcon, ScaleIcon } from '@heroicons/react/outline';
import NavItem from './NavItem';

const Sidebar = () => {
  return (
    <div className="w-64 bg-gray-800 text-white p-4">
      <h1 className="text-xl font-bold mb-8">Accounting Ledger</h1>
      <nav>
        <ul className="space-y-2">
          <NavItem to="/accounts" icon={HomeIcon}>
            Accounts
          </NavItem>
          <NavItem to="/add-journal-entry" icon={CalculatorIcon}>
            Add Journal Entry
          </NavItem>
          <NavItem to="/journal-entries" icon={BookOpenIcon}>
            Journal Entries
          </NavItem>
          <NavItem to="/trial-balance" icon={ScaleIcon}>
            Trial Balance
          </NavItem>
        </ul>
      </nav>
    </div>
  );
};

export default Sidebar;