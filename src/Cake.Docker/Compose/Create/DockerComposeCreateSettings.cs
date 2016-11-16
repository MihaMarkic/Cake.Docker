namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeCreateSettings: DockerComposeSettings
    {
        /// <summary>
        /// Recreate containers even if their configuration and image haven't changed. Incompatible with --no-recreate.
        /// </summary>
        public bool ForceRecreate { get; set; }
        /// <summary>
        /// If containers already exist, don't recreate them. Incompatible with --force-recreate.
        /// </summary>
        public bool NoRecreate { get; set; }
        /// <summary>
        /// Don't build an image, even if it's missing.
        /// </summary>
        public bool NoBuild { get; set; }
        /// <summary>
        /// Build images before creating containers.
        /// </summary>
        public bool Build { get; set; }
    }
}
