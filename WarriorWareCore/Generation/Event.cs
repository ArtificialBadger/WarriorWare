namespace WarriorWareCore.Generation;

public class Event(Guid id, String name, IEnumerable<Happening> happenings)
{
	public required Guid Id { get; set; } = id;

	public required string Name { get; set; } = name;

	public required IEnumerable<Happening> Happenings { get; set; } = happenings;
}
