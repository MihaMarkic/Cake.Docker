namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx ls.
    /// </summary>
    public class DockerBuildXLsSettings: AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
    }
}
