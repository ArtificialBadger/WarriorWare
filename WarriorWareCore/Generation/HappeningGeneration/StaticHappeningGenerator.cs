using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorWareCore.Generation.EmpireGeneration;

namespace WarriorWareCore.Generation.HappeningGeneration;
public sealed class StaticHappeningGenerator : IHappeningGenerator
{
	public static readonly string DEFAULT_EMPIRE_NAME = StaticEmpireGenerator.DEFAULT_NAME;
	public static readonly string DEFAULT_DESCRIPTION = "Plague";
	public static readonly int DEFAULT_POPULATION_CHANGE = -10_000;

	public Task<IEnumerable<Happening>> GenerateHappenings(World world, List<Empire> empires)
	{
		var happenings = empires.Select(empire => new Happening(Guid.NewGuid(), empire.Id, DEFAULT_DESCRIPTION, DEFAULT_POPULATION_CHANGE));

		return Task.FromResult(happenings);
	}
}
