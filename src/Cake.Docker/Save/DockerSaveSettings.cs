namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerSaveSettings : AutoToolSettings
    {
        /// <summary>
        /// --output, -o 
        /// Write to a file, instead of STDOUT
        /// </summary>
        public string Output { get; set; }
    }
}

