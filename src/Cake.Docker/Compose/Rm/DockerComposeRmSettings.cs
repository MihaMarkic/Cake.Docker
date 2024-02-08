namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose rm.
    /// </summary>
    public sealed class DockerComposeRmSettings : DockerComposeSettings
    {
        /// <summary>
        /// Don't ask to confirm removal
        /// </summary>
        public bool? Force { get; set; }
        /// <summary>
        /// Stop the containers, if required, before removing
        /// </summary>
        public bool? Stop { get; set; }
        /// <summary>
        /// Remove any anonymous volumes attached to containers
        /// </summary>
        public bool? Volumes { get; set; }
    }
}