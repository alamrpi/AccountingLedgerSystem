import PropTypes from 'prop-types';
import Sidebar from './Sidebar';

const AppLayout = ({ children }) => {
  return (
    <div className="flex min-h-screen">
      <Sidebar />
      <div className="flex-1 p-8">
        {children}
      </div>
    </div>
  );
};

AppLayout.propTypes = {
  children: PropTypes.node.isRequired,
};

export default AppLayout;