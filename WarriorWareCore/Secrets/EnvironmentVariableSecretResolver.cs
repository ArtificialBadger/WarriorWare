using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Secrets;
public sealed class EnvironmentVariableSecretResolver : ISecretResolver
{
	public string ResolveSecret(string secretName)
	{
		return Environment.GetEnvironmentVariable(secretName) ?? throw new ArgumentException($"Environment variable '{secretName}' not found.");
	}
}
