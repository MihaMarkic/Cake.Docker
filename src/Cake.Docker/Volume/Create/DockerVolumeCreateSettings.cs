namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume create.
    /// </summary>
    public sealed class DockerVolumeCreateSettings: AutoToolSettings
    {
        /// <summary>
        /// Specify volume driver name.
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// Set metadata for a volume.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Specify volume name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Set driver specific options
        /// </summary>
        public string[] Opt { get; set; }
    }
}
