using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.EmpireGeneration;
public sealed class StaticEmpireGenerator : IEmpireGenerator
{
	public static readonly string DEFAULT_NAME = "Alpha Empire";
	public static readonly string DEFAULT_DESCRIPTION = "A powerful empire with a rich history. Some say it's the first empire to ever exist";
	public static readonly int DEFAULT_POPULATION = 1000000;

	public Task<Empire> GenerateEmpire(World world)
	{
		return Task.FromResult(new Empire(Guid.NewGuid(), DEFAULT_NAME, DEFAULT_DESCRIPTION, DEFAULT_POPULATION));
	}
}
