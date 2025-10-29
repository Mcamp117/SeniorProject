# EagleConnect Authentication System

## Overview
This document describes the authentication system implemented for EagleConnect, a professional networking platform for students, alumni, and professionals.

## Features Implemented

### 1. User Registration
- **Email-based registration** with password requirements
- **User type selection**: Student, Alumni, Faculty, External
- **Profile information**: First name, last name, email, user type
- **Password validation**: Minimum 6 characters with complexity requirements

### 2. User Authentication
- **Login system** with email and password
- **Remember me** functionality for persistent sessions
- **Secure password handling** using ASP.NET Core Identity
- **Session management** with configurable timeouts

### 3. Database Integration
- **MySQL database** connection (10.0.0.79)
- **Entity Framework Core** with Identity framework
- **Automatic database creation** on first run
- **User profile storage** with extended fields

### 4. Security Features
- **Password hashing** using ASP.NET Core Identity
- **Account lockout** protection (5 failed attempts)
- **Session security** with sliding expiration
- **CSRF protection** built-in
- **Input validation** on all forms

## Database Schema

### ApplicationUser Table
- Inherits from IdentityUser
- Additional fields:
  - FirstName, LastName
  - UserType (Student, Alumni, Faculty, External)
  - Major, Year, Bio
  - ProfileImage, Skills
  - Company, JobTitle
  - GraduationYear
  - CreatedAt, LastLoginAt

## Pages Created

### Authentication Pages
- `/Account/Register` - User registration
- `/Account/Login` - User login
- `/Account/Logout` - User logout
- `/Account/Profile` - User profile view
- `/Account/AccessDenied` - Access denied page

### Navigation Updates
- **Dynamic navigation** based on authentication status
- **User dropdown menu** with profile and logout options
- **Sign in/Register links** for anonymous users

## Configuration

### Connection String
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=10.0.0.79;Database=EagleConnect;User=sql_admin;Password=password1;"
  }
}
```

### Password Requirements
- Minimum 6 characters
- Requires uppercase letter
- Requires lowercase letter
- Requires digit
- No special characters required

### Session Configuration
- 30-day expiration
- Sliding expiration enabled
- Secure cookie settings

## Usage

### For Users
1. **Register**: Visit `/Account/Register` to create a new account
2. **Login**: Visit `/Account/Login` to sign in
3. **Profile**: Access user profile at `/Account/Profile`
4. **Logout**: Use the dropdown menu or visit `/Account/Logout`

### For Developers
1. **User Management**: Use `AuthService` for user operations
2. **Authentication Checks**: Use `[Authorize]` attribute on pages
3. **User Context**: Access current user via `User.Identity`
4. **Database Operations**: Use `ApplicationDbContext` for data access

## Future Enhancements

### Planned Features
- **Email verification** system
- **Password reset** functionality
- **Profile editing** capabilities
- **Role-based authorization**
- **Two-factor authentication**

### Email Verification Setup
To enable email verification:
1. Update `SignIn.RequireConfirmedEmail = true` in Program.cs
2. Configure email service (SMTP, SendGrid, etc.)
3. Implement email confirmation logic

## Security Considerations

### Current Security Measures
- Password complexity requirements
- Account lockout protection
- Secure session management
- Input validation and sanitization
- CSRF protection

### Recommended Additional Measures
- Enable HTTPS in production
- Implement rate limiting
- Add security headers
- Regular security audits
- User activity logging

## Troubleshooting

### Common Issues
1. **Database connection errors**: Check connection string and MySQL server
2. **Migration issues**: Run `dotnet ef database update`
3. **Authentication failures**: Verify user credentials and account status
4. **Session issues**: Check cookie settings and browser configuration

### Development Commands
```bash
# Install packages
dotnet restore

# Run the application
dotnet run

# Create database migration (if needed)
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

## Support
For technical support or questions about the authentication system, please refer to the ASP.NET Core Identity documentation or contact the development team.
