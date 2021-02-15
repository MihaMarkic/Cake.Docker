namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker publish.
    /// </summary>
    public sealed class DockerComposePushSettings: DockerComposeSettings
    {
        /// <summary>
        /// Push what it can and ignores images with push failures.
        /// </summary>
        public bool IgnorePushFailures { get; set; }
    }
}
