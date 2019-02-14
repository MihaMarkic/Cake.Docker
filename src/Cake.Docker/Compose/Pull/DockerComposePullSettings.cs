namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposePullSettings: DockerComposeSettings
    {
        /// <summary>
        /// Pull what it can and ignores images with pull failures.
        /// </summary>
        public bool IgnorePullFailures { get; set; }
        /// <summary>
        /// Disable parallel pulling.
        /// </summary>
        public bool NoParallel { get; set; }
        /// <summary>
        /// Also pull services declared as dependencies
        /// </summary>
        public bool IncludeDeps { get; set; }
        /// <summary>
        /// Pull without printing progress information
        /// </summary>
        public bool Quiet { get; set; }
    }
}
