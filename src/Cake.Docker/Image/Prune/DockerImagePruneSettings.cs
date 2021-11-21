namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume prune.
    /// </summary>
    public sealed class DockerImagePruneSettings: AutoToolSettings
    {
        /// <summary>
        /// Remove all unused images, not just dangling ones
        /// </summary>
        public bool All { get; set; }
        /// <summary>
        /// Provide filter values (e.g. 'until=&lt;timestamp&gt;')
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Do not prompt for confirmation
        /// </summary>
        public bool Force { get; set; }
    }
}
