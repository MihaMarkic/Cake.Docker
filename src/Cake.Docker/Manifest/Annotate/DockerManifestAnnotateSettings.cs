namespace Cake.Docker
{
    /// <summary>
    /// Settings for `docker manifest annotate [OPTIONS] MANIFEST_LIST MANIFEST`
    /// Add additional information to a local image manifest
    /// </summary>
    [Experimental]
    public sealed class DockerManifestAnnotateSettings : AutoToolSettings
    {
        /// <summary>
        /// --arch
        /// Set architecture
        /// </summary>
        public string Arch { get; set; }
        /// <summary>
        /// --os
        /// Set operating system
        /// </summary>
        public string Os { get; set; }
        /// <summary>
        /// --os-features
        /// Set operating system feature
        /// </summary>
        public string OsFeatures { get; set; }
        /// <summary>
        /// --variant
        /// Set architecture variant
        /// </summary>
        public string Variant { get; set; }
    }
}
