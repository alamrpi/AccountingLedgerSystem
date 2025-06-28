export const handleApiError = (error) => {
  if (error.response) {
    // Server responded with a status other than 2xx
    const response = error.response;
    const errorData = response.data;
    
    // Handle validation errors (400 Bad Request)
    if (response.status === 400 && errorData.errors) {
      return {
        message: 'Validation failed',
        status: response.status,
        errors: errorData.errors,
        ...errorData
      };
    }
    
    // Handle standard error responses
    return {
      message: errorData.title || errorData.message || 'Request failed',
      status: response.status,
      detail: errorData.detail,
      ...errorData
    };
  } else if (error.request) {
    // Request was made but no response received
    return { 
      message: 'No response from server', 
      status: 503,
      detail: 'The server did not respond to the request'
    };
  } else {
    // Something happened in setting up the request
    return { 
      message: error.message || 'Unknown error occurred', 
      status: 500,
      detail: 'An unexpected error occurred while setting up the request'
    };
  }
};

export const withErrorHandling = async (apiCall, onSuccess, onError) => {
  try {
    const response = await apiCall();
    if (onSuccess) onSuccess(response.data);
    return response.data;
  } catch (error) {
    const errorInfo = handleApiError(error);
    console.error('API Error:', errorInfo);
    
    if (onError) {
      onError(errorInfo);
    } else {
      const errorMessage = errorInfo.errors 
        ? Object.entries(errorInfo.errors)
            .map(([field, messages]) => `${field}: ${messages.join(', ')}`)
            .join('\n')
        : errorInfo.detail || errorInfo.message;
      
      //alert(errorMessage); 
    }
    
    throw errorInfo;
  }
};