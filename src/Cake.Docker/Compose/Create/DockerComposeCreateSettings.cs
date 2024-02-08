namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose create.
    /// </summary>
    public sealed class DockerComposeCreateSettings : DockerComposeSettings
    {
        /// <summary>
        /// Build images before starting containers.
        /// </summary>
        public bool? Build { get; set; }
        /// <summary>
        /// Recreate containers even if their configuration
        ///   and image haven't changed.
        /// </summary>
        public bool? ForceRecreate { get; set; }
        /// <summary>
        /// Don't build an image, even if it's policy.
        /// </summary>
        public bool? NoBuild { get; set; }
        /// <summary>
        /// If containers already exist, don't recreate
        ///   them. Incompatible with --force-recreate.
        /// </summary>
        public bool? NoRecreate { get; set; }
        /// <summary>
        /// Pull image before running
        ///   ("always"|"missing"|"never"|"build") (default
        ///   "policy")
        /// </summary>
        public string? Pull { get; set; }
        /// <summary>
        /// Remove containers for services not defined in
        ///   the Compose file.
        /// </summary>
        public bool? RemoveOrphans { get; set; }
        /// <summary>
        /// Scale SERVICE to NUM instances. Overrides the
        ///   scale setting in the Compose file if present.
        /// </summary>
        public bool? Scale { get; set; }
    }
}