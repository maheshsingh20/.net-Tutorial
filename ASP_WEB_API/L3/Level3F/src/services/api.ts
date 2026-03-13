import type { LoginRequest, RegisterRequest, AuthResponse, ApiResponse, WeatherForecast } from '../types/auth';

const API_BASE_URL = 'http://localhost:5137/api';

class ApiService {
  private getHeaders(includeAuth = false): HeadersInit {
    const headers: HeadersInit = {
      'Content-Type': 'application/json',
    };

    if (includeAuth) {
      const token = localStorage.getItem('token');
      if (token) {
        headers['Authorization'] = `Bearer ${token}`;
      }
    }

    return headers;
  }

  async login(data: LoginRequest): Promise<AuthResponse> {
    const response = await fetch(`${API_BASE_URL}/Authenticate/login`, {
      method: 'POST',
      headers: this.getHeaders(),
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      throw new Error('Login failed');
    }

    return response.json();
  }

  async register(data: RegisterRequest): Promise<ApiResponse> {
    const response = await fetch(`${API_BASE_URL}/Authenticate/register`, {
      method: 'POST',
      headers: this.getHeaders(),
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      const error = await response.json();
      throw new Error(error.message || 'Registration failed');
    }

    return response.json();
  }

  async registerAdmin(data: RegisterRequest): Promise<ApiResponse> {
    const response = await fetch(`${API_BASE_URL}/Authenticate/register-admin`, {
      method: 'POST',
      headers: this.getHeaders(),
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      const error = await response.json();
      throw new Error(error.message || 'Admin registration failed');
    }

    return response.json();
  }

  async getWeatherForecast(): Promise<WeatherForecast[]> {
    const response = await fetch('http://localhost:5137/WeatherForecast', {
      method: 'GET',
      headers: this.getHeaders(true),
    });

    if (!response.ok) {
      if (response.status === 403) {
        throw new Error('403: Access denied. Admin role required.');
      }
      throw new Error('Failed to fetch weather forecast');
    }

    return response.json();
  }
}

export const apiService = new ApiService();
