var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Bdziam_ApiService>("apiservice");

builder.AddProject<Projects.Bdziam_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
