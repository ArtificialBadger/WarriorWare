using System.Net;
using WarriorWare;
using WarriorWare.Secrets;

const int HttpPort = 5111;
const int HttpsPort = 7111;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
	serverOptions.Listen(IPAddress.Any, HttpPort, listenOptions => { });
	serverOptions.Listen(IPAddress.IPv6Any, HttpPort, listenOptions => { });

	serverOptions.Listen(IPAddress.Any, HttpsPort, listenOptions => { listenOptions.UseHttps(); });
	serverOptions.Listen(IPAddress.IPv6Any, HttpsPort, listenOptions => { listenOptions.UseHttps(); });
});

builder.Services.AddControllers();

ServiceRegistrar.RegisterServices(builder.Services);

var secrets = builder.Configuration
	.AsEnumerable()
	.Where(kvp => kvp.Key.StartsWith("UserSecrets:") && kvp.Value != null)
	.ToDictionary(kvp => kvp.Key[12..], kvp => kvp.Value!);

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
