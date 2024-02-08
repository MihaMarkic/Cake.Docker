namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose pull.
    /// </summary>
    public sealed class DockerComposePullSettings : DockerComposeSettings
    {
        /// <summary>
        /// Ignore images that can be built.
        /// </summary>
        public bool? IgnoreBuildable { get; set; }
        /// <summary>
        /// Pull what it can and ignores images with
        ///   pull failures.
        /// </summary>
        public bool? IgnorePullFailures { get; set; }
        /// <summary>
        /// Also pull services declared as dependencies.
        /// </summary>
        public bool? IncludeDeps { get; set; }
        /// <summary>
        /// Apply pull policy ("missing"|"always").
        /// </summary>
        public string? Policy { get; set; }
        /// <summary>
        /// Pull without printing progress information.
        /// </summary>
        public bool? Quiet { get; set; }
    }
}