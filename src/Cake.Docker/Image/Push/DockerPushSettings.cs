namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerPushSettings : AutoToolSettings
    {
        /// <summary>
        /// --disable-content-trust 
        /// default: true
        /// Skip image signing
        /// </summary>
        public bool? DisableContentTrust { get; set; }
    }
}

