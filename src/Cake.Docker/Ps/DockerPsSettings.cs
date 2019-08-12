namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker ps [OPTIONS].
    /// </summary>
    public sealed class DockerPsSettings : AutoToolSettings
    {
        /// <summary>
        /// --all, -a 
        /// default: false
        /// Show all containers (default shows just running)
        /// </summary>
        public bool? All { get; set; }
        /// <summary>
        /// --filter, -f 
        /// Filter output based on conditions provided
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// --format 
        /// Pretty-print containers using a Go template
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// --last, -n 
        /// default: -1
        /// Show n last created containers (includes all states)
        /// </summary>
        public int? Last { get; set; }
        /// <summary>
        /// --latest, -l 
        /// default: false
        /// Show the latest created container (includes all states)
        /// </summary>
        public bool? Latest { get; set; }
        /// <summary>
        /// --no-trunc 
        /// default: false
        /// Don’t truncate output
        /// </summary>
        public bool? NoTrunc { get; set; }
        /// <summary>
        /// --quiet, -q 
        /// default: false
        /// Only display numeric IDs
        /// </summary>
        public bool? Quiet { get; set; }
        /// <summary>
        /// --size, -s 
        /// default: false
        /// Display total file sizes
        /// </summary>
        public bool? Size { get; set; }
    }
}