namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose.
    /// </summary>
    public class DockerComposeSettings : AutoToolSettings
    {
        /// <summary>
        /// Control when to print ANSI control
        ///   characters ("never"|"always"|"auto")
        ///   (default "auto")
        /// </summary>
        public string Ansi { get; set; }
        /// <summary>
        /// Run compose in backward compatibility mode
        /// </summary>
        public bool Compatibility { get; set; }
        /// <summary>
        /// Execute command in dry run mode
        /// </summary>
        public bool DryRun { get; set; }
        /// <summary>
        /// Specify an alternate environment file.
        /// </summary>
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] EnvFile { get; set; }
        /// <summary>
        /// Compose configuration files
        /// </summary>
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] File { get; set; }
        /// <summary>
        /// Control max parallelism, -1 for
        ///   unlimited (default -1)
        /// </summary>
        public int? Parallel { get; set; }
        /// <summary>
        /// Specify a profile to enable
        /// </summary>
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] Profile { get; set; }
        /// <summary>
        /// Set type of progress output (auto,
        ///   tty, plain, quiet) (default "auto")
        /// </summary>
        public string Progress { get; set; }
        /// <summary>
        /// Specify an alternate working directory
        ///   (default: the path of the, first
        ///   specified, Compose file)
        /// </summary>
        public string ProjectDirectory { get; set; }
        /// <summary>
        /// Project name
        /// </summary>
        public string ProjectName { get; set; }
    }
}