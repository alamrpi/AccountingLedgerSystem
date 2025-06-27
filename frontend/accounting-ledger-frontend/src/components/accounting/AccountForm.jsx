import { useState } from 'react';
import PropTypes from 'prop-types';
import { ACCOUNT_TYPES } from '../../constants/accountTypes';
import Button from '../common/Button';
import Input from '../common/Input';
import Select from '../common/Select';

const AccountForm = ({ onSubmit, isLoading, initialData = {} }) => {
  const [formData, setFormData] = useState({
    name: initialData.name || '',
    type: initialData.type || 'Asset',
    description: initialData.description || ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData);
    setFormData({
      name: '',
      type: 'Asset',
      description: ''
    });
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4 max-w-md">
      <Input
        label="Account Name"
        name="name"
        value={formData.name}
        onChange={handleChange}
        required
      />

      <Select
        label="Account Type"
        name="type"
        value={formData.type}
        onChange={handleChange}
        options={ACCOUNT_TYPES}
        required
      />

       <Input
        label="Description"
        name="description"
        value={formData.description}
        onChange={handleChange}
        required
      />

      <Button type="submit" isLoading={isLoading}>
        {initialData.id ? 'Update Account' : 'Create Account'}
      </Button>
    </form>
  );
};

AccountForm.propTypes = {
  onSubmit: PropTypes.func.isRequired,
  isLoading: PropTypes.bool,
  initialData: PropTypes.object,
};

export default AccountForm;