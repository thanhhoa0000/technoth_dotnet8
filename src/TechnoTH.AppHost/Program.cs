using TechnoTH.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

var postgres = builder.AddPostgres("postgres")
    .WithImage("postgres")
    .WithImageTag("16.4-alpine");

var catalogDb = postgres.AddDatabase("catalogdb");

// Services
var catalogApi = builder.AddProject<Projects.Catalog_API>("catalog-api")
    .WithReference(catalogDb);

builder.Build().Run();
