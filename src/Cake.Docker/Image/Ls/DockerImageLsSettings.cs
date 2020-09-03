namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume ls.
    /// </summary>
    public sealed class DockerImageLsSettings: AutoToolSettings
    {
        /// <summary>
        /// Show all images (default hides intermediate images)
        /// </summary>
        public bool All { get; set; }
        /// <summary>
        /// Show digests
        /// </summary>
        public bool Digests { get; set; }
        /// <summary>
        /// Pretty-print volumes using a Go template
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Provide filter values (e.g. ‘dangling=true’)
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Don't truncate output
        /// </summary>
        public bool NoTrunc { get; set; }
        /// <summary>
        /// Only display volume names
        /// </summary>
        public bool Quiet { get; set; }
    }
}
