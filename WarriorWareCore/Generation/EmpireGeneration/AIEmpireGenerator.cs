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

	public async Task<List<Empire>> GenerateEmpires(World world, int empireCount = 1)
	{
		var empireConjugation = empireCount > 1 ? "Empires" : "Empire";

		var messages = new List<ChatMessage>()
		{
			new SystemChatMessage(@$"Consider the high fantasy world of {world.Name}. The description of the world is as follows: {world.Description}
		
{world.Name} has existed for a long time. It is currently year {world.Year} of {world.Age}
		
Act as a worldbuilder of {world.Name}, your current task is to create an empire. The term empire here is used generically, so it can be a kingdom, a city-state, or any other form of government from any flavor of high fantasy.
		
Always respond with a JSON object representing a list of ""Empires"" as defined below. This will be parsed with code, so it has to exactly match the format below.
		
```
[
	{{
		""name"":""{StaticEmpireGenerator.DEFAULT_NAME}"",
		""description"":""{StaticEmpireGenerator.DEFAULT_DESCRIPTION}"",
		""population"":{StaticEmpireGenerator.DEFAULT_POPULATION}
	}},
	{{
		""name"":""{StaticEmpireGenerator.DEFAULT_NAME_2}"",
		""description"":""{StaticEmpireGenerator.DEFAULT_DESCRIPTION_2}"",
		""population"":{StaticEmpireGenerator.DEFAULT_POPULATION_2}
	}}
]
			```
			"),
			new UserChatMessage($"Generate {empireCount} new {empireConjugation} in previously specified JSON syntax. The output should be an array with {empireCount} elements")
		};

		var response = await communicator.GetResponse(messages);

		response = response.Replace("```", "").Replace("json", "").Trim();

		var deserializedEmpireList = JsonSerializer.Deserialize<List<Empire>>(response, new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,
		}) ?? throw new Exception("Empire Generation/Parsing Exception");

		return deserializedEmpireList
			.Select(deserializedEmpire => new Empire(Guid.NewGuid(), deserializedEmpire.Name, deserializedEmpire.Description, deserializedEmpire.Population))
			.ToList();
	}
}
