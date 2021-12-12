namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker buildx create.
    /// </summary>
    public sealed class DockerBuildXCreateSettings : AutoToolSettings
    {
        /// <summary>
        /// Append a node to builder instead of
        ///   changing it
        /// </summary>
        public bool Append { get; set; }
        /// <summary>
        /// Override the configured builder instance
        /// </summary>
        public string Builder { get; set; }
        /// <summary>
        /// Flags for buildkitd daemon
        /// </summary>
        public string BuildkitdFlags { get; set; }
        /// <summary>
        /// BuildKit config file
        /// </summary>
        public string Config { get; set; }
        /// <summary>
        /// Driver to use (available: [docker
        ///   docker-container kubernetes])
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// Options for the driver
        /// </summary>
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] DriverOpt { get; set; }
        /// <summary>
        /// Remove a node from builder instead of
        ///   changing it
        /// </summary>
        public bool Leave { get; set; }
        /// <summary>
        /// Builder instance name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Create/modify node with given name
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// Fixed platforms for current node
        /// </summary>
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] Platform { get; set; }
        /// <summary>
        /// Set the current builder instance
        /// </summary>
        public bool Use { get; set; }
    }
}