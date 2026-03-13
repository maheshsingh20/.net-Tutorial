import { useState, useEffect } from 'react';
import { useAuth } from '../context/AuthContext';
import { apiService } from '../services/api';
import type { WeatherForecast } from '../types/auth';

export default function Dashboard() {
  const { logout } = useAuth();
  const [weather, setWeather] = useState<WeatherForecast[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    loadWeather();
  }, []);

  const loadWeather = async () => {
    try {
      const data = await apiService.getWeatherForecast();
      setWeather(data);
      setError('');
    } catch (err) {
      if (err instanceof Error && err.message.includes('403')) {
        setError('Access denied. You need Admin role to view weather data. Please register as an admin user.');
      } else {
        setError(err instanceof Error ? err.message : 'Failed to load weather data');
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="dashboard">
      <header className="dashboard-header">
        <h1>Weather Dashboard</h1>
        <button onClick={logout} className="logout-btn">Logout</button>
      </header>

      <div className="dashboard-content">
        {loading && <p>Loading weather data...</p>}

        {error && (
          <div className="error">
            <p>{error}</p>
            {error.includes('Admin role') && (
              <p style={{ marginTop: '0.75rem' }}>
                <strong>💡 Tip:</strong> Logout and register a new account with the "Register as Admin" option checked to access weather data.
              </p>
            )}
          </div>
        )}

        {!loading && !error && weather.length === 0 && (
          <p>No weather data available.</p>
        )}

        {!loading && !error && weather.length > 0 && (
          <div className="weather-grid">
            {weather.map((forecast, index) => (
              <div key={index} className="weather-card">
                <h3>{forecast.date}</h3>
                <p className="summary">{forecast.summary}</p>
                <div className="temperature">
                  <span>{forecast.temperatureC}°C</span>
                  <span>{forecast.temperatureF}°F</span>
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}
