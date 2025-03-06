using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		var messages = new List<ChatMessage>()
		{
			new UserChatMessage("Generate an custom Empire in a unique magical high fantasy world. Give only the text for the description of this empire.")
		};

		var response = await communicator.GetResponse(messages);

		return new Empire(id, "Ai Generated Empire", response);	
	}
}
