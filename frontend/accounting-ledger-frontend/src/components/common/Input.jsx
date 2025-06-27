import PropTypes from 'prop-types';
import { forwardRef } from 'react';
import { twMerge } from 'tailwind-merge';

const Input = forwardRef(({
  label,
  id,
  type = 'text',
  className = '',
  error,
  helperText,
  ...props
}, ref) => {
  return (
    <div className="space-y-1">
      {label && (
        <label htmlFor={id} className="block text-sm font-medium text-gray-700">
          {label}
        </label>
      )}
      <input
        ref={ref}
        id={id}
        type={type}
        className={twMerge(
          'block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm',
          error ? 'border-red-300 text-red-900 placeholder-red-300 focus:border-red-500 focus:ring-red-500' : '',
          className
        )}
        {...props}
      />
      {helperText && (
        <p className="mt-1 text-sm text-gray-500">{helperText}</p>
      )}
      {error && (
        <p className="mt-1 text-sm text-red-600">{error}</p>
      )}
    </div>
  );
});

Input.propTypes = {
  label: PropTypes.string,
  id: PropTypes.string,
  type: PropTypes.string,
  className: PropTypes.string,
  error: PropTypes.string,
  helperText: PropTypes.string,
};

Input.displayName = 'Input';

export default Input;