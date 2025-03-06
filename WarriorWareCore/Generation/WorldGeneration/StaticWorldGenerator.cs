using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.WorldGeneration;

public sealed class StaticWorldGenerator : IWorldGenerator
{
	public readonly static string WORLD_NAME = "Alteria";
	public readonly static string STARTING_AGE = "Age of Silver";
	public readonly static int STARTING_YEAR = 100;

	public Task<World> GenerateWorld()
	{
		var world = new World(Guid.NewGuid(), WORLD_NAME, STARTING_YEAR, STARTING_AGE);
		return Task.FromResult(world);
	}
}
