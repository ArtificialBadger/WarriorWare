using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.HappeningGeneration;
public sealed class StaticHappeningGenerator : IHappeningGenerator
{
	public static readonly string DEFAULT_NAME = "Plague";
	public static readonly int DEFAULT_POPULATION_MODIFICATION = -10_000;

	public Task<IEnumerable<Happening>> GenerateHappenings(World world, List<Empire> empires)
	{
		var happenings = empires.Select(empire => new Happening(Guid.NewGuid(), empire.Id, DEFAULT_NAME, DEFAULT_POPULATION_MODIFICATION));

		return Task.FromResult(happenings);
	}
}
