namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeKillSettings: AutoToolSettings
    {
        /// <summary>
        ///  SIGNAL to send to the container. Default signal is SIGKILL.
        /// </summary>
        [AutoProperty(Format = "-s {1}")]
        public string Signal { get; set; }
        
    }
}
