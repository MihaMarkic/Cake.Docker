namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx rm.
    /// </summary>
    public sealed class DockerBuildXRmSettings : AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
        /// <summary>
        /// Keep BuildKit state
        /// </summary>
        public bool KeepState { get; set; }
    }
}