# Health e-Monitor - Patient Vital Signs Monitoring

A Razor Pages web application for patient vital signs real-time monitoring. Built with ASP.NET Core (.NET 9), SignalR, and Entity Framework Core.

## Features

- **Patient Management:** Add, view, and manage patient records.
- **Vital Signs Tracking:** Add, record and display patient vital signs.
- **Real-Time Dashboard:** Live display of heart rate, blood pressure, and oxygen saturation with color-coded status (Normal/Warning/Critical).
- **Real-Time Updates:** Live updates of vital signs using SignalR.
- **Alert Notifications:** Immediate alerts for critical vital sign values.
- **Data Visualization:** Charts showing vital sign trends over the last 24 hours.
- **Historical Data:** View historical vital signs for each patient.
- **Interactive UI:** Patient selection and alert management.
- **Responsive Design:** Mobile-friendly layout using Bootstrap. Built with Razor Pages for fast and secure web experiences.
- **Authentication:** User authentication via ASP.NET Core Identity.
- **Export:** Export vital signs data to CSV.
- **Dockerized solution** - Include necessary files to dockerize project. 

> **Note:**
> - For Docker, LocalDB is not supported (use SQL Server).
> - For usage in (i.e. Visual Studio) without Docker, comment or delete the 'Container (Dockerfile)' section located in /Properties/launchSettings.json
 
## Technology Stack

- ASP.NET Core (.NET 9) with Razor Pages
- SignalR for real-time updates
- Entity Framework Core (SQLite)
- Bootstrap for responsive UI
- Chart.js for data visualization

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (LocalDB or compatible instance)

### Setup

1. **Clone the repository:**
2. **Configure the database:**
   - Update the connection string in `appsettings.json` if needed.

3. **Apply migrations:**
   - dotnet ef database update

4. **Run the application:**	
   - dotnet run

5. **Access the app:**
- Open your browser and navigate to `https://localhost:5001` or `http://localhost:5165`.

## Architecture Overview

- **Models:** `Patient` and `VitalSigns` entities with relationships
- **API Endpoints:**
- `GET /patients`
- `GET /about`
- `GET /simulation` (for simulation)
- `GET /patients/export`
- `GET /patients/{id}/vitals`
- `GET /patients/{id}/vitals/monitor`
- `POST /patients/{id}/vitals` (for simulation)
- **SignalR Hub:** Real-time broadcasting of vital signs
- **Data Seeding:** Sample patients and initial vital signs on startup

> **Note**
> - `POST /patients/{id}/vitals` is done automatically via a handler with an interval of 10 seconds to simulate incoming patient data.
> -  The POST is triggered only when in monitoring mode. 

## Project Structure

- `Pages/` - Razor Pages for UI
- `Models/` - Data models (Patient, VitalSign)
- `Data/` - Entity Framework Core context
- `Areas/` - ASP.NET Core Identity 
- `Hubs/` - SignalR hub for real-time communication
- `wwwroot/` - Static files (CSS, JS, images)

### Database Migration Setup

1. **Install EF Core Tools (if not already installed):**

2. **Apply Migrations to the Database:**
   - dotnet ef database update

4. **Verify the Database:**
   - Ensure your connection string in `appsettings.json` is correct for your environment (SQLite or SQL Server).
   - The database will be created and seeded with sample data if configured.

> **Note:**  
> - Run these commands from the project directory containing the `.csproj` file.
> - For SQLite, ensure the database file path is accessible and writable.

## Sample Data

- **Patients:**
> - John Doe, Age 45, Room 101
> - Jane Smith, Age 32, Room 102
> - Bob Johnson, Age 67, Room 103

- **Vital Signs Ranges:**
> - Heart Rate: 60-100 (Normal), 100-120 (Warning), >120 (Critical)
> - Blood Pressure: 90/60-119/79 (Normal), 120-139/80-89 (Warning), >139/>90 (Critical)
> - Oxygen Saturation: >95% (Normal), 90-95% (Warning), <90% (Critical)

## API Documentation

- See [API Endpoints](#architecture-overview) for available routes and usage.

## License

This project is licensed under the MIT License.
