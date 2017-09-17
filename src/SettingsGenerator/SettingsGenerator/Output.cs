using System.Linq;
using System.Text;

namespace SettingsGenerator
{
    public static class OutputGenerator
    {
        public static string OutputContent(Argument[] args, string className, string use, string description)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Cake.Docker");
            sb.AppendLine("{");
            sb.AppendLine("\t/// <summary>");
            sb.AppendLine($"\t/// Settings for docker {use.TrimEnd(',').TrimEnd('"')}.");
            sb.AppendLine($"\t/// {description.TrimEnd(',').TrimEnd('"')}");
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
    }
}
