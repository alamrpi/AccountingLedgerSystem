import { ChevronLeftIcon, ChevronRightIcon } from '@heroicons/react/outline';

const Pagination = ({ currentPage, totalPages, onPageChange, className }) => {
  const canGoPrev = currentPage > 1;
  const canGoNext = currentPage < totalPages;

  return (
    <nav className={`flex items-center gap-1 ${className}`}>
      <button
        onClick={() => onPageChange(currentPage - 1)}
        disabled={!canGoPrev}
        className={`p-2 rounded-md ${canGoPrev ? 'text-gray-600 hover:bg-gray-100' : 'text-gray-300 cursor-default'}`}
        aria-label="Previous page"
      >
        <ChevronLeftIcon className="h-5 w-5" />
      </button>

      {Array.from({ length: totalPages }, (_, i) => i + 1).map(page => (
        <button
          key={page}
          onClick={() => onPageChange(page)}
          className={`w-10 h-10 rounded-md ${currentPage === page ? 'bg-blue-600 text-white' : 'text-gray-600 hover:bg-gray-100'}`}
          aria-current={currentPage === page ? 'page' : undefined}
        >
          {page}
        </button>
      ))}

      <button
        onClick={() => onPageChange(currentPage + 1)}
        disabled={!canGoNext}
        className={`p-2 rounded-md ${canGoNext ? 'text-gray-600 hover:bg-gray-100' : 'text-gray-300 cursor-default'}`}
        aria-label="Next page"
      >
        <ChevronRightIcon className="h-5 w-5" />
      </button>
    </nav>
  );
};

export default Pagination;