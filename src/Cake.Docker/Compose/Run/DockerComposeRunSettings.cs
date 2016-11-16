namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeRunSettings : AutoToolSettings
    {
        /// <summary>
        /// Detached mode: Run container in the background, print new container name.
        /// </summary>
        [AutoProperty(Format ="-d", OnlyWhenTrue = true)]
        public bool DetachedMode { get; set; }
        /// <summary>
        /// Assign a name to the container
        /// </summary>
        public bool Name { get; set; }
        /// <summary>
        /// Override the entrypoint of the image.
        /// </summary>
        public bool Entrypoint { get; set; }
        /// <summary>
        /// Set an environment variable(can be used multiple times)
        /// </summary>
        [AutoProperty(Format = "-e {1}")]
        public string[] Environment { get; set; }
        /// <summary>
        /// Run as specified username or uid
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Don't start linked services.
        /// </summary>
        public bool NoDeps { get; set; }
        /// <summary>
        /// Remove container after run. Ignored in detached mode.
        /// </summary>
        public bool Rm { get; set; }
        /// <summary>
        /// Publish a container's port(s) to the host
        /// </summary>
        public string[] Publish { get; set; }
        /// <summary>
        /// Run command with the service's ports enabled and mapped to the host.
        /// </summary>
        public bool ServicePorts { get; set; }
    }
}
