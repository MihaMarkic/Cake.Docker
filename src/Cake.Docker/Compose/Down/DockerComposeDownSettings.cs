namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose down.
    /// </summary>
    public sealed class DockerComposeDownSettings : DockerComposeSettings
    {
        /// <summary>
        /// Remove containers for services not defined in
        ///   the Compose file.
        /// </summary>
        public bool? RemoveOrphans { get; set; }
        /// <summary>
        /// Remove images used by services. "local" remove
        ///   only images that don't have a custom tag
        ///   ("local"|"all")
        /// </summary>
        public string? Rmi { get; set; }
        /// <summary>
        /// Specify a shutdown timeout in seconds
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// Remove named volumes declared in the "volumes"
        ///   section of the Compose file and anonymous
        ///   volumes attached to containers.
        /// </summary>
        public bool? Volumes { get; set; }
    }
}