namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx version.
    /// </summary>
    public sealed class DockerBuildXVersionSettings : AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
    }
}