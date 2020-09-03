namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume ls.
    /// </summary>
    public sealed class DockerContainerLsSettings: AutoToolSettings
    {
        /// <summary>
        /// Show all images (default hides intermediate images)
        /// </summary>
        public bool All { get; set; }
        /// <summary>
        /// Provide filter values (e.g. ‘dangling=true’)
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Pretty-print volumes using a Go template
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Show n last created containers (includes all states) (default -1)
        /// </summary>
        public int Last { get; set; }
        /// <summary>
        /// Show the latest created container (includes all states)
        /// </summary>
        public bool Latest { get; set; }
        /// <summary>
        /// Don't truncate output
        /// </summary>
        public bool NoTrunc { get; set; }
        /// <summary>
        /// Only display volume names
        /// </summary>
        public bool Quiet { get; set; }
        /// <summary>
        /// Display total file sizes
        /// </summary>
        public bool Size { get; set; }
    }
}
