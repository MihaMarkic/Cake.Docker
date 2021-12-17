namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx prune.
    /// </summary>
    public sealed class DockerBuildXPruneSettings : AutoToolSettings
    {
        /// <summary>
        /// Remove all unused images, not just dangling ones
        /// </summary>
        public bool All { get; set; }
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
        /// <summary>
        /// Provide filter values (e.g. 'until=24h')
        /// </summary>
        public bool Filter { get; set; }
        /// <summary>
        /// Do not prompt for confirmation
        /// </summary>
        public bool Force { get; set; }
        /// <summary>
        /// Amount of disk space to keep for cache
        /// </summary>
        public bool KeepStorage { get; set; }
        /// <summary>
        /// Provide a more verbose output
        /// </summary>
        public bool Verbose { get; set; }
    }
}