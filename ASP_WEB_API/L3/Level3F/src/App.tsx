import { useState } from 'react';
import { AuthProvider, useAuth } from './context/AuthContext';
import Login from './pages/Login';
import Register from './pages/Register';
import Dashboard from './pages/Dashboard';
import './App.css';

function AppContent() {
  const { isAuthenticated } = useAuth();
  const [view, setView] = useState<'login' | 'register'>('login');

  if (isAuthenticated) {
    return <Dashboard />;
  }

  return (
    <div className="app">
      <nav className="nav-tabs">
        <button
          className={view === 'login' ? 'active' : ''}
          onClick={() => setView('login')}
        >
          Login
        </button>
        <button
          className={view === 'register' ? 'active' : ''}
          onClick={() => setView('register')}
        >
          Register
        </button>
      </nav>
      {view === 'login' ? <Login /> : <Register />}
    </div>
  );
}

export default function App() {
  return (
    <AuthProvider>
      <AppContent />
    </AuthProvider>
  );
}
