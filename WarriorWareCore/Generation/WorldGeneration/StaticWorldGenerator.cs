using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.WorldGeneration;

public sealed class StaticWorldGenerator : IWorldGenerator
{
	public readonly static string DEFAULT_NAME = "Alteria";
	public readonly static string DEFAULT_DESCRIPTION = "Alteria";
	public readonly static string DEFAULT_STARTING_AGE = "Age of Silver";
	public readonly static int DEFAULT_STARTING_YEAR = 100;

	public Task<World> GenerateWorld()
	{
		var world = new World(Guid.NewGuid(), DEFAULT_NAME, DEFAULT_DESCRIPTION, DEFAULT_STARTING_YEAR, DEFAULT_STARTING_AGE);
		return Task.FromResult(world);
	}
}
