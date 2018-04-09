namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeUpSettings: DockerComposeSettings
    {
        /// <summary>
        /// Detached mode: Run container in the background, print new container name.
        /// </summary>
        [AutoProperty(Format = "-d", OnlyWhenTrue = true)]
        public bool DetachedMode { get; set; }
        /// <summary>
        /// Produce monochrome output.
        /// </summary>
        public bool NoColor { get; set; }
        /// <summary>
        /// Don't start linked services.
        /// </summary>
        public bool NoDeps { get; set; }
        /// <summary>
        /// Recreate containers even if their configuration
        ///   and image haven't changed.
        ///   Incompatible with --no-recreate.
        /// </summary>
        public bool ForceRecreate { get; set; }
        /// <summary>
        /// If containers already exist, don't recreate them.
        ///   Incompatible with --force-recreate.
        /// </summary>
        public bool NoRecreate { get; set; }
        /// <summary>
        /// Don't build an image, even if it's missing.
        /// </summary>
        public bool NoBuild { get; set; }
        /// <summary>
        /// Build images before starting containers.
        /// </summary>
        public bool Build { get; set; }
        /// <summary>
        /// Stops all containers if any container was stopped.
        ///   Incompatible with -d.
        /// </summary>
        public bool AbortOnContainerExit { get; set; }
        /// <summary>
        /// Use this timeout in seconds for container shutdown
        ///   when attached or when containers are already
        ///   running. (default: 10)
        /// </summary>
        public bool Timeout { get; set; }
        /// <summary>
        /// Remove containers for services not defined in
        ///   the Compose file
        /// </summary>
        public bool RemoveOrphans { get; set; }
        /// <summary>
        /// Return the exit code of the selected service container.
        ///   Implies --abort-on-container-exit.
        /// </summary>
        [AutoProperty(Format = "--exit-code-from {1}")]
        public string ExitCodeFrom { get; set; }
        /// <summary>
        /// SERVICE=NUM        Scale SERVICE to NUM instances. Overrides the `scale`
        ///   setting in the Compose file if present.
        /// </summary>
        public bool Scale { get; set; }
    }
}
