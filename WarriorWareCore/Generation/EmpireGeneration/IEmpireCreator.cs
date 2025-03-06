using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.EmpireGeneration;

public interface IEmpireCreator
{
	Task<Empire> CreateEmpire();

	Task<Empire> CreateEmpire(Guid id);
}
