namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx rm.
    /// </summary>
    public sealed class DockerBuildXRmSettings : AutoToolSettings
    {
        /// <summary>
        /// Remove all inactive builders
        /// </summary>
        public bool AllInactive { get; set; }
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
        /// <summary>
        /// Do not prompt for confirmation
        /// </summary>
        public bool Force { get; set; }
        /// <summary>
        /// Keep the buildkitd daemon running
        /// </summary>
        public bool KeepDaemon { get; set; }
        /// <summary>
        /// Keep BuildKit state
        /// </summary>
        public bool KeepState { get; set; }
    }
}