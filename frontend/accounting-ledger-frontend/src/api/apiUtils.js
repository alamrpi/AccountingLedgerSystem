export const handleApiError = (error) => {
  if (error.response) {
    // Server responded with a status other than 2xx
    return {
      message: error.response.data?.message || 'Request failed',
      status: error.response.status,
      data: error.response.data
    };
  } else if (error.request) {
    // Request was made but no response received
    return { message: 'No response from server', status: 503 };
  } else {
    // Something happened in setting up the request
    return { message: error.message || 'Unknown error occurred', status: 500 };
  }
};

export const withErrorHandling = async (apiCall, onSuccess, onError) => {
  try {
    const response = await apiCall();
    if (onSuccess) onSuccess(response.data);
    return response.data;
  } catch (error) {
    const errorInfo = handleApiError(error);
    if (onError) onError(errorInfo);
    throw errorInfo;
  }
};