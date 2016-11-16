namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeDownSettings: AutoToolSettings
    {
        /// <summary>
        /// Remove images. Type must be one of:
        ///   'all': Remove all images used by any service.
        ///   'local': Remove only images that don't have a custom tag
        ///   set by the `image` field.
        /// </summary>
        public bool Rmi { get; set; }
        /// <summary>
        /// Remove named volumes declared in the `volumes` section
        ///   of the Compose file and anonymous volumes
        ///   attached to containers.
        /// </summary>
        public bool Volumes { get; set; }
        /// <summary>
        /// Remove containers for services not defined in the
        ///   Compose file
        /// </summary>
        public bool RemoveOrphans { get; set; }
    }
}
