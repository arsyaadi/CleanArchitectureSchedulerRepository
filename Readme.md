# CronJob Scheduler with Clean Architecture

This project is a scheduler application implemented using clean architecture principles. It allows users to define and manage cron jobs for scheduled tasks.

## Overview

The CronJob Scheduler is a .NET application that leverages clean architecture to provide a modular and maintainable solution for scheduling tasks using cron expressions.

## Features

- Configurable cron job scheduling
- Clean architecture design for maintainability and scalability
- Use of the repository pattern for data access
- Integration with Quartz.NET for cron job management
- Use of the mediator pattern for application logic

## Architecture

The project follows the clean architecture principles, with the following layers:

- **Application**: Contains application logic and use cases, utilizing the mediator pattern for decoupling.
- **Domain**: Contains domain entities, value objects, and domain logic.
- **Infrastructure**: Contains infrastructure concerns such as data access and external services. Implements the repository pattern for database access.
- **Infrastructure.SqlServer**: Contains SQL Server-specific infrastructure implementations, such as DbContext and database migrations.
- **Worker**: Contains background worker services for executing scheduled jobs.

Each layer has well-defined responsibilities to ensure separation of concerns and ease of testing and maintenance.

## Technologies Used

- .NET 8.0.204
- Entity Framework Core
- Quartz.NET
- dotnet ef 8.0.4 (Entity Framework Core tools)

## Getting Started

1. Clone the repository.
2. Install dependencies: `dotnet restore`.
3. Configure the database connection string in `appsettings.json`.
4. Run database migrations: `dotnet ef database update`.
5. Run the application: `dotnet run`.

## Usage

To use the CronJob Scheduler:

1. Define and configure cron jobs using the provided user interface.
2. Run and monitor scheduled jobs to ensure they execute as expected.
3. Customize and extend the application as needed for your specific use case.

## Acknowledgements

- Quartz.NET: https://www.quartz-scheduler.net/
- Entity Framework Core: https://docs.microsoft.com/en-us/ef/core/
