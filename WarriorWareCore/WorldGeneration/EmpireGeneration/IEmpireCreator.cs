﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.WorldGeneration.EmpireGeneration;

public interface IEmpireCreator
{
	Task<Empire> CreateEmpire();

	Task<Empire> CreateEmpire(Guid id);
}
