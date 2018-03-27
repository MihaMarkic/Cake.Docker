using Humanizer;
using System.Diagnostics;

namespace SettingsGenerator
{
    [DebuggerDisplay("{OptName} {RawType,nq}")]
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
                    return Type + "[]";
                }
                else
                {
                    switch (Type)
                    {
                        case "bool":
                        case "Int64":
                        case "UInt64":
                        case "UInt16":
                        case "int":
                            return Type + "?";
                            //return Type + (!string.IsNullOrEmpty(Default) ? "?" : "");
                        default:
                            return Type;
                    }
                }
            }
        }
        public string NetName => Long.Humanize(LetterCasing.Title).Replace(" ", "");
        public string NetDefault => Default != "[]string{}" ? Default : "";
    }
}
