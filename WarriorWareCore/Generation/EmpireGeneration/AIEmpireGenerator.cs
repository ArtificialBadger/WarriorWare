using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WarriorWareCore.AI;
using WarriorWareCore.Generation.WorldGeneration;

namespace WarriorWareCore.Generation.EmpireGeneration;
public sealed class AIEmpireGenerator(IAzureAICommunicator communicator) : IEmpireGenerator
{
	private readonly IAzureAICommunicator communicator = communicator;

	public async Task<Empire> GenerateEmpire(World world)
	{

		var messages = new List<ChatMessage>()
		{
			new SystemChatMessage(@$"Consider the high fantasy world of {world.Name}. The description of the world is as follows: {world.Description}
		
			{world.Name} has existed for a long time. It is currently year {world.Year} of {world.Age}
		
			Act as a worldbuilder of {world.Name}, your current task is to create an empire. The term empire here is used generically, so it can be a kingdom, a city-state, or any other form of government from any flavor of high fantasy.
		
			Always respond with a JSON object representing an ""Empire"". This will be parsed with code, so it has to exactly match the format below.
		
			```
			{{
				""name"":""{StaticEmpireGenerator.DEFAULT_NAME}"",
				""description"":""{StaticEmpireGenerator.DEFAULT_DESCRIPTION}"",
				""population"":{StaticEmpireGenerator.DEFAULT_POPULATION}
			}}
			```
			"),
			new UserChatMessage("Generate a new empire in the previously specified JSON syntax.")
		};

		var response = await communicator.GetResponse(messages);

		response = response.Replace("```", "").Replace("json", "").Trim();

		var deserializedEmpire = JsonSerializer.Deserialize<Empire>(response, new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,
		}) ?? throw new Exception("Empire Generation/Parsing Exception");

		return new Empire(Guid.NewGuid(), deserializedEmpire.Name, deserializedEmpire.Description, deserializedEmpire.Population);	
	}
}
