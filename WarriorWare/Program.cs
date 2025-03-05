using WarriorWareCore.WorldGeneration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();


app.MapGet("/", () => "Hello World!");


app.MapGet("/warrior", (HttpContext context) =>
{
	return Results.Ok("A Warrior has awoken");
});

app.Run();
