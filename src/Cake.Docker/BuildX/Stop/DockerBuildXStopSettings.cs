namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx stop.
    /// </summary>
    public sealed class DockerBuildXStopSettings : AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
    }
}