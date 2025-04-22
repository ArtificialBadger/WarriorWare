using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.WorldGeneration;

public interface IWorldGenerator
{
	public Task<World> GenerateWorld(string? keywords = null);
}
