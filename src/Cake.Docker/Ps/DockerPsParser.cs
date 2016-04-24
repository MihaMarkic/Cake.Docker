using System;
using System.Globalization;

namespace Cake.Docker
{
    public static class DockerPsParser
    {
        public class Indexes
        {
            public int ImageIndex { get; private set; }
            public int CommandIndex{ get; private set; }
            public int CreatedIndex { get; private set; }
            public int StatusIndex { get; private set; }
            public int PortsIndex { get; private set; }
            public int NameIndex { get; private set; }
            public int? SizeIndex { get; private set; }

            public static Indexes CreateFromFirstLine(string line)
            {
                var result = new Indexes();
                result.ImageIndex = line.IndexOf("IMAGE", StringComparison.Ordinal);
                result.CommandIndex = line.IndexOf("COMMAND", result.ImageIndex, StringComparison.Ordinal);
                result.CreatedIndex = line.IndexOf("CREATED", result.CommandIndex, StringComparison.Ordinal);
                result.StatusIndex = line.IndexOf("STATUS", result.CommandIndex, StringComparison.Ordinal);
                result.PortsIndex = line.IndexOf("PORTS", result.StatusIndex, StringComparison.Ordinal);
                result.NameIndex = line.IndexOf("NAMES", result.PortsIndex, StringComparison.Ordinal);
                int sizeIndex = line.IndexOf("SIZE", result.PortsIndex, StringComparison.Ordinal);
                result.SizeIndex = sizeIndex >= 0 ? sizeIndex: (int?)null;
                return result;
            }
        }

        public static DockerPsResult ParseLine(Indexes indexes, string line)
        {
            string statusText = line.Substring(indexes.StatusIndex, indexes.PortsIndex - indexes.StatusIndex).Trim();
            return new DockerPsResult
            {
                Id = line.Substring(0, indexes.ImageIndex).Trim(),
                Image = line.Substring(indexes.ImageIndex, indexes.CommandIndex - indexes.ImageIndex).Trim(),
                Command = line.Substring(indexes.CommandIndex, indexes.CreatedIndex - indexes.CommandIndex).Trim().Trim('"'),
                Created = line.Substring(indexes.CreatedIndex, indexes.StatusIndex - indexes.CreatedIndex).Trim(),
                Status = ParseContainerStatus(statusText),
                ExitCode = ParseExitCode(statusText),
                //Ports = line.Substring(indexes.PortsIndex, indexes.NameIndex - indexes.PortsIndex).Trim(),
                Name = (indexes.SizeIndex.HasValue ? line.Substring(indexes.NameIndex, indexes.SizeIndex.Value - indexes.NameIndex) : line.Substring(indexes.NameIndex)).Trim(),
                Size = indexes.SizeIndex.HasValue ? ParseNormalSize(line.Substring(indexes.SizeIndex.Value)) : (long?)null,
                VirtualSize = indexes.SizeIndex.HasValue ? ParseVirtualSize(line.Substring(indexes.SizeIndex.Value)) : (long?)null,
            };
        }

        public static ContainerStatus ParseContainerStatus(string statusText)
        {
            ContainerStatus result;
            string status = statusText.Split(' ')[0];
            if (!Enum.TryParse(status, out result))
            {
                // yield warning
            }
            return result;
        }

        public static int? ParseExitCode(string statusText)
        {
            string[] parts = statusText.Split(' ');
            if (parts.Length > 1)
            {
                string codeText = parts[1].Substring(1, parts[1].Length - 2);
                int code;
                if (int.TryParse(codeText, out code))
                {
                    return code;
                }
                else
                {
                    // yield warning
                }
            }
            return null;
        }

        public static long ParseNormalSize(string input)
        {
            string[] parts = input.Split('(');
            return ParseSize(parts[0].Trim());
        }

        public static long ParseVirtualSize(string input)
        {
            string[] parts = input.Split('(');
            return ParseSize(parts[1].Replace(')', ' ').Replace("virtual", "").Trim());
        }

        public static long ParseSize(string input)
        {
            string[] parts = input.Split(' ');
            decimal number = decimal.Parse(parts[0], CultureInfo.InvariantCulture);

            int multiply;
            switch (parts[1].ToUpperInvariant())
            {
                case "KB":
                    multiply = 1024;
                    break;
                case "MB":
                    multiply = 1024 * 1024;
                    break;
                case "GB":
                    multiply = 1024 * 1024 * 1024;
                    break;
                default:
                    multiply = 1;
                    break;
            }
            return (long)(number * multiply);
        }
    }
}
