using Microsoft.AspNetCore.Mvc;
using WarriorWareCore.Generation;
using WarriorWareCore.Generation.EmpireGeneration;
using WarriorWareCore.Generation.WorldGeneration;

namespace WarriorWare.Generation;

[ApiController]
[Route("[controller]")]
public class GenerationController(IWorldGenerator worldGenerator, IEmpireCreator empireCreator) : ControllerBase
{
	private readonly IWorldGenerator worldGenerator = worldGenerator;
	private readonly IEmpireCreator empireCreator = empireCreator;

	[HttpGet("world")]
	public async Task<IActionResult> GenerateWorld()
	{
		var world = await this.worldGenerator.GenerateWorld();
		return Ok(world);
	}

	[HttpGet("empire")]
	public async Task<IActionResult> GenerateEmpire()
	{
		var empire = await this.empireCreator.CreateEmpire();
		return Ok(empire);
	}
}