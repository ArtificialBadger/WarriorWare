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

	public static readonly string DEFAULT_NAME_2 = "Kingdom of Amber";
	public static readonly string DEFAULT_DESCRIPTION_2 = "Spanning over a vast archipeliago, the Kingdom of Amber is home to warriors who mix sword mastery with magical abilities to enhance their physical attributes. Each island has it's own govermnent, superceeded only by the central King on the capital island.";
	public static readonly int DEFAULT_POPULATION_2 = 350000;

	public Task<List<Empire>> GenerateEmpires(World world, int empireCount = 1)
	{
		return Task.FromResult(new List<Empire>() {
			new Empire(Guid.NewGuid(), DEFAULT_NAME, DEFAULT_DESCRIPTION, DEFAULT_POPULATION),
			new Empire(Guid.NewGuid(), DEFAULT_NAME_2, DEFAULT_DESCRIPTION_2, DEFAULT_POPULATION_2)
		});
	}
}
