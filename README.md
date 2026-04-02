# TaskTrackerSolution Documentation





# Overview

The TaskTracker solution is a multi-project ASP.NET Core Web API application designed to manage tasks efficiently. It follows clean architecture principles by separating concerns into distinct layers: Core, Infrastructure, Services, Web API, and Tests.



# Solution Structure

1. TaskTracker.Core

Purpose: Contains the core domain logic and business entities.

Responsibilities:

Define domain models

Define interfaces



2. TaskTracker.Infrastructure

Purpose: Handles data access and external dependencies.

Responsibilities:

Implement repository interfaces from Core

Configure database context (Entity Framework Core)

Manage persistence (CRUD operations)



3. TaskTracker.Services
Purpose: Contains application/business logic.
Responsibilities:
Coordinate between controllers and repositories
Implement use cases such as:
Creating tasks
Updating task status
Deleting tasks
Retrieving tasks

Enforce business rules (valid status transitions)

Services:

TaskItemCreatorService

TaskItemGetterService

TaskItemUpdaterService

TaskItemDeleterService



4. TaskTracker.WebAPI

Purpose: Exposes RESTful endpoints for the application.

Responsibilities:

Handle HTTP requests and responses

Map endpoints to service methods

Validate incoming data (DTOs)

Endpoints:

POST /tasks

GET /tasks

PUT /tasks/{id}

DELETE /tasks/{id}



5.TaskTracker.Test

Purpose: Contains unit tests for validating application behavior using xUnit and Moq.

Responsibilities:

Test services and business logic

Ensure correctness of status transitions



Architecture Pattern

The solution follows Clean Architecture:

Core → Independent of everything

Infrastructure → Depends on Core

Services → Depends on Core

WebAPI → Depends on Services

Tests → Tests TaskTracker.Services layer



# Technologies Used

ASP.NET Core Web API

Entity Framework Core with SQLLite

C#

xUnit Moq (for testing)

Angular (Client-side, partially implemented)

Swagger (end-point testing)

Serilog (logging)



Default launch URL (Swagger): https://localhost:7221/swagger/index.html

