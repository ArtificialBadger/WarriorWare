namespace WarriorWareCore.Generation;

public class Empire(Guid id, string name, string description, int? population)
{
	public Guid Id { get; set; } = id;

	public string Name { get; set; } = name;

	public string Description { get; set; } = description;

	public int? Population { get; set; } = population;

}
