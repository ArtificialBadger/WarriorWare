using WarriorWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ServiceRegistrar.RegisterServices(builder.Services);

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.MapGet("/warrior", (HttpContext context) =>
{
	return Results.Ok("A Warrior has awoken");
});

app.Run();
