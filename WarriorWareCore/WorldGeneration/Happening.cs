﻿namespace WarriorWareCore.WorldGeneration;

public class Happening(Guid id, Guid empireId, string description)
{
	public required Guid Id { get; set; } = id;
	public required Guid EmpireId { get; set; } = empireId;
	public required string Description { get; set; } = description;
}
