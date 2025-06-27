import PropTypes from 'prop-types';

const PageHeader = ({ title, description, children }) => {
  return (
    <div className="mb-8">
      <div className="flex justify-between items-center">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">{title}</h1>
          {description && (
            <p className="mt-2 text-sm text-gray-600">{description}</p>
          )}
        </div>
        {children && <div>{children}</div>}
      </div>
      <hr className="mt-4 border-gray-200" />
    </div>
  );
};

PageHeader.propTypes = {
  title: PropTypes.string.isRequired,
  description: PropTypes.string,
  children: PropTypes.node,
};

export default PageHeader;