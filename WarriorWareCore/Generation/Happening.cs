namespace WarriorWareCore.Generation;

public class Happening(Guid id, Guid empireId, string description, int populationChange)
{
	public required Guid Id { get; set; } = id;
	
	public required Guid EmpireId { get; set; } = empireId;
	
	public required string Description { get; set; } = description;

	public required int PopulationChange { get; set; } = populationChange;
}
