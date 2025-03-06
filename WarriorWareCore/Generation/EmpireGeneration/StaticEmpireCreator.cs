using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.EmpireGeneration;
public sealed class StaticEmpireCreator : IEmpireCreator
{
	private static Empire empire = new Empire(Guid.NewGuid(), "Alpha Empire", "A powerful empire with a rich history. Some say it's the first empire to ever exist", Empire.DEFAULT_POPULATION);

	public Task<Empire> CreateEmpire()
	{
		return Task.FromResult(empire);
	}
	public Task<Empire> CreateEmpire(Guid id)
	{
		return Task.FromResult(new Empire(id, empire.Name, empire.Description, empire.Population));
	}
}
