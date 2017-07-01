namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerStopSettings : AutoToolSettings
    {
        /// <summary>
        /// --time, -t 
        /// default: 10
        /// Seconds to wait for stop before killing it
        /// </summary>
        public int? Time { get; set; }
    }
}

