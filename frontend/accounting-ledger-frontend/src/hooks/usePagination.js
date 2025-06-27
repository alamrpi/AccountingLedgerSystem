import { useState } from 'react';

export const usePagination = (initialState = {}) => {
  const [pagination, setPagination] = useState({
    page: 1,
    pageSize: initialState.pageSize || 5,
    totalItems: 0,
    totalPages: 1,
    ...initialState
  });

  const updatePagination = (newValues) => {
    setPagination(prev => {
      const updated = { ...prev, ...newValues };
      return {
        ...updated,
        totalPages: Math.ceil(updated.totalItems / updated.pageSize)
      };
    });
  };

  const handlePageChange = (newPage) => {
    if (newPage >= 1 && newPage <= pagination.totalPages) {
      updatePagination({ page: newPage });
      return newPage;
    }
    return pagination.page;
  };

  const handlePageSizeChange = (newSize) => {
    updatePagination({
      pageSize: newSize,
      page: 1 // Reset to first page when changing page size
    });
  };

  return {
    pagination,
    setPagination: updatePagination,
    handlePageChange,
    handlePageSizeChange,
    getPaginationParams: () => ({
      pageNumber: pagination.page,
      pageSize: pagination.pageSize
    })
  };
};
