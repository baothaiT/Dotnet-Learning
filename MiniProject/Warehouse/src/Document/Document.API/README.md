#

## Packages

dotnet add package Microsoft.EntityFrameworkCore.Tools v8.0.14
dotnet add package Microsoft.EntityFrameworkCore.SqlServer v8.0.14
dotnet add package Microsoft.EntityFrameworkCore.Sqlite v8.0.14
dotnet add package Microsoft.EntityFrameworkCore.Design v8.0.14
dotnet add package Microsoft.EntityFrameworkCore v8.0.14

## Commands
dotnet ef migrations add init
dotnet ef database update 


New-NetFirewallRule -DisplayName "Allow SQL Server" -Direction Inbound -Action Allow -Protocol TCP -LocalPort 1433
