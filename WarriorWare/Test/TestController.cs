using Microsoft.AspNetCore.Mvc;

namespace WarriorWare.Generation;

[ApiController]
[Route("[controller]")]
public class TestController() : ControllerBase
{
	[HttpGet("status")]
	public IActionResult StatusTest([FromQuery] int? requestedStatusCode = 200)
	{
		return StatusCode(requestedStatusCode ?? 200);
	}
}