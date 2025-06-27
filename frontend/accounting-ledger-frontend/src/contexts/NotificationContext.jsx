import { createContext, useContext, useState } from 'react';
import PropTypes from 'prop-types';
import Notification from '../components/common/Notification';

const NotificationContext = createContext();

export const NotificationProvider = ({ children }) => {
  const [notification, setNotification] = useState(null);

  const showNotification = (notification) => {
    setNotification(notification);
  };

  const hideNotification = () => {
    setNotification(null);
  };

  return (
    <NotificationContext.Provider value={{ showNotification, hideNotification }}>
      {children}
      {notification && (
        <Notification
          message={notification.message}
          type={notification.type}
          onDismiss={hideNotification}
          duration={notification.duration}
        />
      )}
    </NotificationContext.Provider>
  );
};

NotificationProvider.propTypes = {
  children: PropTypes.node.isRequired,
};

export const useNotification = () => {
  const context = useContext(NotificationContext);
  if (!context) {
    throw new Error('useNotification must be used within a NotificationProvider');
  }
  return context;
};