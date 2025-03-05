using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorWareCore.Secrets;
public interface ISecretResolver
{
	public string ResolveSecret(string secretName);
}
