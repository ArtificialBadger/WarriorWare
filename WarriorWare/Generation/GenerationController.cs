using Microsoft.AspNetCore.Mvc;
using WarriorWareCore.Generation;
using WarriorWareCore.Generation.EmpireGeneration;
using WarriorWareCore.Generation.WorldGeneration;

namespace WarriorWare.Generation;

[ApiController]
[Route("[controller]")]
public class GenerationController(IWorldGenerator worldGenerator, IEmpireGenerator empireCreator) : ControllerBase
{
	private readonly IWorldGenerator worldGenerator = worldGenerator;
	private readonly IEmpireGenerator empireCreator = empireCreator;

	[HttpGet("world")]
	public async Task<IActionResult> GenerateWorld()
	{
		var world = await this.worldGenerator.GenerateWorld();
		return Ok(world);
	}

	[HttpGet("empire")]
	public async Task<IActionResult> GenerateEmpire([FromQuery] int count = 1)
	{
		var world = await this.worldGenerator.GenerateWorld();

		var empires = await this.empireCreator.GenerateEmpires(world, count);
		return Ok(new List<object>() { world, empires } ); // Stupid and bad, but easy to see what's going on
	}
}