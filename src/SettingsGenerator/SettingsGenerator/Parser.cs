using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SettingsGenerator
{
    public static class Parser
    {
        public static (string[] Types, string[] Flags, string Use, string Description, Trust? Trust) 
            CollectTypesAndFlags(string[] lines, Regex typeRegex, Regex cmdRegex, (string Key, string Value)[] consts)
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
                            Console.WriteLine("Type start found");
                            state = State.CollectingType;
                        }
                        else if (cmdRegex.IsMatch(line))
                        {
                            Console.WriteLine("Command header found");
                            isInCommand = true;
                        }
                        else if (line.StartsWith("flags "))
                        {
                            Console.WriteLine("Command start found");
                            state = State.CollectingFlags;
                        }
                        break;
                    case State.CollectingType:
                        if (line == "}" || string.IsNullOrEmpty(line))
                        {
                            Console.WriteLine("Type end found");
                            state = State.SearchingFlags;
                        }
                        else if (!line.StartsWith("//"))
                        {
                            types.Add(line);
                        }
                        break;
                    case State.SearchingFlags:
                        if (line.StartsWith("flags "))
                        {
                            Console.WriteLine("Command start found");
                            state = State.CollectingFlags;
                        }
                        else if (cmdRegex.IsMatch(line))
                        {
                            Console.WriteLine("Command header found");
                            isInCommand = true;
                        }
                        break;
                    case State.CollectingFlags:
                        if (line == "}")
                        {
                            Console.WriteLine("Command end found");
                            return (types.ToArray(), flags.ToArray(), use, description, trust);
                        }
                        else if (line.StartsWith("flags."))
                        {
                            flags.Add(PreprocessFlagLine(consts, line));
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
            Console.WriteLine("Failed parsing");
            return (null, null, use, description, trust);
        }
        static string PreprocessFlagLine((string Key, string Value)[] consts, string content)
        {
            if (consts != null)
            {
                foreach (var cnst in consts)
                {
                    content = content.Replace(cnst.Key, $"\"{cnst.Value}\"");
                }
            }
            return content;
        }
        public static (string[] Types, string[] Flags) CollectTypesAndFlagsFromAdditional(string[] lines, Regex typeRegex, string addFlagsTrigger, (string Key, string Value)[] consts)
        {
            
            var state = State.SearchingType;
            var types = new List<string>();
            var flags = new List<string>();
            int index = 0;
            while (index < lines.Length)
            {
                string line = lines[index];
                index++;
                switch (state)
                {
                    case State.SearchingType:
                        if (typeRegex.IsMatch(line))
                        {
                            Console.WriteLine("Type start found");
                            state = State.CollectingType;
                        }
                        break;
                    case State.CollectingType:
                        if (line == "}" || string.IsNullOrEmpty(line))
                        {
                            Console.WriteLine("Type end found");
                            state = State.SearchingFlags;
                            index = 0;
                        }
                        else if (!line.StartsWith("//"))
                        {
                            types.Add(line);
                        }
                        break;
                    case State.SearchingFlags:
                        if (line.StartsWith(addFlagsTrigger))
                        {
                            Console.WriteLine("Command start found");
                            state = State.SearchingFlagsFirst;
                        }
                        break;
                    case State.SearchingFlagsFirst:
                        if (line.StartsWith("flags."))
                        {
                            Console.WriteLine("First flag found: " + line);
                            state = State.CollectingFlags;
                            flags.Add(PreprocessFlagLine(consts, line));
                        }
                        break;
                    case State.CollectingFlags:
                        if (line == "}")
                        {
                            Console.WriteLine("Command end found");
                            return (types.ToArray(), flags.ToArray());
                        }
                        else if (line.StartsWith("flags."))
                        {
                            flags.Add(PreprocessFlagLine(consts, line));
                        }
                        break;
                    default:
                        throw new Exception($"Invalid state {state}");
                }
            }
            Console.WriteLine("Failed parsing");
            return (null, null);
        }
        static string ExtractText(string content)
        {
            int openQuotationsIndex = content.IndexOf('"');
            //int closeQuotationsIndex = content.IndexOf('"', openQuotationsIndex + 1);
            //	return content.Substring(openQuotationsIndex + 1, closeQuotationsIndex - openQuotationsIndex - 1);
            return content.Substring(openQuotationsIndex + 1).TrimEnd('"');
        }
        public static string[] PartsWithStrings(string content)
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
        public static (string Key, string Value)[] CollectConsts(string[] lines)
        {
            var pairs = new List<(string Key, string Value)>();
            int index = 0;
            bool seeking = true;
            while (index < lines.Length)
            {
                string line = lines[index];
                index++;
                if (seeking)
                {
                    if (line == "const (")
                    {
                        seeking = false;
                    }
                }
                else if (line == ")")
                {
                    return pairs.ToArray();
                }
                else if (!string.IsNullOrEmpty(line))
                {
                    string[] parts = line.Split('=').Select(p => p.Trim().Trim('"')).ToArray();
                    pairs.Add((parts[0], parts[1]));
                }
            }
            Console.WriteLine("Failed parsing consts");
            return null;
        }
    }
}
