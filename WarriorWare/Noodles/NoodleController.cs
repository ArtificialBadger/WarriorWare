using Microsoft.AspNetCore.Mvc;
using WarriorWareCore.Secrets;

namespace WarriorWare.Noodles;

[ApiController]
public class NoodleController(ISecretResolver secretResolver) : ControllerBase
{
	private readonly ISecretResolver secretResolver = secretResolver;

	[HttpGet("noodle")]
	public IActionResult GetNoodle()
	{
		var secret = this.secretResolver.ResolveSecret("AzureAiApiKey");
		return Ok(secret);
	}
}
