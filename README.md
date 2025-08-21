# ASP .NET Coffee Warehouse

## Overview
This ASP.NET Core MVC project is designed for managing coffee warehouse operations, including product inventory, supplier and customer information, and coffee order tracking. It uses Entity Framework Core (EF Core) for database operations, C# models for structured data, and supports CRUD functionalities with secure user authentication and role-based access control.

## Features
### Backend (C# & EF Core)
-Entity Models
 --Products & Inventory: Cafea, TipCafea, Stoc
 --Orders & Transactions: Comanda, Client, Plata
-Data Management
 --Built using Entity Framework Core for handling CRUD operations
 --Defines relationships between coffee items, orders, customers, and payments
 --Implements a Code-First approach with clearly defined models and a DbContext

### User Authentication & Access Control
-Login System with credential-based authentication
-Access Levels for different user roles (Admin, Customer, Guest)
-Role-Based Restrictions for managing access to specific functionalities

### Database Functionality
-CRUD Operations for managing coffee items, types, stock entries, customers, and orders
-Code-first approach implemented using Entity Framework Core with model classes and migrations
-Secure data storage ensuring referential integrity

### User Interface (MVC & Razor Pages)
-Dynamic UI with model binding
-Navigation and shared layouts for consistent user experience
-Validation and error handling for secure form submissions
