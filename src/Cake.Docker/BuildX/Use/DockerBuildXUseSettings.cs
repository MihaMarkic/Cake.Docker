namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx use.
    /// </summary>
    public sealed class DockerBuildXUseSettings : AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
        /// <summary>
        /// Set builder as default for current context
        /// </summary>
        public bool Default { get; set; }
        /// <summary>
        /// Builder persists context changes
        /// </summary>
        public bool Global { get; set; }
    }
}