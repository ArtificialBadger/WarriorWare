using Azure.AI.OpenAI;
using Azure;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorWareCore.Secrets;

namespace WarriorWareCore.AI;

public sealed class AzureAICommunicator : IAzureAICommunicator
{
	private readonly ISecretResolver secretResolver;

	private Lazy<AzureKeyCredential> credential;
	private Lazy<AzureOpenAIClient> client;
	private Lazy<ChatClient> chatClient;

	public AzureAICommunicator(ISecretResolver secretResolver)
	{
		this.secretResolver = secretResolver;

		credential = new Lazy<AzureKeyCredential>(() => new AzureKeyCredential(this.secretResolver.ResolveSecret("AzureAiApiKey")));
		client = new Lazy<AzureOpenAIClient>(() => new AzureOpenAIClient(new Uri(this.secretResolver.ResolveSecret("AzureAiEndpoint")), credential.Value));
		chatClient = new Lazy<ChatClient>(() => client.Value.GetChatClient(this.secretResolver.ResolveSecret("AzureAiDeployment")));
	}

	public async Task<string> GetResponse(List<ChatMessage> messages)
	{
		var options = new ChatCompletionOptions
		{
			Temperature = 1.1f,
			MaxOutputTokenCount = 800,
			TopP = 0.95f,
			FrequencyPenalty = 0f,
			PresencePenalty = 0f
		};

		ChatCompletion completion = await chatClient.Value.CompleteChatAsync(messages, options);

		if (completion != null)
		{
			// This is hacky as all hell, we are just taking the first text element from the completion
			foreach (var element in completion.Content)
			{
				if (element.Kind is ChatMessageContentPartKind.Text)
				{
					return element.Text;
				}
			}

			throw new Exception("No text element found in completion");
		}
		else
		{
			throw new NullReferenceException("completion is null");
		}

	}
}
