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
	public async Task<IActionResult> GenerateEmpire()
	{
		var world = await this.worldGenerator.GenerateWorld();

		var empire = await this.empireCreator.GenerateEmpire(world);
		return Ok(new List<object>() { world, empire } ); // Stupid and bad
	}
}