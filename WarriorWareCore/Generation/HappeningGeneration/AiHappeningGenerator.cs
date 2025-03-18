using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WarriorWareCore.AI;
using WarriorWareCore.Generation.EmpireGeneration;

namespace WarriorWareCore.Generation.HappeningGeneration;

public sealed class AIHappeningGenerator(IAzureAICommunicator communicator) : IHappeningGenerator
{
	private readonly IAzureAICommunicator communicator = communicator;

	public async Task<IEnumerable<Happening>> GenerateHappenings(World world, List<Empire> empires)
	{
		var messages = new List<ChatMessage>()
				{
					new SystemChatMessage(@$"Consider the high fantasy world of {world.Name}. The description of the world is as follows: {world.Description}

{world.Name} has existed for a long time. It is currently year {world.Year} of {world.Age}

{world.Name} is home to the following empires: {EmpiresToString(empires)}.

Act as a worldbuilder, and generate a list of 2 new happenings that could occur in this world. A happening is something that happens to an empire in the world, such as natural disater, plague, war, or era of prosperity. Each happening has an impact on the population of the empire, represented as a positive or negative integer. An event such as a war can impact multiple empires, in this case return a new happening for each affected empire.

Always respond with a JSON object representing a list of ""Happenings"" as defined below. This will be parsed with code, so it has to exactly match the format below.

```
[
	{{
		""empireName"":""{StaticHappeningGenerator.DEFAULT_EMPIRE_NAME}"",
		""description"":""{StaticHappeningGenerator.DEFAULT_DESCRIPTION}"",
		""populationChange"":{StaticHappeningGenerator.DEFAULT_POPULATION_CHANGE}
	}},
]
```
"),
					new UserChatMessage($"Generate 2-4 new happenings in the previously specified JSON syntax. The output should be a JSON array with 2-5 elements")
				};

		var response = await communicator.GetResponse(messages);

		response = response.Replace("```", "").Replace("json", "").Trim();

		var deserializedHappeningList = JsonSerializer.Deserialize<List<Happening>>(response, new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,
		}) ?? throw new Exception("Happening Generation/Parsing Exception");

		// TODO: Map the empirename to a guid
		return deserializedHappeningList
			.Select(deserializedHappening => new Happening(Guid.NewGuid(), Guid.NewGuid(), deserializedHappening.Description, deserializedHappening.PopulationChange) { EmpireName = deserializedHappening.EmpireName })
			.ToList();
	}

	private string EmpiresToString(List<Empire> empires)
	{
		var sb = new StringBuilder();
		foreach (var empire in empires)
		{
			sb.Append(empire.Name);
			sb.Append(": (");
			sb.Append(empire.Description);
			sb.Append("), (Current Population: ");
			sb.Append(empire.Population);
			sb.Append("), ");
		}
		sb.Remove(sb.Length - 2, 2); // Remove the last comma and space
		return sb.ToString();
	}
}
