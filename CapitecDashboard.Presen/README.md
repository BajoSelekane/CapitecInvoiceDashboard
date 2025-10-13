# CapitecDashboard Presentation Layer

This is the presentation layer for the CapitecDashboard application, providing a web interface for managing customers and invoices.

## Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB or full SQL Server)
- Visual Studio 2022 or VS Code

## Setup Instructions

### 1. Database Setup

1. Open SQL Server Management Studio or use sqlcmd
2. Run the script `Scripts/CreateDatabase.sql` to create the database and tables
3. Alternatively, you can use Entity Framework migrations (see below)

### 2. Entity Framework Migrations (Alternative)

If you prefer to use Entity Framework migrations instead of the SQL script:

```bash
# Navigate to the CapitecDashboard.Presen directory
cd CapitecDashboard.Presen

# Add Entity Framework tools (if not already installed)
dotnet tool install --global dotnet-ef

# Create initial migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

### 3. Connection String

The application is configured to use LocalDB by default. If you want to use a different SQL Server instance, update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=CapitecDashboardDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 4. Run the Application

```bash
# Navigate to the CapitecDashboard.Presen directory
cd CapitecDashboard.Presen

# Restore packages
dotnet restore

# Build the application
dotnet build

# Run the application
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## Features

### Customer Management
- **Create**: Add new customers with name, email, phone, and address
- **Read**: View all customers in a table format
- **Update**: Edit existing customer information
- **Delete**: Remove customers from the system

### Invoice Management
- **Create**: Create new invoices with customer selection, invoice details, and amounts
- **Read**: View all invoices with customer information and status
- **Update**: Edit existing invoice details
- **Delete**: Remove invoices from the system

## Navigation

The application includes a navigation bar with links to:
- Home
- Customers
- Invoices
- Privacy

## Database Schema

The application uses the following main entities:

- **Customers**: Store customer information
- **Invoices**: Store invoice details with customer relationships
- **InvoiceItems**: Store line items for each invoice
- **Payments**: Store payment information for invoices

## Troubleshooting

### Common Issues

1. **Database Connection Error**: Ensure SQL Server is running and the connection string is correct
2. **Migration Errors**: Make sure all required packages are installed and the database exists
3. **Build Errors**: Ensure all project references are correct and packages are restored

### Getting Help

If you encounter issues:
1. Check the application logs for detailed error messages
2. Verify the database connection and permissions
3. Ensure all required NuGet packages are installed
4. Check that the target framework is .NET 9.0

