@echo off
echo Adding Entity Framework Core migration...
@REM dotnet ef migrations add nullableBase --project MyWorld.Infra --startup-project MyWorld.API
dotnet ef migrations add ChangeNameUserEntity
echo Done.
pause