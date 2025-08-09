@echo off
echo Update database with Entity Framework Core...
@REM dotnet ef migrations add nullableBase --project MyWorld.Infra --startup-project MyWorld.API
dotnet ef database update
echo Done.
pause