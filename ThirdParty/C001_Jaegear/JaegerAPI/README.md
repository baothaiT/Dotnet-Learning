# JEAGEAR

## Packages


dotnet add package OpenTelemetry --version 1.4.0
dotnet add package OpenTelemetry.Exporter.Jaeger --version 1.4.0
dotnet add package OpenTelemetry.Extensions.Hosting --version 1.4.0
dotnet add package OpenTelemetry.Instrumentation.AspNetCore --version 1.4.0
dotnet add package OpenTelemetry.Instrumentation.Http --version 1.4.0


## Docker file
docker build -t c001_jaegear .
docker run -p 5000:8080 c001_jaegear


docker compose up
docker compose down


docker network create jaegear_network
