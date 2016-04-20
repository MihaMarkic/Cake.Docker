namespace Cake.Docker.Rm
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerBuildSettings: AutoToolSettings
    {
        /// <summary>
        ///  Name of the Dockerfile (Default is 'PATH/Dockerfile')
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// Name and optionally a tag in the 'name:tag' format
        /// </summary>
        public string[] Tag { get; set; }
        /// <summary>
        /// Suppress the build output and print image ID on success
        /// </summary>
        public bool Quiet { get; set; }
    }
}
