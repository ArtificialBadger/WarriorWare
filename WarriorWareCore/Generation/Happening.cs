namespace WarriorWareCore.Generation;

public class Happening(Guid id, Guid empireId, string description, int populationChange)
{
	public Guid Id { get; set; } = id;
	
	public Guid EmpireId { get; set; } = empireId;
	
	public string Description { get; set; } = description;

	public int PopulationChange { get; set; } = populationChange;
}
