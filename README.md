# mPATH AssessmentP Healthcare Web Application Project

# Project Overview: 
Develop a healthcare-focused web application using .NET Core 8, Angular 18, and Entity Framework core 8 to manage patient recommendations. 
The system should allow users to log in, browse a list of patients, and view recommendations such as allergy checks and screenings.

# Project Goals:
* Authentication & Authorization:  Implement secure login functionality. Role-based access control (e.g., Admin, Healthcare Professional). 
* Patient Management:  Display a list of patients with pagination and filtering options. Search functionality by name or ID. 
* View detailed patient information.
* Display a list of recommendations (Allergy check, screenings, follow-ups) associated with a patient.  Allow users to mark recommendations as completed. 
* Security Considerations:  Implement OWASP security best practices (CSP, anti-CSRF, secure headers). Protect against SQL Injection, XSS, and authentication-related attacks. 

# Technical Requirements:
* Backend: .NET Core 8+ Web API. 
* Frontend: Angular 18 (using Angular Material components). 
* Database: SQL Server and Entity Framework. 
* API should follow RESTful principles.

# DESIGN SYSTEM
## Healthcare Web Application Design System
This design system outlines the core components and guidelines for building a scalable, secure, and user-friendly healthcare web application. It addresses both frontend and backend architecture, taking into account security, user experience, and responsive design.
## 1. User Interface Design (Frontend)
Framework: Angular 18 (with Angular Material)
## 2. Backend Architecture
Framework: .NET Core 8 Web API
## 3. Security Considerations
* Authentication & Authorization: JWT (JSON Web Tokens) for token-based authentication.
* Implement Role-based Access Control (RBAC)
* Admin: Full access to patient management and user roles.
* Healthcare Professional: Read access to patient data and recommendations.
* OWASP Security Best Practices
* Content Security Policy (CSP): Protect against XSS attacks.
* Anti-CSRF Tokens: Protect against Cross-Site Request Forgery attacks.
* Secure Headers: Add headers like Strict-Transport-Security and X-Content-Type-Options.
* Rate Limiting: Prevent brute force attacks by limiting login attempts.
## 4. Database Schema
The database should have the following entities:
## 5. Infrastructure and Deployment
Docker: Containerize the application for consistent environments across development, staging, and production.

# Local Development Setup
This guide will walk you through setting up the project locally for development. The project consists of a backend API, frontend application, and Docker configuration for easy setup.

## Table of Contents:
* Prerequisites
* Setting Up Backend
* Setting Up Frontend
* Root Project Setup

## Prerequisites
Before getting started, make sure you have the following installed on your local machine:

* Docker (for containerized setup): Docker Installation Guide
* .NET 8 SDK (for backend development): Download .NET
* Node.js (LTS) (for frontend development): Node.js Installation Guide
* Angular CLI (for managing Angular frontend): Install with npm install -g @angular/cli

## Setting Up Backend
1️ Clone the Backend Repository
If you haven't already, clone the backend repository:
```
git clone https://github.com/your-org/healthcare-backend.git
cd healthcare-backend
```

2️ Restore Dependencies
Run the following command to restore the backend project dependencies:
```dotnet restore```

3️ Set Up Database (SQL Server)
The backend uses SQL Server as the database. You can either set it up using Docker (preferred for local development) or use an existing SQL Server instance.

To set up SQL Server in a Docker container, run:
```docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest```

After that, ensure your appsettings.json in the backend project has the correct database connection string (by default, Docker is set up to expose the database on port 1433).
Example connection string in appsettings.json:
```
json

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=HealthcareDB;User Id=sa;Password=YourStrong!Passw0rd;"
}
```
4️ Run Database Migrations
Run the migrations to create the required database schema:
```dotnet ef database update```

5️ Run the Backend API Locally
Now you can run the backend API:
```dotnet run```

By default, the backend will run on http://localhost:5000 and https://localhost:5001.

# Project Setup
1️ Clone the Root Repository
If you haven't already, clone the root repository:
```git clone https://github.com/your-org/healthcare-project.git
cd healthcare-project
```
2️ Docker Setup (Optional)
If you'd like to run both the backend and frontend using Docker, you can use Docker Compose. The project contains a docker-compose.yml file that configures both the backend and frontend along with SQL Server.

To build and run both services using Docker Compose:
```
docker-compose up --build
```
This will:

* Build Docker images for both the frontend and backend.
* Run SQL Server as a Docker container.
* Expose the frontend on http://localhost and backend API on http://localhost:5000.

3️ Running Backend and Frontend Separately
Alternatively, you can run the backend and frontend separately using the following commands:

* Backend API: Follow the backend instructions to run the API locally.
* Frontend: Follow the frontend instructions to run the Angular app.

4️ Testing the Application
Once everything is running, open:

* Frontend: http://localhost (where you can interact with the UI)
* Backend API: http://localhost:5000/swagger (for API testing and documentation)

# Troubleshooting
* Backend API not starting: Make sure Docker is running if you're using a Dockerized SQL Server. Also, verify that the connection string in appsettings.json is correctly pointing to the local database.
* CORS Issues: If the frontend cannot communicate with the backend, ensure that CORS is properly configured in the backend (if not using Docker). The backend should have a CORS policy that allows requests from the frontend's domain (e.g., http://localhost:4200).
* Frontend build issues: If there are issues with building the frontend, try cleaning the cache:
```
npm cache clean --force
npm install
```


## Contact Information

For any questions regarding the project, feel free to reach out to me:

- **Natthaphon Foithong** : n.foithong1983@gmail.com

---

## **License**

This project is licensed under the MIT License - see the LICENSE file for details.

---