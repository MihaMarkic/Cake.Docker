namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker push.
    /// </summary>
    public sealed class DockerPullSettings : AutoToolSettings
    {
        /// <summary>
        /// Download all tagged images in the repository
        /// </summary>
        public bool AllTags { get; set; }
        /// <summary>
        /// Skip image verification (default true)
        /// </summary>
        public bool DisableContentTrust { get; set; }
    }
}
