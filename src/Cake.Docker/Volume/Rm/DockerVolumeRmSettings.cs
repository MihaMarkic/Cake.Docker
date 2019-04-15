namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume rm.
    /// </summary>
    public sealed class DockerVolumeRmSettings : AutoToolSettings
    {
        /// <summary>
        /// Force the removal of one or more volumes
        /// </summary>
        public bool Force { get; set; }
    }
}
