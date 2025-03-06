namespace WarriorWareCore.Generation;

public class Empire(Guid id, string name, string description, int? population)
{
	public readonly static int DEFAULT_POPULATION = 1_000_000;

	public Guid Id { get; set; } = id;

	public string Name { get; set; } = name;

	public string Description { get; set; } = description;

	public int? Population { get; set; } = population;

}
