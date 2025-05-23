﻿using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WarriorWareCore.AI;

namespace WarriorWareCore.Generation.WorldGeneration;

public sealed class AIWorldGenerator(IAzureAICommunicator communicator) : IWorldGenerator
{
	private readonly IAzureAICommunicator communicator = communicator;

	public async Task<World> GenerateWorld(string? keywords = null)
	{
		if (keywords is null)
		{
			keywords = "dwarves, mystic stones, deep-dwelling demons";
		}

		var messages = new List<ChatMessage>()
		{
			new SystemChatMessage(@$"Act as a worldbuilder, specialized in high fantasy worlds that include any number of fantastical things such as powerful warriors and mages, mythical beasts, and strange and wild magics.
		
Always respond with a JSON object representing a ""World"", as defined below. This will be parsed with code, so it has to exactly match the format below.

Here are some additional keywords to help you generate the world: {keywords}
		
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
