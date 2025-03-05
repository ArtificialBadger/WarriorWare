using WarriorWareCore.Secrets;
using WarriorWareCore.WorldGeneration.EmpireGeneration;

namespace WarriorWare;

public static class ServiceRegistrar
{
	public static void RegisterServices(IServiceCollection services)
	{
		services.AddTransient<IEmpireCreator, StaticEmpireCreator>();
		services.AddTransient<ISecretResolver, EnvironmentVariableSecretResolver>(); // Could be singleton for caching
	}
}
