namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker-compose port.
    /// </summary>
    public sealed class DockerComposePortSettings: DockerComposeSettings
    {
        /// <summary>
        /// --index
        /// default: 1
        /// Index of the container if there are multiple.
        /// </summary>
        public int? Index { get; set; }
        /// <summary>
        /// --protocol
        /// default: tcp
        /// The protocol.
        /// </summary>
        public string? Protocol { get; set; }
    }
}
