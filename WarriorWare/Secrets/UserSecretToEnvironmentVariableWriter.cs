namespace WarriorWare.Secrets;

// This seems kinda silly
// Read from user secrets, write to environment variables
// This lets the Core librarys read from environment variables and don't have to worry about how they get there
// If I really cared, I'd set up a KeyVault, but I don't so I won't
public static class UserSecretToEnvironmentVariableWriter
{
	public static void WriteAllUserSecretsToEnvironmentVariables(Dictionary<string, string> secrets)
	{
		foreach(var secretPair in secrets)
		{
			Environment.SetEnvironmentVariable(secretPair.Key, secretPair.Value);
		}
	}
}
