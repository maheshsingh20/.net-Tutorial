import { useState } from 'react';
import { apiService } from '../services/api';
import type { RegisterRequest } from '../types/auth';

export default function Register() {
  const [formData, setFormData] = useState<RegisterRequest>({ username: '', email: '', password: '' });
  const [isAdmin, setIsAdmin] = useState(false);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setSuccess('');
    setLoading(true);

    try {
      const response = isAdmin
        ? await apiService.registerAdmin(formData)
        : await apiService.register(formData);

      setSuccess(response.message || `${isAdmin ? 'Admin' : 'User'} registered successfully! You can now login.`);
      setFormData({ username: '', email: '', password: '' });
      setIsAdmin(false);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Registration failed. Please try again.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Create Account</h2>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <input
              id="username"
              type="text"
              value={formData.username}
              onChange={(e) => setFormData({ ...formData, username: e.target.value })}
              placeholder="Choose a username"
              required
              autoComplete="username"
            />
          </div>
          <div className="form-group">
            <input
              id="email"
              type="email"
              value={formData.email}
              onChange={(e) => setFormData({ ...formData, email: e.target.value })}
              placeholder="Enter your email"
              required
              autoComplete="email"
            />
          </div>
          <div className="form-group">
            <input
              id="password"
              type="password"
              value={formData.password}
              onChange={(e) => setFormData({ ...formData, password: e.target.value })}
              placeholder="Create a strong password"
              required
              autoComplete="new-password"
            />
          </div>
          <div className="form-group checkbox">
            <label>
              <input
                type="checkbox"
                checked={isAdmin}
                onChange={(e) => setIsAdmin(e.target.checked)}
              />
              Register as Admin (access to weather data)
            </label>
          </div>
          {error && <div className="error">{error}</div>}
          {success && <div className="success">{success}</div>}
          <button type="submit" disabled={loading}>
            {loading ? 'Creating account...' : 'Register'}
          </button>
        </form>
      </div>
    </div>
  );
}
