namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx install.
    /// </summary>
    public class DockerBuildXInstallSettings : AutoToolSettings 
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
    }
}
