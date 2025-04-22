using Microsoft.AspNetCore.Mvc;
using WarriorWareCore.Generation;
using WarriorWareCore.Generation.EmpireGeneration;
using WarriorWareCore.Generation.HappeningGeneration;
using WarriorWareCore.Generation.WorldGeneration;

namespace WarriorWare.Generation;

[ApiController]
[Route("[controller]")]
public class GenerationController(IWorldGenerator worldGenerator, IEmpireGenerator empireCreator, IHappeningGenerator happeningGenerator) : ControllerBase
{
	private readonly IWorldGenerator worldGenerator = worldGenerator;
	private readonly IEmpireGenerator empireCreator = empireCreator;
	private readonly IHappeningGenerator happeningGenerator = happeningGenerator;

	[HttpGet("world")]
	public async Task<IActionResult> GenerateWorld([FromQuery] string? keywords)
	{
		var world = await this.worldGenerator.GenerateWorld(keywords);
		return Ok(world);
	}

	[HttpGet("empire")]
	public async Task<IActionResult> GenerateEmpire([FromQuery] int count = 1)
	{
		var world = await this.worldGenerator.GenerateWorld();

		var empires = await this.empireCreator.GenerateEmpires(world, count);
		
		return Ok(new List<object>() { world, empires }); // Stupid and bad, but easy to see what's going on
	}

	[HttpGet("happening")]
	public async Task<IActionResult> GenerateHappenings()
	{
		var world = await this.worldGenerator.GenerateWorld();

		var empires = await this.empireCreator.GenerateEmpires(world, 1);

		var happenings = await this.happeningGenerator.GenerateHappenings(world, empires);

		return Ok(new List<object>() { world, empires, happenings}); // Stupid and bad, but easy to see what's going on
	}
}