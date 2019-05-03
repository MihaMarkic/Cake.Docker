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
        [AutoProperty(Format = "--index={1}")]
        public int? Index { get; set; }
        /// <summary>
        /// --protocol
        /// default: tcp
        /// The protocol.
        /// </summary>
        [AutoProperty(Format = "--protocol={1}")]
        public string Protocol { get; set; }
    }
}
