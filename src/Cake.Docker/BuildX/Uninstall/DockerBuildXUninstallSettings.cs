namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx uninstall.
    /// </summary>
    public class DockerBuildXUninstallSettings : AutoToolSettings 
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
    }
}
