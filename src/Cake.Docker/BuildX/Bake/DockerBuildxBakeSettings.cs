namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx bake.
    /// </summary>
    public sealed class DockerBuildXBakeSettings : AutoToolSettings
    {
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string? Builder { get; set; }
        /// <summary>
        /// Build definition file
        /// </summary>
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] File { get; set; }
        /// <summary>
        /// Shorthand for "--set=*.output=type=docker"
        /// </summary>
        public bool Load { get; set; }
        /// <summary>
        /// Write build result metadata to the file
        /// </summary>
        public string? MetadataFile { get; set; }
        /// <summary>
        /// Do not use cache when building the image
        /// </summary>
        public bool NoCache { get; set; }
        /// <summary>
        /// Print the options without building
        /// </summary>
        public bool Print { get; set; }
        /// <summary>
        /// Set type of progress output ("auto", "plain", "tty"). Use plain to show container output (default "auto")
        /// </summary>
        public string? Progress { get; set; }
        /// <summary>
        /// Always attempt to pull all referenced images
        /// </summary>
        public bool Pull { get; set; }
        /// <summary>
        /// Shorthand for "--set=*.output=type=registry"
        /// </summary>
        public bool Push { get; set; }
        /// <summary>
        /// Override target value (e.g., "targetpattern.key=value")
        /// </summary>
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] Set { get; set; }
    }
}