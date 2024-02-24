<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

void Main()
{
	string[] commands = new[] { "Build", "Cp", "Create", "Down", "Exec", "Kill", "Logs", "Pause", "Port", "Ps", "Pull", "Push", "Restart", "Rm", "Run", "Scale", "Start", "Stop", "Unpase", "Up" };
	foreach (string command in commands)
	{
		CreateSettings(@$"Compose\{command}", true);
	}
}

int CountSpaces(string line)
{
	int result = 0;
	foreach (char c in line)
	{
		if (c != ' ')
		{
			break;
		}
		result++;
	}
	return result;
}

void CreateSettings(string command, bool outputToFile)
{
	string file = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath)!, $@"src\Cake.Docker\{command}\args.txt");
	if (!File.Exists(file))
	{
		file.Dump("Skipping, does not exist");
		return;
	}
	string className = command.Replace(@"\", "");
	string settingsFile = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath)!, $@"src\Cake.Docker\{command}\\Docker{className}Settings.cs");
	//string file = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\Compose\Up\args.txt";
	string[] lines = File.ReadAllLines(file);
	//string.Join(Environment.NewLine, lines).Dump();

	Regex regex = new Regex(
		  "--(?<Argument>[a-z0-9,\\-]+)(?:\\s(?<Type>\\w+))?\\s+(?<Info>.+" +
		  ")",
		RegexOptions.IgnoreCase
		| RegexOptions.Multiline
		| RegexOptions.CultureInvariant
		| RegexOptions.Compiled
		);

	Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
	List<string>? current = null;
	foreach (string line in lines.Where(l => !string.IsNullOrEmpty(l)))
	{
		int offset = CountSpaces(line);
		var trimmed = line.AsSpan().Trim();
		if (offset < 34 && trimmed.StartsWith("-"))
		{
			current = new List<string>();
			data.Add(line, current);
		}
		current!.Add(trimmed.ToString());
	}
	StringBuilder sb = new();
	
	sb.AppendLine("namespace Cake.Docker;");
	sb.AppendLine("/// <summary>");
	sb.AppendLine($"/// Settings for docker {string.Join(" ", command.Split('\\').Select(p => p.ToLower()))}.");
	sb.AppendLine("/// </summary>");
	sb.AppendLine($"public sealed class Docker{className}Settings : AutoToolSettings");
	sb.AppendLine("{");
	foreach (var pair in data)
	{
		string line = pair.Key;

		var match = regex.Match(line);
		if (!match.Success)
		{
			("FAILED to match " + line).Dump();
		}
		else
		{
			string rawName = match.Groups["Argument"].Value;
			string type = match.Groups["Type"].Value;
			string info = match.Groups["Info"].Value;
			string name = "";
			bool upperCase = true;
			foreach (char c in rawName)
			{
				if (upperCase)
				{
					name += char.ToUpper(c);
					upperCase = false;
				}
				else
				{
					if (c == '-')
					{
						upperCase = true;
					}
					else
					{
						name += c;
					}
				}
			}
			List<string> comment = new List<string>();
			comment.Add(info);
			comment.AddRange(pair.Value.Skip(1).Select(l => $"{l}"));
			sb.AppendLine("\t/// <summary>");
			foreach (string commentLine in comment)
			{
				sb.AppendLine("\t/// " + commentLine
					.Replace("<", "&lt;")
					.Replace(">", "&gt;"));
			}
			sb.AppendLine("\t/// </summary>");
			string netType;
			switch (type)
			{
				case "duration":
					netType = "TimeSpan?";
					break;
				case "int?":
				case "int":
				case "uint":
				case "bytes":
					netType = "int?";
					break;
				case "value":
					if (info.EndsWith("[])"))
					{
						netType = "string[]?";
					}
					else
					{
						netType = "string?=";
					}
					break;
				case "string":
					netType = "string?";
					break;
				case "strings":
					netType = "string[]?";
					break;
				case "stringArray":
					netType = "string[]?";
					break;
				default:
					netType = "bool?";
					break;
			}
			if (type == "stringArray")
			{
				sb.AppendLine("\t[AutoProperty(AutoArrayType=AutoArrayType.List)]");
			}
			sb.AppendLine($"\tpublic {netType} {name} {{ get; set; }}");
		}
	}
	sb.AppendLine("}");
	if (outputToFile)
	{
		File.WriteAllText(settingsFile, sb.ToString());
	}
	else
	{
		sb.Dump();
	}

}