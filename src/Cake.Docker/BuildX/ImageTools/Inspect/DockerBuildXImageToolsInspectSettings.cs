namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx imagetools inspect.
    /// </summary>
    public sealed class DockerBuildXImageToolsInspectSettings : AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
        /// <summary>
        /// Show original JSON manifest
        /// </summary>
        public bool Raw { get; set; }
    }
}