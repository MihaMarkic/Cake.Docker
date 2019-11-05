namespace Cake.Docker
{
    /// <summary>
    /// Settings for `docker manifest create MANIFEST_LIST MANIFEST [MANIFEST...]`
    /// Create a local manifest list for annotating and pushing to a registry
    /// </summary>
    [Experimental]
    public sealed class DockerManifestCreateSettings : AutoToolSettings
    {
        /// <summary>
        /// --amend , -a
        /// Amend an existing manifest list
        /// </summary>
        public bool? Amend { get; set; }
        /// <summary>
        /// --insecure
        /// Allow communication with an insecure registry
        /// </summary>
        public bool? Insecure { get; set; }
    }
}
