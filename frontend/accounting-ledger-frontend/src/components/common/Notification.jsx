import { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { XIcon } from '@heroicons/react/outline';

const Notification = ({ message, type, onDismiss, duration = 5000 }) => {
  const [visible, setVisible] = useState(true);

  useEffect(() => {
    if (!duration) return;

    const timer = setTimeout(() => {
      setVisible(false);
      onDismiss?.();
    }, duration);

    return () => clearTimeout(timer);
  }, [duration, onDismiss]);

  if (!visible) return null;

  const typeClasses = {
    success: 'bg-green-50 text-green-800',
    error: 'bg-red-50 text-red-800',
    warning: 'bg-yellow-50 text-yellow-800',
    info: 'bg-blue-50 text-blue-800',
  };

  return (
    <div className={`fixed bottom-4 right-4 p-4 rounded-md shadow-md ${typeClasses[type]}`}>
      <div className="flex items-center">
        <p className="mr-4">{message}</p>
        <button
          onClick={() => {
            setVisible(false);
            onDismiss?.();
          }}
          className="text-current hover:opacity-70"
        >
          <XIcon className="h-5 w-5" />
        </button>
      </div>
    </div>
  );
};

Notification.propTypes = {
  message: PropTypes.string.isRequired,
  type: PropTypes.oneOf(['success', 'error', 'warning', 'info']).isRequired,
  onDismiss: PropTypes.func,
  duration: PropTypes.number,
};

export default Notification;