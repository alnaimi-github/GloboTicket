# GloboTicket

## Basic Project Overview

* **Project Name**: GloboTicket
* **Description**: GloboTicket is a web application for managing events, shopping carts, and orders. It uses ASP.NET Core, Blazor, and Entity Framework Core.
* **Technologies Used**:
  * .NET 8.0
  * ASP.NET Core
  * Blazor
  * Entity Framework Core
  * AutoMapper
  * Microsoft Identity
* **Project Structure**:
  * `GloboTicket.Abstractions` - Contains shared abstractions and interfaces.
  * `GloboTicket.App` - The main web application project.
  * `GloboTicket.Grains` - Contains the grain implementations for Orleans.
  * `GloboTicket.Silo` - The entry point for the Orleans Silo.
* **Configuration**:
  * The connection string for the database is configured in `GloboTicket.App/appsettings.json`.
* **Build and Run**:
  * Use Visual Studio or the .NET CLI to build and run the solution.
  * The web application can be accessed at `http://localhost:5049` or `https://localhost:7274` as configured in `GloboTicket.App/Properties/launchSettings.json`.

## Detailed Project Components

* **GloboTicket.Abstractions**:
  * Contains shared interfaces and abstractions.
  * Project file: `GloboTicket.Abstractions/GloboTicket.Abstractions.csproj`.
* **GloboTicket.App**:
  * The main web application project.
  * Contains Razor components, pages, services, and data models.
  * Project file: `GloboTicket.App/GloboTicket.App.csproj`.
  * Configuration file: `GloboTicket.App/appsettings.json`.
  * Main entry point: `GloboTicket.App/Program.cs`.
* **GloboTicket.Grains**:
  * Contains the grain implementations for Orleans.
  * Project file: `GloboTicket.Grains/GloboTicket.Grains.csproj`.
* **GloboTicket.Silo**:
  * The entry point for the Orleans Silo.
  * Project file: `GloboTicket.Silo/GloboTicket.Silo.csproj`.
  * Main entry point: `GloboTicket.Silo/Program.cs`.

## Key Features and Services

* **Event Management**:
  * Service: `GloboTicket.App/Services/EventCatalogService.cs`.
  * Interface: `GloboTicket.App/Services/Interfaces/IEventCatalogService.cs`.
* **Shopping Cart**:
  * Service: `GloboTicket.App/Services/ShoppingCartService.cs`.
  * Interface: `GloboTicket.App/Services/Interfaces/IShoppingCartService.cs`.
* **Order Management**:
  * Service: `GloboTicket.App/Services/OrderService.cs`.
  * Interface: `GloboTicket.App/Services/Interfaces/IOrderService.cs`.
* **User Management**:
  * Service: `GloboTicket.App/Services/UserService.cs`.
  * Interface: `GloboTicket.App/Services/Interfaces/IUserService.cs`.
* **Authentication and Authorization**:
  * Custom authentication state provider: `GloboTicket.App/Areas/Identity/RevalidatingIdentityAuthenticationStateProvider.cs`.
  * Identity configuration: `GloboTicket.App/Data/ApplicationDbContext.cs`.
