using Microsoft.AspNetCore.Mvc;
using WarriorWareCore.WorldGeneration;
using WarriorWareCore.WorldGeneration.EmpireGeneration;

namespace WarriorWare.WorldGeneration;

[ApiController]
[Route("[controller]")]
public class GenerationController(IEmpireCreator empireCreator) : ControllerBase
{
	private readonly IEmpireCreator empireCreator = empireCreator;	

	[HttpGet("empire")]
	public async Task<IActionResult> GenerateEmpire()
	{
		var empire = await this.empireCreator.CreateEmpire();
		return Ok(empire);
	}
}
