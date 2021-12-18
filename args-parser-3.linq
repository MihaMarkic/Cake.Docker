<Query Kind="Program" />

void Main()
{
	string path = @"BuildX\Bake";
	string file = $@"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\{path}\args.txt";
	string[] lines = File.ReadAllLines(file);

	//Regex regex = new Regex(
	//	  "--(?<Argument>[a-z0-9,\\-]+)(?:\\s(?<Type>\\w+))?\\s+(?<Info>.+" +
	//	  ")",
	//	RegexOptions.IgnoreCase
	//	| RegexOptions.Multiline
	//	| RegexOptions.CultureInvariant
	//	| RegexOptions.Compiled
	//	);
	string[] fileParts = path.Split('\\');
	string className = string.Join("", fileParts);

	"namespace Cake.Docker".Dump();
	"{".Dump();
	"/// <summary>".Dump();
	"/// Settings for docker swarm init.".Dump();
	"/// </summary>".Dump();
	$"public sealed class Docker{className}Settings : AutoToolSettings".Dump();
	"{".Dump();
	foreach (string line in lines)
	{
		string[] args = line.Split('\t');
		//$"{args[0]}|{args[1]}|{args[2]}".Dump();
		string[] commands = args[0].Split(',').Select(s => s.Trim()).ToArray();
		string argument = args[1].Trim();
		string description = args[2];
		string name = FormatName(commands[0]);
		string type = GetType(argument);		
		"/// <summary>".Dump();
		$"/// {args[0]}".Dump();
		if (!string.IsNullOrEmpty(argument))
		{
			$"/// default: {argument}".Dump();
		}
		$"/// {description}".Dump();
		"/// </summary>".Dump();
		$"public {type} {name} {{ get; set; }}".Dump();
	}
	"}".Dump();
	"}".Dump();
}

string FormatName(string argument)
{

	string name = "";
	bool upperCase = true;
	foreach (char c in argument.TrimStart('-'))
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
	return name;
}

string GetType(string defaultValue)
{
	string netType;
	if (string.IsNullOrEmpty(defaultValue))
	{
		netType = "string";
	}
	else if (int.TryParse(defaultValue, out int _))
	{
		netType = "int?";
	}
	else if (bool.TryParse(defaultValue, out bool _))
	{
		netType = "bool?";
	}
	else
	{
		netType = "string";
	}
	return netType;
}