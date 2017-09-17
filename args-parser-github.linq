<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Humanizer.Core.uk</NuGetReference>
  <NuGetReference>System.Collections.Immutable</NuGetReference>
  <NuGetReference>YamlDotNet</NuGetReference>
  <Namespace>Humanizer</Namespace>
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>YamlDotNet.Serialization</Namespace>
</Query>

const string root = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\";
Input[] inputs = new Input[] { 
//	new Input(Path.Combine("Image", "Build")),
//	new Input(Path.Combine("Image", "Load")),
//	new Input(Path.Combine("Image", "Pull")),
//	new Input(Path.Combine("Image", "Push")),
//	new Input(Path.Combine("Image", "Remove")),
//	new Input(Path.Combine("Image", "Save")),
//	new Input(Path.Combine("Image", "Tag")),
//	new Input(Path.Combine("Container", "Cp"), "Copy"),
	new Input(Path.Combine("Container", "Create")),
//	new Input(Path.Combine("Container", "Exec")),
//	new Input(Path.Combine("Container", "Rm")),
//	new Input(Path.Combine("Container", "Run")),
//	new Input(Path.Combine("Container", "Stop")),
};
public class Input
{
	public readonly string Path;
	public readonly string GoCommandName;
	public readonly string OriginalCommandName;
	public readonly 
	
	public Input(string path, string goCommandName = null)
	{
		string[] parts = path.Split(new[] { System.IO.Path.DirectorySeparatorChar});
		Path = path;
		OriginalCommandName = parts[parts.Length-1];
		GoCommandName = goCommandName != null ? goCommandName: OriginalCommandName;
	}
}

async Task Main()
{
	foreach (var input in inputs)
	{
		$"Processing ${input.Path}".Dump();
		await ProcessCommandAsync(input.Path, input.GoCommandName, input.OriginalCommandName);
	}
}

async Task ProcessCommandAsync(string path, string command, string originalCommandName)
{
	var httpClient = new HttpClient { BaseAddress = new Uri("https://raw.githubusercontent.com/docker/cli/master/cli/command/") };
	string[] parts = path.Split(new[] { System.IO.Path.DirectorySeparatorChar});
	string url = string.Join("/",parts).ToLower();
	string source = await httpClient.GetStringAsync($"{url}.go");
//	source.Dump();

	var lines = source.Split('\n').Select(l => l.Trim()).ToArray();

	var typeRegex = new Regex(
	  $"^\\s*type\\s+{command.ToLower()}Options\\s+struct\\s*{{\\s*$",
			RegexOptions.IgnoreCase
			| RegexOptions.Multiline
			| RegexOptions.CultureInvariant
			| RegexOptions.IgnorePatternWhitespace
			| RegexOptions.Compiled
			);
	string cmdRegexText = $"^\\s*func\\s+New{command}Command\\s*\\(\\s*dockerCli\\s+[*]?command." +
	  "\\w*Cli\\s*\\)\\s*\\*cobra.Command\\s*{\\s*$";
	var cmdRegex = new Regex(cmdRegexText,
	RegexOptions.IgnoreCase
	| RegexOptions.Multiline
	| RegexOptions.CultureInvariant
	| RegexOptions.IgnorePatternWhitespace
	| RegexOptions.Compiled
	);
	
	bool isMatch = cmdRegex.IsMatch("func NewCopyCommand(dockerCli *command.DockerCli) *cobra.Command {");
	var typesAndFlags = CollectTypesAndFlags(lines, typeRegex, cmdRegex);
	var args = GetOptArguments(typesAndFlags.Types);
	if (typesAndFlags.Trust.HasValue)
	{
		var resize = new List<Argument>(args);
		resize.Add(new Argument { RawType="bool", OptName = "disableContentTrust", Long = "disable-content-trust", Type="bool", Default="true", 
		Description = "Skip image " + (typesAndFlags.Trust.Value == Trust.Verification ? "verification": "signing")});
		args = resize.ToArray();
	}
	FillArgumentsWithFlags(args, typesAndFlags.Flags);
	var validArgs = args.Where(a => !string.IsNullOrEmpty(a.Long)).ToArray();
	validArgs.Dump();
	string output = OutputContent(validArgs, command, typesAndFlags.Use, typesAndFlags.Description);
	string fileName = Path.Combine(root, path, $"Docker{originalCommandName}Settings.cs");
	File.WriteAllText( fileName, output);
//	output.Dump();
}

