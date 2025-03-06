using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Generation;

// Don't want to use record here because the year info will be changing 
public sealed class World(Guid id, string name, int year, string age)
{
	public Guid Id { get; init; } = id;

	public string Name { get; init; } = name;

	// Could use string here and let the AI have a bit more fun with it
	public int Year { get; set; } = year;

	public string Age { get; set; } = age;
}
