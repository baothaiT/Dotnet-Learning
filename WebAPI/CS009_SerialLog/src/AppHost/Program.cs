var builder = DistributedApplication.CreateBuilder(args);

builder.AddContainer("jaeger", "jaegertracing/all-in-one")
    .WithHttpEndpoint(16686, targetPort: 16686, name: "jaegerPortal")
    .WithHttpEndpoint(4317, targetPort: 4317, name: "jaegerEndpoint");

var sql = builder.AddSqlServer(
    name: "sql",
    port: 1444
    )
    .WithLifetime(ContainerLifetime.Session);

var MyAppDb = sql.AddDatabase("MyDb");

var myAppAPI = builder.AddProject<Projects.CS004_SwaggerUI>("myAppAPI")
    .WaitFor(MyAppDb)
    .WithReference(MyAppDb)
    ;

builder.Build().Run();