string OutputContent(Argument[] args, string className, string use, string description)
{
	StringBuilder sb = new StringBuilder();
	sb.AppendLine("using System;");
	sb.AppendLine();
	sb.AppendLine("namespace Cake.Docker");
	sb.AppendLine("{");
	sb.AppendLine("\t/// <summary>");
	sb.AppendLine($"\t/// Settings for docker {use}.");
	sb.AppendLine($"\t/// {description}");
	sb.AppendLine("\t/// </summary>");
	sb.AppendLine($"\tpublic sealed class Docker{className}Settings : AutoToolSettings");
	sb.AppendLine("\t{");
	foreach (var arg in args.OrderBy(a => a.NetName))
	{
		sb.AppendLine("\t\t/// <summary>");
		sb.AppendLine($"\t\t/// {arg.NameInfo}");
		if (!string.IsNullOrEmpty(arg.Default))
		{
			sb.AppendLine($"\t\t/// default: {arg.NetDefault}");
		}
		sb.AppendLine($"\t\t/// {arg.Description}");
		sb.AppendLine("\t\t/// </summary>");
		if (arg.IsExperimental || !string.IsNullOrEmpty(arg.Version))
		{
			sb.AppendLine("\t\t/// <remarks>");
			if (arg.IsExperimental)
			{
				sb.AppendLine($"\t\t/// Experimental");
			}
			if (!string.IsNullOrEmpty(arg.Version))
			{
				sb.AppendLine($"\t\t/// Version: {arg.Version}");
			}
			sb.AppendLine("\t\t/// </remarks>");
		}
		sb.AppendLine($"\t\tpublic {arg.NetTypeName} {arg.NetName} {{ get; set; }}");
	}
	sb.AppendLine("\t}");
	sb.Append("}");
	return sb.ToString();
}

(string[] Types, string[] Flags, string Use, string Description, Trust? Trust) CollectTypesAndFlags(string[] lines, Regex typeRegex, Regex cmdRegex)
{
	var state = State.SearchingType;
	var types = new List<string>();
	var flags = new List<string>();
	string use = null;
	string description = null;
	Trust? trust = null;
	bool isInCommand = false;
	foreach (string line in lines)
	{
		if (isInCommand)
		{
			if (use == null && line.StartsWith("Use:"))
			{
				use = ExtractText(line);
			}
			else if (description == null && line.StartsWith("Short:"))
			{
				description = ExtractText(line);
			}
		}
		switch (state)
		{
			case State.SearchingType:
				if (typeRegex.IsMatch(line))
				{
					"Type start found".Dump();
					state = State.CollectingType;
				}
				else if (cmdRegex.IsMatch(line))
				{
					"Command header found".Dump();
					isInCommand = true;
				}
				else if (line.StartsWith("flags "))
				{
					"Command start found".Dump();
					state = State.CollectingFlags;
				}
				break;
			case State.CollectingType:
				if (line == "}")
				{
					"Type end found".Dump();
					state = State.SearchingFlags;
				}
				else if (!string.IsNullOrEmpty(line))
				{
					types.Add(line);
				}
				break;
			case State.SearchingFlags:
				if (line.StartsWith("flags "))
				{
					"Command start found".Dump();
					state = State.CollectingFlags;
				}
				else if (cmdRegex.IsMatch(line))
				{
					"Command header found".Dump();
					isInCommand = true;
				}
				break;
			case State.CollectingFlags:
				if (line == "}")
				{
					"Command end found".Dump();
					return (types.ToArray(), flags.ToArray(), use, description, trust);
				}
				else if (line.StartsWith("flags."))
				{
					flags.Add(line);
				}
				else if (!trust.HasValue)
				{
					if (line == "command.AddTrustVerificationFlags(flags)")
					{
						trust = Trust.Verification;
					}
					else if (line == "command.AddTrustSigningFlags(flags)")
					{
						trust = Trust.Signing;
					}
				}
				break;
			default:
				throw new Exception($"Invalid state {state}");
		}
	}
	"Failed parsing".Dump();
	return (null, null, use, description, trust);
}
string ExtractText(string content)
{
	int openQuotationsIndex = content.IndexOf('"');
	//int closeQuotationsIndex = content.IndexOf('"', openQuotationsIndex + 1);
//	return content.Substring(openQuotationsIndex + 1, closeQuotationsIndex - openQuotationsIndex - 1);
	return content.Substring(openQuotationsIndex + 1).TrimEnd('"');
}

