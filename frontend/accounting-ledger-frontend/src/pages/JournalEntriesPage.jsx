import { useEffect, useState } from 'react';
import { useJournalEntries } from '../hooks/useJournalEntries';
import { usePagination } from '../hooks/usePagination';
import PageHeader from '../components/common/PageHeader';
import JournalEntryTable from '../components/accounting/JournalEntryTable';
import LoadingSpinner from '../components/common/LoadingSpinner';
import Input from '../components/common/Input';
import PaginationControls from '../components/common/PaginationControls';

const JournalEntriesPage = () => {
  const [dateFilter, setDateFilter] = useState('');
  const {
    pagination,
    handlePageChange,
    handlePageSizeChange,
    handleSortChange,
    getPaginationParams,
    setPagination
  } = usePagination({ 
    pageSize: 5,
    sortField: 'date',
    sortDirection: 'desc'
  });

  const { entries, isLoading, loadEntries } = useJournalEntries();

  const handleFilter = (e) => {
    e.preventDefault();
    loadData({ date: dateFilter });
  };

  const loadData = async (params = {}) => {
    const { date = dateFilter } = params;
    await loadEntries({ 
      date,
      ...getPaginationParams()
    });
  };

  useEffect(() => {
    loadData();
  }, [pagination.page, pagination.pageSize, pagination.sortField, pagination.sortDirection]);

  useEffect(() => {
    if (entries) {
      setPagination({
        page: entries.pageNumber,
        totalItems: entries.totalCount
      });
    }
  }, [entries]);

  return (
    <div className="space-y-6">
      <PageHeader
        title="Journal Entries"
        description="View all journal entries"
      >
        <form onSubmit={handleFilter} className="flex flex-col sm:flex-row gap-2">
          <div className="flex-1 flex gap-2">
            <Input
              type="date"
              value={dateFilter}
              onChange={(e) => setDateFilter(e.target.value)}
              placeholder="Filter by date"
              className="flex-1"
            />
            <button
              type="submit"
              className="px-2 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 transition-colors"
            >
              Filter
            </button>
            {dateFilter && (
              <button
                type="button"
                onClick={() => {
                  setDateFilter('');
                  loadData({ date: '' });
                }}
                className="px-4 py-2 bg-gray-200 text-gray-800 rounded-md hover:bg-gray-300 transition-colors"
              >
                Clear
              </button>
            )}
          </div>
        </form>
      </PageHeader>

      {isLoading ? (
        <div className="flex justify-center py-12">
          <LoadingSpinner size="lg" />
        </div>
      ) : (
        <>
          <div className="bg-white shadow rounded-lg overflow-hidden">
            <JournalEntryTable 
              entries={entries?.items || []}
              sortField={pagination.sortField}
              sortDirection={pagination.sortDirection}
              onSortChange={handleSortChange}
            />
          </div>
          
          <PaginationControls
            pagination={pagination}
            onPageChange={handlePageChange}
            onPageSizeChange={handlePageSizeChange}
          />
        </>
      )}
    </div>
  );
};

export default JournalEntriesPage;