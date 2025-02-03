# Setting Up Backend
1️ Clone the Backend Repository
If you haven't already, clone the backend repository:
```
git clone https://github.com/your-org/healthcare-backend.git
cd healthcare-backend
```

2️ Restore Dependencies
Run the following command to restore the backend project dependencies:
```
dotnet restore
```

3️ Set Up Database (SQL Server)
The backend uses SQL Server as the database. You can either set it up using Docker (preferred for local development) or use an existing SQL Server instance.

To set up SQL Server in a Docker container, run:
```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```
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
```
dotnet ef database update
```

5️ Run the Backend API Locally
Now you can run the backend API:
```
dotnet run
```
By default, the backend will run on http://localhost:5000 and https://localhost:5001.