using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.WorldGeneration;

public sealed class StaticWorldGenerator : IWorldGenerator
{
	private static string worldName = "Alteria";
	private static string startingAge = "Age of Silver";
	private static int startingYear = 100;

	public Task<World> GenerateWorld()
	{
		var world = new World(Guid.NewGuid(), worldName, startingYear, startingAge);
		return Task.FromResult(world);
	}
}
