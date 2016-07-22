namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerSwarmLeaveSettings : AutoToolSettings
    {
        /// <summary>
        /// Force leave ignoring warnings.
        /// </summary>
        public bool Force { get; set; }
    }
}
