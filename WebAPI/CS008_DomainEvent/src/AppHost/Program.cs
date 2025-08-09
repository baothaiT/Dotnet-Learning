var builder = DistributedApplication.CreateBuilder(args);

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
