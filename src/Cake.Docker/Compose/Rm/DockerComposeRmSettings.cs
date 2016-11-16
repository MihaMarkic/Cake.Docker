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
        /// Also remove one-off containers created by
        ///   docker-compose run
        /// </summary>
        public bool All { get; set; }
    }
}
