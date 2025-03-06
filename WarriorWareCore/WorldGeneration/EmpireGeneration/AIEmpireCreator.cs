using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WarriorWareCore.AI;

namespace WarriorWareCore.WorldGeneration.EmpireGeneration;
public sealed class AIEmpireCreator(IAzureAICommunicator communicator) : IEmpireCreator
{
	private readonly IAzureAICommunicator communicator = communicator;

	public Task<Empire> CreateEmpire()
	{
		return this.CreateEmpire(Guid.NewGuid());
	}

	public async Task<Empire> CreateEmpire(Guid id)
	{
		var worldName = "Alteria";
		var startingAge = "Age of Silver";
		var startingYear = "100";

		var messages = new List<ChatMessage>()
		{
			new UserChatMessage(@$"Consider the high fantasy world of {worldName}. This world is filled with magic, monsters, and political intrigue.
		
			{worldName} has existed for a long time. It is currently year {startingYear} of {startingAge}
		
			Act as a worldbuilder of {worldName}, your current task is to create an empire. The term empire here is used generically, so it can be a kingdom, a city-state, or any other form of government from any flavor of high fantasy.
		
			Always respond with a JSON object representing an ""Empire"". This will be parsed with code, so it has to exactly match the format below.
		
			```
			{{
				""name"":""Alpha Empire"",
				""description"":""The Alpha Empire is the original and most powerful empire in {worldName}, currently ruled by High King Elgrim and his Warriors of Alh."",
				""population"":{Empire.DEFAULT_POPULATION}
			}}
			```
			"),
		};

		var response = await communicator.GetResponse(messages);

		response = response.Replace("```", "").Replace("json", "").Trim();

		var deserializedEmpire = JsonSerializer.Deserialize<Empire>(response, new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,
		}) ?? new Empire(id, "Default Empire", "Something went wrong with the AI", Empire.DEFAULT_POPULATION);

		return new Empire(id, deserializedEmpire.Name, deserializedEmpire.Description, deserializedEmpire.Population ?? Empire.DEFAULT_POPULATION);	
	}
}
