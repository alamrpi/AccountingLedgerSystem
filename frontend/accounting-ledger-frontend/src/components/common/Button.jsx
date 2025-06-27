import PropTypes from 'prop-types';
import { forwardRef } from 'react';
import { twMerge } from 'tailwind-merge';

const Button = forwardRef(({
  children,
  type = 'button',
  variant = 'primary',
  size = 'medium',
  className = '',
  isLoading = false,
  icon: Icon,
  iconPosition = 'left',
  ...props
}, ref) => {
  const baseClasses = 'inline-flex items-center justify-center rounded-md font-medium transition-colors focus:outline-none focus:ring-2 focus:ring-offset-2 disabled:opacity-50 disabled:pointer-events-none';
  
  const variantClasses = {
    primary: 'bg-indigo-600 text-white hover:bg-indigo-700 focus:ring-indigo-500',
    secondary: 'bg-white text-gray-700 border border-gray-300 hover:bg-gray-50 focus:ring-indigo-500',
    danger: 'bg-red-600 text-white hover:bg-red-700 focus:ring-red-500',
  };

  const sizeClasses = {
    small: 'px-3 py-1.5 text-sm',
    medium: 'px-4 py-2 text-base',
    large: 'px-6 py-3 text-lg',
  };

  const iconSizeClasses = {
    small: 'h-4 w-4',
    medium: 'h-5 w-5',
    large: 'h-6 w-6',
  };

  return (
    <button
      ref={ref}
      type={type}
      className={twMerge(
        baseClasses,
        variantClasses[variant],
        sizeClasses[size],
        className
      )}
      disabled={isLoading}
      {...props}
    >
      {isLoading ? (
        <span className="inline-flex items-center">
          <svg className="animate-spin -ml-1 mr-3 h-5 w-5 text-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
          </svg>
          Loading...
        </span>
      ) : (
        <>
          {Icon && iconPosition === 'left' && (
            <Icon className={`${iconSizeClasses[size]} mr-2`} />
          )}
          {children}
          {Icon && iconPosition === 'right' && (
            <Icon className={`${iconSizeClasses[size]} ml-2`} />
          )}
        </>
      )}
    </button>
  );
});

Button.propTypes = {
  children: PropTypes.node.isRequired,
  type: PropTypes.oneOf(['button', 'submit', 'reset']),
  variant: PropTypes.oneOf(['primary', 'secondary', 'danger']),
  size: PropTypes.oneOf(['small', 'medium', 'large']),
  className: PropTypes.string,
  isLoading: PropTypes.bool,
  icon: PropTypes.elementType,
  iconPosition: PropTypes.oneOf(['left', 'right']),
};

Button.displayName = 'Button';

export default Button;