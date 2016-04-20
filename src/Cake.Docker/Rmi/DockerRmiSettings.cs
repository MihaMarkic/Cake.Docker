namespace Cake.Docker.Rmi
{
    /// <summary>
    /// Settings for docker rmi
    /// </summary>
    public sealed class DockerRmiSettings: AutoToolSettings
    {
        /// <summary>
        /// Force removal of the image
        /// </summary>
        public bool Force { get; set; }
        /// <summary>
        /// Do not delete untagged parents
        /// </summary>
        public bool NoPrune { get; set; }
    }
}
