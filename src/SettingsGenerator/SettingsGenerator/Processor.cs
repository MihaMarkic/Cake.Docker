using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SettingsGenerator
{
    public class Processor
    {
        readonly string root;
        public Processor(string root)
        {
            this.root = root;
        }
        public async Task ProcessCommandAsync(string path, string command, string originalCommandName,
            string additionalOptionsUrl, string additionalOptionsTypeName)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://raw.githubusercontent.com/docker/cli/master/cli/command/") };

            string[] parts = path.Split(new[] { System.IO.Path.DirectorySeparatorChar });
            string url = string.Join("/", parts).ToLower();
            string source = await httpClient.GetStringAsync($"{url}.go");
            var args = ImmutableArray<Argument>.Empty;
            if (!string.IsNullOrEmpty(additionalOptionsUrl))
            {
                string additionalUrl = string.Join("/", parts.Take(parts.Length-1)).ToLower();
                if (additionalUrl.Length > 0 )
                {
                    additionalUrl += "/";
                }
                additionalUrl += $"{additionalOptionsUrl}.go";
                string additionalSource = await httpClient.GetStringAsync(additionalUrl);
                args = GetAdditionalArguments(additionalSource, additionalOptionsTypeName);
            }
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

            //bool isMatch = cmdRegex.IsMatch("func NewCopyCommand(dockerCli *command.DockerCli) *cobra.Command {");
            var typesAndFlags = Parser.CollectTypesAndFlags(lines, typeRegex, cmdRegex);
            args = args.AddRange(GetOptArguments(typesAndFlags.Types));
            if (typesAndFlags.Trust.HasValue)
            {
                args = args.Add(new Argument
                {
                    RawType = "bool",
                    OptName = "disableContentTrust",
                    Long = "disable-content-trust",
                    Type = "bool",
                    Default = "true",
                    Description = "Skip image " + (typesAndFlags.Trust.Value == Trust.Verification ? "verification" : "signing")
                });
            }
            FillArgumentsWithFlags(args, typesAndFlags.Flags);
            var validArgs = args.Where(a => !string.IsNullOrEmpty(a.Long)).ToArray();
            //validArgs.Dump();
            string output = OutputGenerator.OutputContent(validArgs, originalCommandName, typesAndFlags.Use, typesAndFlags.Description);
            string fileName = Path.Combine(root, path, $"Docker{originalCommandName}Settings.cs");
            File.WriteAllText(fileName, output);
            //	output.Dump();
        }

        ImmutableArray<Argument> GetAdditionalArguments(string source, string additionalOptionsTypeName)
        {
            var lines = source.Split('\n').Select(l => l.Trim()).ToArray();

            string pattern = $"^\\s*type\\s+{additionalOptionsTypeName.ToLower()}Options\\s+struct\\s*{{\\s*$";
            var typeRegex = new Regex(
              pattern,
                    RegexOptions.IgnoreCase
                    | RegexOptions.Multiline
                    | RegexOptions.CultureInvariant
                    | RegexOptions.IgnorePatternWhitespace
                    | RegexOptions.Compiled
                    );
            bool isMatch = typeRegex.IsMatch("type containerOptions struct {");
            var typesAndFlags = Parser.CollectTypesAndFlagsFromAdditional(lines, typeRegex);
            var args = GetOptArguments(typesAndFlags.Types).ToImmutableArray();
            FillArgumentsWithFlags(args, typesAndFlags.Flags);

            return args;
        }

        void FillArgumentsWithFlags(ImmutableArray<Argument> arguments, string[] flags)
        {
            var dict = arguments.ToDictionary(a => a.OptName, a => a);
            var data = new List<(string FullName, string Type, string Content)>();
            // hidden keywords has to be removed otherwise duplication occurs
            var hiddenKeywords = ImmutableHashSet<string>.Empty;
            var annotations = new List<(string FullName, string Content)>();
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
                            int openQuotationsIndex = content.IndexOf('"');
                            int closeQuotationsIndex = content.IndexOf('"', openQuotationsIndex + 1);
                            string fullName = content.Substring(openQuotationsIndex + 1, closeQuotationsIndex - openQuotationsIndex - 1);
                            int firstCommaIndex = content.IndexOf(',', closeQuotationsIndex + 1);
                            annotations.Add((fullName, content.Substring(firstCommaIndex + 1).Trim()));
                        }
                        break;
                    case "MarkHidden":
                        hiddenKeywords = hiddenKeywords.Add(content.Replace("\"", ""));
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
                    case "DurationVar":
                    case "IntVar":
                    case "IntVarP":
                    case "Uint64Var":
                        {
                            dotIndex = content.IndexOf('.');
                            int firstCommaIndex = content.IndexOf(',');
                            string fullName = content.Substring(dotIndex + 1, firstCommaIndex - dotIndex - 1);
                            //var arg = dict[fullName];
                            //PopulateArgument(arg, type, content.Substring(firstCommaIndex + 1).Trim());
                            data.Add((fullName, type, content.Substring(firstCommaIndex + 1).Trim()));
                        }
                        break;
                }
            }
            foreach (var tuple in data)
            {
                var arg = dict[tuple.FullName];
                PopulateArgument(arg, tuple.Type, tuple.Content, hiddenKeywords);
            }
            foreach (var tuple in annotations)
            {
                var arg = arguments.Single(a => a.Long == tuple.FullName);
                Annotator.AnnotateArgument(arg, tuple.Content);
            }
        }

        void PopulateArgument(Argument args, string type, string content, ImmutableHashSet<string> hiddenKeywords)
        {
            string[] parts = Parser.PartsWithStrings(content);
            args.Long = parts[0];
            if (hiddenKeywords.Contains(args.Long))
            {
                return;
            }
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
                case "IntVarP":
                case "BoolVarP":
                    args.Short = parts[1];
                    args.Default = parts[2];
                    args.Description = parts[3];
                    break;
                case "Int64Var":
                case "StringVar":
                case "BoolVar":
                case "StringSliceVar":
                case "DurationVar":
                case "IntVar":
                case "Uint16Var":
                    args.Default = parts[1];
                    args.Description = parts[2];
                    break;
                case "SetAnnotation":
                    break;
            }
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
                switch (parts[1].TrimStart('*'))
                {
                    case "string":
                    case "time.Duration":
                        arg.Type = "string";
                        break;
                    case "int64":
                        arg.Type = "Int64";
                        break;
                    case "uint64":
                    case "opts.MemBytes":
                    case "opts.MemSwapBytes":
                    case "opts.WeightdeviceOpt":
                    case "opts.ThrottledeviceOpt":
                    case "opts.NanoCPUs":
                        arg.Type = "UInt64";
                        break;
                    case "bool":
                        arg.Type = "bool";
                        break;
                    case "[]string":
                    case "opts.ListOpts":
                    case "opts.UlimitOpt":
                    case "opts.MountOpt":
                    case "opts.MapOpts":
                        arg.Type = "string";
                        arg.IsArray = true;
                        break;
                    case "int":
                        arg.Type = "int";
                        break;
                    default:
                        Console.WriteLine($"Unknown type: {parts[1]}");
                        break;
                }
                result.Add(arg);
            }

            return result.ToArray();
        }
    }
}
