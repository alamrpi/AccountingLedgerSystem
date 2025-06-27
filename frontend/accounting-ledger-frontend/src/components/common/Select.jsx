import PropTypes from 'prop-types';
import { forwardRef } from 'react';
import { twMerge } from 'tailwind-merge';

const Select = forwardRef(({
  label,
  id,
  options = [],
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
      <select
        ref={ref}
        id={id}
        className={twMerge(
          'block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm',
          error ? 'border-red-300 text-red-900 placeholder-red-300 focus:border-red-500 focus:ring-red-500' : '',
          className
        )}
        {...props}
      >
        {options.map((option) => (
          <option 
            key={option.value} 
            value={option.value}
            disabled={option.disabled}
          >
            {option.label}
          </option>
        ))}
      </select>
      {helperText && (
        <p className="mt-1 text-sm text-gray-500">{helperText}</p>
      )}
      {error && (
        <p className="mt-1 text-sm text-red-600">{error}</p>
      )}
    </div>
  );
});

Select.propTypes = {
  label: PropTypes.string,
  id: PropTypes.string,
  options: PropTypes.arrayOf(
    PropTypes.shape({
      value: PropTypes.oneOfType([PropTypes.string, PropTypes.number]).isRequired,
      label: PropTypes.string.isRequired,
      disabled: PropTypes.bool,
    })
  ),
  className: PropTypes.string,
  error: PropTypes.string,
  helperText: PropTypes.string,
};

Select.displayName = 'Select';

export default Select;