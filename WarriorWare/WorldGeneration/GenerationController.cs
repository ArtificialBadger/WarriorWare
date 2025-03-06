using Microsoft.AspNetCore.Mvc;
using WarriorWareCore.Generation;
using WarriorWareCore.Generation.EmpireGeneration;

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