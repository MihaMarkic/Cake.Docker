namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker-compose exec [options] [-e KEY=VAL...] SERVICE COMMAND [ARGS...]
    /// </summary>
    public sealed class DockerComposeExecSettings : DockerComposeSettings
    {
        /// <summary>
        /// -d, --detach
        /// Detached mode: Run command in the background.
        /// </summary>
        public bool? Detach { get; set; }

        /// <summary>
        /// --privileged
        /// Give extended privileges to the process.
        /// </summary>
        public bool? Privileged { get; set; }

        /// <summary>
        /// -u, --user USER
        /// Run the command as this user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// --index=index
        /// index of the container if there are multiple
        /// instances of a service
        /// default: 1
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// --env, -e
        /// Set environment variables (can be used multiple times,
        /// </summary>
        /// <remarks>
        /// Version: 1.25
        /// </remarks>
        public string[] Env { get; set; }

        /// <summary>
        /// --workdir, -w
        /// Path to workdir directory for this command.
        /// </summary>
        public string Workdir { get; set; }

        /// <summary>
        /// -T
        ///  Disable pseudo-tty allocation. By default `docker-compose exec`
        /// allocates a TTY.
        /// </summary>
        [AutoProperty(Format = "-T", OnlyWhenTrue = true)]
        public bool? DisablePseudoTTYAllocation { get; set; }
    }
}
