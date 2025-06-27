import Pagination from './Pagination';

const PaginationControls = ({
  pagination,
  onPageChange,
  onPageSizeChange,
  className = ''
}) => {
  if (pagination.totalItems <= 0) return null;

  return (
    <div className={`flex flex-col sm:flex-row items-center justify-between gap-4 px-4 py-3 bg-white border-t border-gray-200 rounded-b-lg ${className}`}>
      <div className="text-sm text-gray-600">
        Showing {(pagination.page - 1) * pagination.pageSize + 1} to{' '}
        {Math.min(pagination.page * pagination.pageSize, pagination.totalItems)} of{' '}
        {pagination.totalItems} entries
      </div>
      
      <Pagination
        currentPage={pagination.page}
        totalPages={pagination.totalPages}
        onPageChange={onPageChange}
        className="flex-shrink-0"
      />
      
      <div className="flex items-center gap-2 text-sm">
        <span>Items per page:</span>
        <select
          value={pagination.pageSize}
          onChange={(e) => onPageSizeChange(Number(e.target.value))}
          className="border rounded-md px-2 py-1 text-sm"
        >
          {[5, 10, 25, 50, 100].map(size => (
            <option key={size} value={size}>{size}</option>
          ))}
        </select>
      </div>
    </div>
  );
};

export default PaginationControls;