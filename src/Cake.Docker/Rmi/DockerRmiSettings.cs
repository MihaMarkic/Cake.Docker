namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerRmiSettings : AutoToolSettings
    {
        /// <summary>
        /// --force, -f 
        /// default: false
        /// Force removal of the image
        /// </summary>
        public bool? Force { get; set; }
        /// <summary>
        /// --no-prune 
        /// default: false
        /// Do not delete untagged parents
        /// </summary>
        public bool? NoPrune { get; set; }
    }
}

