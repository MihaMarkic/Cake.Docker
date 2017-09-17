using System.Linq;
using System.Net;
using System.Text;

namespace SettingsGenerator
{
    public static class OutputGenerator
    {
        public static string OutputContent(Argument[] args, string className, string use, string description)
        {
            string TrimDesc(string input) => WebUtility.HtmlEncode(input.Trim(',').Trim('"').Trim('`'));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Cake.Docker");
            sb.AppendLine("{");
            sb.AppendLine("\t/// <summary>");
            sb.AppendLine($"\t/// Settings for docker {TrimDesc(use)}.");
            sb.AppendLine($"\t/// {TrimDesc(description)}");
            sb.AppendLine("\t/// </summary>");
            sb.AppendLine($"\tpublic sealed class Docker{className}Settings : AutoToolSettings");
            sb.AppendLine("\t{");
            foreach (var arg in args.OrderBy(a => a.NetName))
            {
                sb.AppendLine("\t\t/// <summary>");
                sb.AppendLine($"\t\t/// {TrimDesc(arg.NameInfo)}");
                if (!string.IsNullOrEmpty(arg.Default))
                {
                    sb.AppendLine($"\t\t/// default: {arg.NetDefault}");
                }
                if (!string.IsNullOrEmpty(arg.Description))
                {
                    sb.AppendLine($"\t\t/// {TrimDesc(arg.Description)}");
                }
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
    }
}
