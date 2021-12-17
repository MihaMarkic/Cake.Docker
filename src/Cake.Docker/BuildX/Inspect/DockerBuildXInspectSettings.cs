namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx inspect.
    /// </summary>
    public sealed class DockerBuildXInspectSettings : AutoToolSettings
    {
        /// <summary>
        /// Ensure builder has booted before inspecting
        /// </summary>
        public bool Bootstrap { get; set; }
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
    }
}