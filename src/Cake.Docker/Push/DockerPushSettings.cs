namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker push.
    /// </summary>
    public sealed class DockerPushSettings : AutoToolSettings
    {
        /// <summary>
        /// Skip image signing
        /// </summary>
        public bool DisableContentTrust { get; set; }
    }
}
