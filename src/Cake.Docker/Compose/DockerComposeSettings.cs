namespace Cake.Docker
{
    /// <summary>
    /// Generic docker-compose settings.
    /// </summary>
    public class DockerComposeSettings: AutoToolSettings
    {
        /// <summary>
        /// Configuration files.
        /// </summary>
        [AutoProperty(Format ="-f {1}", PreCommand =true)]
        public string[] Files { get; set; }
        /// <summary>
        /// Specify an alternate project name (default: directory name)
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public bool ProjectName { get; set; }
        /// <summary>
        /// Show more output
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public bool Verbose { get; set; }
        /// <summary>
        /// Print version and exit
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public bool Version { get; set; }
        /// <summary>
        /// Daemon socket to connect to
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public string Host { get; set; }
        /// <summary>
        /// Use TLS; implied by --tlsverify
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public bool Tls { get; set; }
        /// <summary>
        /// Trust certs signed only by this CA
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public string Tlscacert { get; set; }
        /// <summary>
        /// Path to TLS certificate file
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public string Tlscert { get; set; }
        /// <summary>
        /// Path to TLS key file
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public string Tlskey { get; set; }
        /// <summary>
        /// Use TLS and verify the remote
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public bool Tlsverify { get; set; }
        /// <summary>
        /// Don't check the daemon's hostname against the name specified
        ///   in the client certificate (for example if your docker host
        ///   is an IP address)
        /// </summary>
        [AutoProperty(PreCommand = true)]
        public bool SkipHostnameCheck { get; set; }
}
}
