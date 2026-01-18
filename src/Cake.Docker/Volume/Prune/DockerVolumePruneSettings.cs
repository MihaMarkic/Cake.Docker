namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume prune.
    /// </summary>
    public sealed class DockerVolumePruneSettings : AutoToolSettings
    {
        /// <summary>
        /// Provide filter values (e.g. ‘label=’)
        /// </summary>
        public string? Filter { get; set; }
        /// <summary>
        /// Do not prompt for confirmation
        /// </summary>
        public bool Force { get; set; }
    }
}
