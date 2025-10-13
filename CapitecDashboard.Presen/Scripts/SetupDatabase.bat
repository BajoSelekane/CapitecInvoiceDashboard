@echo off
echo Setting up CapitecDashboard Database...

REM Database connection parameters
set SERVER_INSTANCE=(localdb)\mssqllocaldb
set DATABASE_NAME=CapitecDashboardDb
set SQL_SCRIPT_PATH=.\Scripts\CreateDatabase.sql

REM Check if SQL Server LocalDB is available
sqlcmd -Q "SELECT @@VERSION" -S %SERVER_INSTANCE% >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: SQL Server LocalDB is not available. Please install SQL Server LocalDB.
    pause
    exit /b 1
)

REM Check if the SQL script exists
if not exist "%SQL_SCRIPT_PATH%" (
    echo Error: SQL script not found at %SQL_SCRIPT_PATH%
    pause
    exit /b 1
)

REM Run the SQL script
echo Executing SQL script...
sqlcmd -S %SERVER_INSTANCE% -i "%SQL_SCRIPT_PATH%"
if %errorlevel% neq 0 (
    echo Error executing SQL script.
    pause
    exit /b 1
)

echo Database setup completed successfully!
echo You can now run the application.
pause

