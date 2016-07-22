<Query Kind="Statements" />

string file = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\SwarmInit\args.txt";
string[] lines = File.ReadAllLines(file);

Regex regex = new Regex(
	  "--(?<Argument>[a-z,\\-]+)(?:\\s(?<Type>\\w+))?\\s+(?<Info>.+" +
	  ")",
	RegexOptions.IgnoreCase
	| RegexOptions.Multiline
	| RegexOptions.CultureInvariant
	| RegexOptions.Compiled
	);

foreach (string line in lines)
{
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
		"/// <summary>".Dump();
		("/// " + info).Dump();
		"/// </summary>".Dump();
		string netType;
		switch (type)
		{
			case "duration":
				netType = "TimeSpan?";
				break;
			case "int?":
				netType = "int";
				break;
			case "value":
				netType = "string";
				break;
			default:
				netType = "bool";
				break;
		}
		$"public {netType} {name} {{ get; set; }}".Dump();
	}
}
