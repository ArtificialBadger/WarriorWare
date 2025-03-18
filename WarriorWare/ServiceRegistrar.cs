using WarriorWareCore.AI;
using WarriorWareCore.Secrets;
using WarriorWareCore.Generation.EmpireGeneration;
using WarriorWareCore.Generation.WorldGeneration;
using WarriorWareCore.Generation.HappeningGeneration;

namespace WarriorWare;

public static class ServiceRegistrar
{
	public static void RegisterServices(IServiceCollection services)
	{
		//services.AddTransient<IEmpireCreator, StaticEmpireCreator>();
		services.AddTransient<IEmpireGenerator, AIEmpireGenerator>();
		services.AddTransient<IWorldGenerator, AIWorldGenerator>();
		services.AddTransient<IHappeningGenerator, AIHappeningGenerator>();

		services.AddSingleton<ISecretResolver, EnvironmentVariableSecretResolver>();
		services.AddSingleton<IAzureAICommunicator, AzureAICommunicator>();
	}
}
