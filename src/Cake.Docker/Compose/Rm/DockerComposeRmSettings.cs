namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeRmSettings: DockerComposeSettings
    {
        /// <summary>
        /// Don't ask to confirm removal
        /// </summary>
        public bool Force { get; set; }
        /// <summary>
        /// Remove any anonymous volumes attached to containers
        /// </summary>
        [AutoProperty(Format = "-v", OnlyWhenTrue = true)]
        public bool Volumes { get; set; }
        /// <summary>
        /// Stop the containers, if required, before removing
        /// </summary>
        public bool Stop { get; set; }
    }
}
