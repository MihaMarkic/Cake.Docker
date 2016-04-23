<Query Kind="Statements" />

string file = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\Build\args.txt";
string[] lines = File.ReadAllLines(file);

int delimiter = -1;
string firstLine = lines[0];
for (int i = 0; i < firstLine.Length; i++)
{
	if (firstLine[i] == ' ' && firstLine[i + 1] != '-')
	{
		delimiter = i;
		break;
	}
}
foreach (string line in lines)
{
	string cmd = line.Substring(0,delimiter).Trim();
	string info = line.Substring(delimiter+1).Trim();

	if (!string.IsNullOrEmpty(info) && !string.IsNullOrEmpty(cmd))
	{
		int pos = cmd.IndexOf("--") + 2;
		int eqPos = cmd.IndexOf('=', pos);
		string raw;
		bool isBool;
		bool isInt;
		bool isArray;
		string equals;
		if (eqPos >= 0)
		{
			isBool = false;
			raw = cmd.Substring(pos, eqPos - pos);
			equals = cmd.Substring(eqPos+1);
		}
		else
		{
			isBool = true;
			raw = cmd.Substring(pos);
			equals = null;
		}
		string name = "";
		bool upperCase = true;
		foreach (char c in raw)
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
		isArray = cmd.EndsWith("[]");
		int tmp;
		isInt = int.TryParse(equals, out tmp);
		"/// <summary>".Dump();
		("/// " + info).Dump();
		"/// </summary>".Dump();
		string type;
		switch (name.ToLower())
		{
			case "env":
				type = "Dictionary<string, string>";
				break;
			default:
				if (isBool)
				{
					type = "bool";
				}
				else if (isInt)
				{
					type = "int?";
				}
				else
				{
					type = "string" + (isArray ? "[]" : "");
				}
				break;
		}
		
		$"public {type} {name} {{ get; set; }}".Dump();
	}
}