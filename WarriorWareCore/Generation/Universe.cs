using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation;
public sealed class Universe
{
	public required World World { get; set; }

	public required List<Empire> Empires { get; set; }

	public required List<Event> Events { get; set; }
}
