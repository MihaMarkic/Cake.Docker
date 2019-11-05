namespace Cake.Docker
{
    /// <summary>
    /// Settings for `docker manifest push [OPTIONS] MANIFEST_LIST`
    /// Push a manifest list to a repository
    /// </summary>
    [Experimental]
    public sealed class DockerManifestPushSettings : AutoToolSettings
    {
        /// <summary>
        /// --insecure
        /// Allow communication with an insecure registry
        /// </summary>
        public bool? Insecure { get; set; }
        /// <summary>
        /// --purge , -p
        /// Remove the local manifest list after push
        /// </summary>
        public bool? Purge { get; set; }
    }
}
