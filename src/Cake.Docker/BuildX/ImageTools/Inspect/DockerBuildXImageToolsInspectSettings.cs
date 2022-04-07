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
        /// Format the output using the given Go template
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Show original, unformatted JSON manifest
        /// </summary>
        public bool Raw { get; set; }
    }
}