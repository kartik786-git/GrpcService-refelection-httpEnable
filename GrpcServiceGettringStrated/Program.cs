using GrpcServiceGettringStrated.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();

builder.Services.AddGrpcReflection();

builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo 
        { Title = "grpc trasnsocding", Version = "v1" });
});
var app = builder.Build();

app.MapSwagger();
app.UseSwaggerUI(x => {

    x.SwaggerEndpoint("/swagger/v1/swagger.json", "my api v1");
});

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcReflectionService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
