namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose scale.
    /// </summary>
    public sealed class DockerComposeScaleSettings : DockerComposeSettings
    {
        /// <summary>
        /// Don't start linked services.
        /// </summary>
        public bool? NoDeps { get; set; }
    }
}