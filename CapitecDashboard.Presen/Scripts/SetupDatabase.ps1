# PowerShell script to set up the CapitecDashboard database
# This script will create the database and run the necessary SQL scripts

Write-Host "Setting up CapitecDashboard Database..." -ForegroundColor Green

# Database connection parameters
$ServerInstance = "(localdb)\mssqllocaldb"
$DatabaseName = "CapitecDashboardDb"
$SqlScriptPath = ".\Scripts\CreateDatabase.sql"

# Check if SQL Server LocalDB is available
try {
    $LocalDBVersion = sqlcmd -Q "SELECT @@VERSION" -S $ServerInstance
    Write-Host "SQL Server LocalDB is available" -ForegroundColor Green
}
catch {
    Write-Host "Error: SQL Server LocalDB is not available. Please install SQL Server LocalDB." -ForegroundColor Red
    exit 1
}

# Check if the SQL script exists
if (Test-Path $SqlScriptPath) {
    Write-Host "Found SQL script: $SqlScriptPath" -ForegroundColor Green
}
else {
    Write-Host "Error: SQL script not found at $SqlScriptPath" -ForegroundColor Red
    exit 1
}

# Run the SQL script
try {
    Write-Host "Executing SQL script..." -ForegroundColor Yellow
    sqlcmd -S $ServerInstance -i $SqlScriptPath
    Write-Host "Database setup completed successfully!" -ForegroundColor Green
}
catch {
    Write-Host "Error executing SQL script: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}

Write-Host "Database setup is complete. You can now run the application." -ForegroundColor Green

