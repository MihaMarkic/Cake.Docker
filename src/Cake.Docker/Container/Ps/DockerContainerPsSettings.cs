using System;

namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker ps [OPTIONS]
    /// List containers
    /// </summary>
    public sealed partial class DockerContainerPsSettings : AutoToolSettings
	{
        /// <summary>
        /// --all , -a
        /// Show all containers (default shows just running)
        /// </summary>
        public bool? All { get; set; }
        /// <summary>
        /// --filter , -f
        /// Filter output based on conditions provided
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// --format
        /// Pretty-print containers using a Go template
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// --last , -n
        /// Show n last created containers (includes all states)
        /// </summary>
        public int Last { get; set; }
        /// <summary>
        /// --latest , -l
        /// Show the latest created container (includes all states)
        /// </summary>
        public bool? Latest { get; set; }
        /// <summary>
        /// --no-trunc
        /// Don’t truncate output
        /// </summary>
        public bool? NoTrunc { get; set; }
        /// <summary>
        /// --quiet , -q
        /// Only display numeric IDs
        /// </summary>
        public bool? Quiet { get; set; }
        /// <summary>
        /// --size , -s
        /// Display total file sizes
        /// </summary>
        public bool? Size { get; set; }
    }
}