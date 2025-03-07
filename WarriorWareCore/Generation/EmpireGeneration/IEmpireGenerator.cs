using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation.EmpireGeneration;

public interface IEmpireGenerator
{
	Task<List<Empire>> GenerateEmpires(World world, int empireCount = 1);
}
