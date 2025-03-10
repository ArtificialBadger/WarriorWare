# WarriorWare

WarriorWare is an ASP.Net Core app with the goal of automating parts of the worldbuilding process.

Create a world, generate empires within the world, and see how they interact as time passes.

This project is currently in very early stages and has only basic Proof of Concept functionallity.

## Running Locally

This project currently requires a connection to an Azure OpenAI deployment. 

In the associated secrets file (in Visual Studio, right click on the WarriorWare project and select "Manage User Secrets") add values for the following.

- UserSecrets:AzureAiApiKey
- UserSecrets:AzureAiEndpoint
- UserSecrets:AzureAiDeployment

Alternatively, creating a new AI Communicator class is possible, but may require translating the Azure.AI objects into similar objects of a different SDK. This is not overly complex and could be done easily if using a local LLM or other hosted AI service. Currently there are no plans to add LLM connectivity other than Azure OpenAI.

## Contributing

Contributions would certainly be unexpected, as this project is unlikely to be of interest.