void FillArgumentsWithFlags(Argument[] arguments, string[] flags)
{
	var dict = arguments.ToDictionary(a => a.OptName, a => a);
	bool hasTrustVerification = false;
	foreach (string flag in flags)
	{
		int dotIndex = flag.IndexOf('.');
		int openBracketIndex = flag.IndexOf('(', dotIndex + 1);
		string type = flag.Substring(dotIndex + 1, openBracketIndex - dotIndex - 1);
		string content = flag.Substring(openBracketIndex + 1, flag.Length - (openBracketIndex + 1) - 1);
		switch (type)
		{
			case "SetAnnotation":
				{
					int openQuotationsIndex  = content.IndexOf('"');
					int closeQuotationsIndex = content.IndexOf('"', openQuotationsIndex + 1);
					string fullName = content.Substring(openQuotationsIndex + 1, closeQuotationsIndex - openQuotationsIndex - 1);
					var arg = arguments.Single(a => a.Long == fullName);
					int firstCommaIndex = content.IndexOf(',', closeQuotationsIndex+1);
					AnnotateArgument(arg, content.Substring(firstCommaIndex + 1).Trim());
				}
				break;
			case "VarP":
			case "Var":
			case "StringVarP":
			case "Int64VarP":
			case "BoolVarP":
			case "Int64Var":
			case "StringVar":
			case "BoolVar":
			case "StringSliceVar":
				{
					dotIndex = content.IndexOf('.');
					int firstCommaIndex = content.IndexOf(',');
					string fullName = content.Substring(dotIndex + 1, firstCommaIndex - dotIndex - 1);
					var arg = dict[fullName];
					PopulateArgument(arg, type, content.Substring(firstCommaIndex + 1).Trim());
				}
				break;
		}
	}
}
void AnnotateArgument(Argument arg, string content)
{
	string[] parts = PartsWithStrings(content);
	string type = parts[0];
	switch (type)
	{
		case "experimental":
			arg.IsExperimental = true;
			break;
		case "version":
			string value = parts[1];
			int openQuotationsIndex = value.IndexOf('{');
			int closeQuotationsIndex = value.IndexOf('}', openQuotationsIndex + 1);
			arg.Version = value.Substring(openQuotationsIndex + 1, closeQuotationsIndex - openQuotationsIndex - 1);
			break;
	}
}
void PopulateArgument(Argument args, string type, string content)
{
	string[] parts = PartsWithStrings(content);
	args.Long = parts[0];
	switch (type)
	{
		case "VarP":
			args.Short = parts[1];
			args.Description = parts[2];
			break;
		case "Var":
			args.Description = parts[1];
			break;
		case "StringVarP":
		case "Int64VarP":
		case "BoolVarP":
			args.Short = parts[1];
			args.Default = parts[2];
			args.Description = parts[3];
			break;
		case "Int64Var":
		case "StringVar":
		case "BoolVar":
		case "StringSliceVar":
			args.Default = parts[1];
			args.Description = parts[2];
			break;
		case "SetAnnotation":
			break;
	}
}

string[] PartsWithStrings(string content)
{
	var result = new List<string>();
	var item = new StringBuilder();
	bool isString = false;
	foreach (char c in content)
	{
		if (c == '"')
		{
			isString = !isString;
		}
		else if (c == ',' && !isString)
		{
			result.Add(item.ToString().Trim());
			item.Clear();
		}
		else
		{
			item.Append(c);
		}
	}
	result.Add(item.ToString().Trim());
	item.Clear();
	return result.ToArray();
}

Argument[] GetOptArguments(string[] types)
{
	if (types.Length == 0)
	{
		return new Argument[0];
	}
	var result = new List<Argument>(types.Length);
	foreach (string type in types)
	{
		string[] parts = type.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (parts[0] == "context")
		{
			continue;
		}
		Argument arg = new Argument
		{
			OptName = parts[0],
			RawType = parts[1]
		};
		switch (parts[1])
		{
			case "string":
				arg.Type = "string";
				break;
			case "int64":
			case "opts.MemBytes":
			case "opts.MemSwapBytes":
				arg.Type = "Int64";
				break;
			case "bool":
				arg.Type = "bool";
				break;
			case "[]string":
			case "opts.ListOpts":
			case "*opts.UlimitOpt":
				arg.Type = "string";
				arg.IsArray = true;
				break;
			default:
				$"Unknown type: {parts[1]}".Dump();
				break;
		}
		result.Add(arg);
	}
	
	return result.ToArray();
}

enum State
{
	SearchingType,
	CollectingType,
	SearchingFlags,
	CollectingFlags
}

public class Argument
{
	public string RawType;
	public string OptName;
	public string Type;
	public bool IsArray;
	public string Default;
	public string Short;
	public string Long;
	public string Description;
	public bool IsExperimental;
	public string Version;

	public string NameInfo
	{
		get
		{
			string result = $"--{Long}";
			if (!string.IsNullOrEmpty(Short))
			{
				return $"{result}, -{Short}";
			}
			return result;
		}
	}
	public string NetTypeName
	{
		get
		{
			if (IsArray)
			{
				return Type+"[]";
			}
			else
			{
				switch (Type)
				{
					case "bool":
					case "Int64":
						return Type + (!string.IsNullOrEmpty(Default) ? "?": "");
					default:
						return Type;
				}
			}
		}
	}
	public string NetName => Long?.Humanize(LetterCasing.Title).Replace(" ","");
	public  string NetDefault => Default != "[]string{}" ? Default: "";
}

public enum Trust
{
	Signing,
	Verification
}
//void ReadYaml(string fileName)
//{
//	var deserializer = new DeserializerBuilder()
//		.WithNamingConvention(new CamelCaseNamingConvention())
//		.Build();
//
//	var settings = deserializer.Deserialize<Settings>(input);
//}