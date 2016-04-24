namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerPsSettings: AutoToolSettings
    {
        /// <summary>
        /// Show all containers (default shows just running)
        /// </summary>
        public bool All { get; set; }
        /// <summary>
        /// Show the latest created container (includes all states)
        /// </summary>
        public bool Latest { get; set; }
        /// <summary>
        /// Don't truncate output
        /// </summary>
        public bool NoTrunc { get; set; }
        /// <summary>
        /// Display total file sizes
        /// </summary>
        public bool Size { get; set; }
    }
}
