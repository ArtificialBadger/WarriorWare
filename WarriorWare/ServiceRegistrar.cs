using WarriorWareCore.AI;
using WarriorWareCore.Secrets;
using WarriorWareCore.Generation.EmpireGeneration;
using WarriorWareCore.Generation.WorldGeneration;

namespace WarriorWare;

public static class ServiceRegistrar
{
	public static void RegisterServices(IServiceCollection services)
	{
		//services.AddTransient<IEmpireCreator, StaticEmpireCreator>();
		services.AddTransient<IEmpireCreator, AIEmpireCreator>();
		services.AddTransient<IWorldGenerator, StaticWorldGenerator>();

		services.AddSingleton<ISecretResolver, EnvironmentVariableSecretResolver>();
		services.AddSingleton<IAzureAICommunicator, AzureAICommunicator>();
	}
}
