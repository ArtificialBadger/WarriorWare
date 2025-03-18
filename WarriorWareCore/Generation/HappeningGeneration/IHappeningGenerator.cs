using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.HappeningGeneration;
public interface IHappeningGenerator
{
	public Task<IEnumerable<Happening>> GenerateHappenings(World world, List<Empire> empires);
}
