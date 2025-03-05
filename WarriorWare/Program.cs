using WarriorWare;
using WarriorWare.Secrets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ServiceRegistrar.RegisterServices(builder.Services);

var secrets = builder.Configuration
	.AsEnumerable()
	.Where(kvp => kvp.Key.StartsWith("UserSecrets") && kvp.Value != null)
	.ToDictionary(kvp => kvp.Key, kvp => kvp.Value!);

UserSecretToEnvironmentVariableWriter.WriteAllUserSecretsToEnvironmentVariables(secrets);

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.MapGet("/warrior", (HttpContext context) =>
{
	return Results.Ok("A Warrior has awoken");
});

app.Run();
