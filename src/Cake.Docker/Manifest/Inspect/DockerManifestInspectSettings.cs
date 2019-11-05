namespace Cake.Docker
{
    /// <summary>
    /// Settings for `docker manifest inspect [OPTIONS] [MANIFEST_LIST] MANIFEST`
    /// Display an image manifest, or manifest list
    /// </summary>
    [Experimental]
    public sealed class DockerManifestInspectSettings : AutoToolSettings
    {
        /// <summary>
        /// --insecure
        /// Allow communication with an insecure registry
        /// </summary>
        public bool? Insecure { get; set; }
        /// <summary>
        /// --verbose , -v 	
        /// Output additional info including layers and platform
        /// </summary>
        public bool? Verbose { get; set; }
    }
}
