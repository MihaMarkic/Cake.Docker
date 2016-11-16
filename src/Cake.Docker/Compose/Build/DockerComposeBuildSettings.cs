namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeBuildSettings: AutoToolSettings
    {
        /// <summary>
        /// Always remove intermediate containers.
        /// </summary>
        public bool ForceRm { get; set; }
        /// <summary>
        /// Do not use cache when building the image.
        /// </summary>
        public bool NoCache { get; set; }
        /// <summary>
        /// Always attempt to pull a newer version of the image.
        /// </summary>
        public bool Pull { get; set; }
    }
}
