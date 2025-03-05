using Microsoft.AspNetCore.Mvc;
using WarriorWareCore.WorldGeneration;

namespace WarriorWare.WorldGeneration;

[ApiController]
[Route("[controller]")]
public class GenerationController : ControllerBase
{
	public GenerationController()
	{
	}

	[HttpGet("empire")]
	public async Task<IActionResult> GenerateEmpire()
	{
		await Task.CompletedTask;
		var empire = new Empire(Guid.NewGuid(), "Empire of the Sun", "A powerful empire with a rich history.");
		return Ok(empire);
	}
}
