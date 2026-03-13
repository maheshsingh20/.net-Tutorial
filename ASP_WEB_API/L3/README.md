# Level3 Full Stack Application

A complete full-stack web application featuring ASP.NET Core Web API backend with JWT authentication and a modern React TypeScript frontend.

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [API Documentation](#api-documentation)
- [Usage Guide](#usage-guide)
- [Screenshots](#screenshots)
- [Security Features](#security-features)
- [Troubleshooting](#troubleshooting)

## 🎯 Overview

This project demonstrates a modern full-stack application with secure authentication, role-based authorization, and a clean, responsive user interface. The backend is built with ASP.NET Core Web API using Entity Framework Core and SQL Server, while the frontend is a React application with TypeScript and Vite.

## ✨ Features

### Backend (Level3)
- ✅ JWT Bearer Token Authentication
- ✅ ASP.NET Core Identity for user management
- ✅ Role-based authorization (Admin/User roles)
- ✅ Entity Framework Core with SQL Server
- ✅ RESTful API design
- ✅ CORS configuration for frontend integration
- ✅ Secure password hashing
- ✅ Token expiration management (3 hours)

### Frontend (Level3F)
- ✅ Modern React 19 with TypeScript
- ✅ Responsive UI design
- ✅ JWT token management with localStorage
- ✅ Protected routes and authentication flow
- ✅ Form validation
- ✅ Error handling and user feedback
- ✅ Clean, professional UI with consistent design
- ✅ Real-time weather dashboard (admin-only)

## 🛠 Technology Stack

### Backend
- **Framework**: .NET 10.0
- **API**: ASP.NET Core Web API
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Authentication**: JWT Bearer + ASP.NET Core Identity
- **Security**: HTTPS, Password Hashing, Token Validation

### Frontend
- **Framework**: React 19
- **Language**: TypeScript
- **Build Tool**: Vite
- **Styling**: CSS3 (Custom)
- **State Management**: React Context API
- **HTTP Client**: Fetch API

## 📁 Project Structure

```
├── Level3/                          # Backend API
│   ├── Controllers/
│   │   ├── AuthenticateController.cs    # Authentication endpoints
│   │   └── WeatherForecastController.cs # Protected weather API
│   ├── Models/
│   │   ├── ApplicationUser.cs           # User entity
│   │   ├── LoginModel.cs                # Login request model
│   │   ├── RegisterModel.cs             # Registration request model
│   │   └── Response.cs                  # API response model
│   ├── Data/
│   │   └── ApplicationDbContext.cs      # EF Core DbContext
│   ├── Auth/
│   │   └── UserRoles.cs                 # Role constants
│   ├── Migrations/                      # EF Core migrations
│   ├── Program.cs                       # Application entry point
│   ├── appsettings.json                 # Configuration
│   └── Level3.csproj                    # Project file
│
├── Level3F/                         # Frontend Application
│   ├── src/
│   │   ├── pages/
│   │   │   ├── Login.tsx                # Login page
│   │   │   ├── Register.tsx             # Registration page
│   │   │   └── Dashboard.tsx            # Weather dashboard
│   │   ├── context/
│   │   │   └── AuthContext.tsx          # Authentication context
│   │   ├── services/
│   │   │   └── api.ts                   # API service layer
│   │   ├── types/
│   │   │   └── auth.ts                  # TypeScript types
│   │   ├── App.tsx                      # Main app component
│   │   ├── App.css                      # Application styles
│   │   └── main.tsx                     # Entry point
│   ├── package.json                     # Dependencies
│   ├── vite.config.ts                   # Vite configuration
│   └── tsconfig.json                    # TypeScript config
│
└── README.md                        # This file
```

## 📦 Prerequisites

Before you begin, ensure you have the following installed:

- **.NET SDK 10.0** or higher - [Download](https://dotnet.microsoft.com/download)
- **Node.js 18+** and npm - [Download](https://nodejs.org/)
- **SQL Server** (Express or higher) - [Download](https://www.microsoft.com/sql-server/sql-server-downloads)
- **Git** - [Download](https://git-scm.com/)

## 🚀 Installation & Setup

### 1. Clone the Repository

```bash
git clone <repository-url>
cd <project-folder>
```

### 2. Backend Setup (Level3)

#### Step 1: Configure Database Connection

Edit `Level3/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLExpress;Database=HOL;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

Update the connection string to match your SQL Server instance.

#### Step 2: Configure JWT Settings

The JWT settings are already configured in `appsettings.json`:

```json
{
  "JWT": {
    "ValidAudience": "http://localhost:5173",
    "ValidIssuer": "http://localhost:5137",
    "Secret": "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"
  }
}
```

**Note**: Change the `Secret` key in production!

#### Step 3: Apply Database Migrations

```bash
cd Level3
dotnet ef database update
```

If you don't have EF Core tools installed:

```bash
dotnet tool install --global dotnet-ef
```

#### Step 4: Run the Backend

```bash
dotnet run
```

The API will start at `http://localhost:5137`

### 3. Frontend Setup (Level3F)

#### Step 1: Install Dependencies

```bash
cd Level3F
npm install
```

#### Step 2: Verify API URL

The API URL is configured in `src/services/api.ts`:

```typescript
const API_BASE_URL = 'http://localhost:5137/api';
```

Make sure this matches your backend URL.

#### Step 3: Run the Frontend

```bash
npm run dev
```

The application will start at `http://localhost:5173`

## 📚 API Documentation

### Authentication Endpoints

#### 1. Register User
```http
POST /api/Authenticate/register
Content-Type: application/json

{
  "username": "string",
  "email": "string",
  "password": "string"
}
```

**Response**: 200 OK
```json
{
  "status": "Success",
  "message": "User created successfully!"
}
```

#### 2. Register Admin
```http
POST /api/Authenticate/register-admin
Content-Type: application/json

{
  "username": "string",
  "email": "string",
  "password": "string"
}
```

**Response**: 200 OK
```json
{
  "status": "Success",
  "message": "Admin user created successfully!"
}
```

#### 3. Login
```http
POST /api/Authenticate/login
Content-Type: application/json

{
  "username": "string",
  "password": "string"
}
```

**Response**: 200 OK
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2026-03-13T12:00:00Z"
}
```

### Protected Endpoints

#### Get Weather Forecast (Admin Only)
```http
GET /WeatherForecast
Authorization: Bearer {token}
```

**Response**: 200 OK
```json
[
  {
    "date": "2026-03-14",
    "temperatureC": 25,
    "temperatureF": 76,
    "summary": "Warm"
  }
]
```

## 📖 Usage Guide

### 1. Register a New User

1. Open the application at `http://localhost:5173`
2. Click the **Register** tab
3. Fill in the registration form:
   - Username
   - Email
   - Password
4. **Optional**: Check "Register as Admin" to create an admin user
5. Click **Register**

### 2. Login

1. Click the **Login** tab
2. Enter your username and password
3. Click **Login**
4. You'll be redirected to the dashboard

### 3. View Weather Dashboard

- **Admin users**: Can view the 5-day weather forecast
- **Regular users**: Will see an access denied message with instructions

### 4. Logout

Click the **Logout** button in the dashboard header to end your session.

## 🔒 Security Features

### Backend Security
- **Password Hashing**: ASP.NET Core Identity with secure password hashing
- **JWT Tokens**: Signed tokens with expiration (3 hours)
- **HTTPS**: Enforced in production
- **CORS**: Configured to allow only frontend origin
- **Role-based Authorization**: Attribute-based access control
- **Token Validation**: Issuer, audience, and signature validation

### Frontend Security
- **Token Storage**: JWT stored in localStorage
- **Automatic Token Inclusion**: Bearer token added to protected requests
- **Error Handling**: Proper handling of 401/403 responses
- **Input Validation**: Form validation before submission

## 🐛 Troubleshooting

### Backend Issues

#### Database Connection Failed
```
Error: Cannot open database "HOL" requested by the login
```
**Solution**: 
- Verify SQL Server is running
- Check connection string in `appsettings.json`
- Ensure database exists or run migrations

#### Port Already in Use
```
Error: Failed to bind to address http://localhost:5137
```
**Solution**: 
- Stop other applications using port 5137
- Or change the port in `Properties/launchSettings.json`

### Frontend Issues

#### API Connection Refused
```
Error: net::ERR_CONNECTION_REFUSED
```
**Solution**: 
- Ensure backend is running at `http://localhost:5137`
- Check API URL in `src/services/api.ts`

#### 403 Forbidden on Weather Endpoint
```
Error: 403 Forbidden
```
**Solution**: 
- You need an admin account to access weather data
- Logout and register a new account with "Register as Admin" checked

#### CORS Error
```
Error: Access to fetch has been blocked by CORS policy
```
**Solution**: 
- Verify CORS is configured in `Program.cs`
- Ensure frontend URL matches CORS policy (`http://localhost:5173`)

## 🎨 Design Features

- **Responsive Design**: Works on desktop, tablet, and mobile
- **Modern UI**: Clean, professional interface with consistent styling
- **Smooth Animations**: Fade-in effects and hover transitions
- **Accessible**: Proper form labels and ARIA attributes
- **User Feedback**: Clear error and success messages
- **Loading States**: Visual feedback during API calls

## 🔄 Development Workflow

### Backend Development
```bash
cd Level3
dotnet watch run  # Hot reload enabled
```

### Frontend Development
```bash
cd Level3F
npm run dev  # Hot module replacement enabled
```

### Build for Production

#### Backend
```bash
cd Level3
dotnet publish -c Release
```

#### Frontend
```bash
cd Level3F
npm run build
```

## 📝 Environment Variables

### Backend (appsettings.json)
- `ConnectionStrings:DefaultConnection` - Database connection string
- `JWT:ValidAudience` - Frontend URL
- `JWT:ValidIssuer` - Backend URL
- `JWT:Secret` - JWT signing key (change in production!)

### Frontend (src/services/api.ts)
- `API_BASE_URL` - Backend API URL

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License.

## 👥 Authors

- Your Name - Initial work

## 🙏 Acknowledgments

- ASP.NET Core Team for the excellent framework
- React Team for the amazing library
- Vite Team for the blazing fast build tool

---

**Note**: This is a demonstration project. For production use, implement additional security measures such as:
- HTTPS enforcement
- Rate limiting
- Input sanitization
- SQL injection prevention
- XSS protection
- CSRF tokens
- Secure secret management
- Logging and monitoring
- Error handling improvements
