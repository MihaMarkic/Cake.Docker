namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose restart.
    /// </summary>
    public sealed class DockerComposeRestartSettings : DockerComposeSettings
    {
        /// <summary>
        /// Don't restart dependent services.
        /// </summary>
        public bool? NoDeps { get; set; }
        /// <summary>
        /// Specify a shutdown timeout in seconds
        /// </summary>
        public int? Timeout { get; set; }
    }
}