import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';

const NavItem = ({ to, icon: Icon, children }) => {
  return (
    <li>
      <NavLink
        to={to}
        className={({ isActive }) =>
          `flex items-center p-2 rounded hover:bg-gray-700 ${
            isActive ? 'bg-gray-700' : ''
          }`
        }
      >
        <Icon className="w-5 h-5 mr-3" />
        {children}
      </NavLink>
    </li>
  );
};

NavItem.propTypes = {
  to: PropTypes.string.isRequired,
  icon: PropTypes.elementType.isRequired,
  children: PropTypes.node.isRequired,
};

export default NavItem;