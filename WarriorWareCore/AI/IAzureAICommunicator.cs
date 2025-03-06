using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.AI;
public interface IAzureAICommunicator
{
	Task<string> GetResponse(List<ChatMessage> messages);
}
