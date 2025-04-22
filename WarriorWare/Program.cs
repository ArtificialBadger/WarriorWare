using System.Net;
using WarriorWare;
using WarriorWare.Secrets;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
	serverOptions.Listen(IPAddress.Any, 5111, listenOptions => { });
	serverOptions.Listen(IPAddress.IPv6Any, 5111, listenOptions => { });

	serverOptions.Listen(IPAddress.Any, 7111, listenOptions => { listenOptions.UseHttps(); });
	serverOptions.Listen(IPAddress.IPv6Any, 7111, listenOptions => { listenOptions.UseHttps(); });
});

builder.Services.AddControllers();

ServiceRegistrar.RegisterServices(builder.Services);

var secrets = builder.Configuration
	.AsEnumerable()
	.Where(kvp => kvp.Key.StartsWith("UserSecrets:") && kvp.Value != null)
	.ToDictionary(kvp => kvp.Key.Remove(0,12), kvp => kvp.Value!);

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
