using SeamenResto.Api.Endpoint;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapOrderEndpoint();

app.Run();
