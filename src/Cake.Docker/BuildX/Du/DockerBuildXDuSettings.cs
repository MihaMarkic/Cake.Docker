namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx du.
    /// </summary>
    public sealed class DockerBuildXDuSettings : AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
        /// <summary>
        /// Provide filter values
        /// </summary>
        public bool Filter { get; set; }
        /// <summary>
        /// Provide a more verbose output
        /// </summary>
        public bool Verbose { get; set; }
    }
}