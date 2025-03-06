using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WarriorWareCore.AI;

namespace WarriorWareCore.Generation.WorldGeneration;

public sealed class AiWorldGenerator(IAzureAICommunicator communicator) : IWorldGenerator
{
	private readonly IAzureAICommunicator communicator = communicator;

	public async Task<World> GenerateWorld()
	{
		var messages = new List<ChatMessage>()
		{
			new SystemChatMessage(@$"Act as a worldbuilder, specialized in high fantasy worlds that include powerful warriors and mages, mythical beasts, and strange and wild magics.
		
			Always respond with a JSON object representing an ""Empire"". This will be parsed with code, so it has to exactly match the format below.
		
			```
			{{
				""name"":""{StaticWorldGenerator.DEFAULT_NAME}"",
				""description"":""{StaticWorldGenerator.DEFAULT_DESCRIPTION}"",
				""age"":""{StaticWorldGenerator.DEFAULT_STARTING_AGE}"",
				""year"":{StaticWorldGenerator.DEFAULT_STARTING_YEAR}
			}}
			```
			"),

			new UserChatMessage("Generate a new world in the previously specified JSON syntax.")
		};

		var response = await communicator.GetResponse(messages);

		response = response.Replace("```", "").Replace("json", "").Trim();

		var deserializedWorld = JsonSerializer.Deserialize<World>(response, new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,
		}) ?? throw new Exception("World Generation Exception");

		return new World(Guid.NewGuid(), deserializedWorld.Name, deserializedWorld.Description, deserializedWorld.Year, deserializedWorld.Age);

	}
}
