<Query Kind="Statements" />

string path = @"Compose\Run";
string file = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath)!, $@"src\Cake.Docker\{path}\args.txt");
//string file = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\Compose\Up\args.txt";
string[] lines = File.ReadAllLines(file);

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
foreach (string line in lines.Where(l =>!string.IsNullOrEmpty(l)).Select(l => l.TrimStart()))
{
	if (line.StartsWith("-"))
	{
		current = new List<string>();
		data.Add(line, current);
	}
	else
	{
		current.Add(line.Trim());
	}
}
string className = path.Replace(@"\", "");
"namespace Cake.Docker".Dump();
"{".Dump();
"/// <summary>".Dump();
$"/// Settings for docker {string.Join(" ", path.Split('\\').Select(p => p.ToLower()))}.".Dump();
"/// </summary>".Dump();
$"public sealed class Docker{className}Settings : DockerComposeSettings".Dump();
"{".Dump();
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
		comment.AddRange(pair.Value.Select(l => $"\t{l}"));
		"/// <summary>".Dump();
		foreach (string commentLine in comment)
		{
			("/// " + commentLine
				.Replace("<", "&lt;")
				.Replace(">", "&gt;"))
				.Dump();
		}
		"/// </summary>".Dump();
		string netType;
		switch (type)
		{
			case "duration":
				netType = "TimeSpan?";
				break;
			case "int?":
			case "int":
			case "uint":
				netType = "int?";
				break;
			case "value":
				if (info.EndsWith("[])"))
                {
					netType = "string[]?";
				}
				else
				{
					netType = "string=";
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
			"[AutoProperty(AutoArrayType=AutoArrayType.List)]".Dump();
		}
		$"public {netType} {name} {{ get; set; }}".Dump();
	}
}
"}".Dump();
"}".Dump();
