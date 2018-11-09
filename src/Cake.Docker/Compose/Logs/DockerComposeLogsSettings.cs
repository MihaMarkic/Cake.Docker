namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposeLogsSettings: DockerComposeSettings
    {
        /// <summary>
        /// Produce monochrome output.
        /// </summary>
        public bool NoColor { get; set; }
        /// <summary>
		/// --follow, -f
		/// default: false
		/// Follow log output
		/// </summary>
		public bool? Follow { get; set; }
        /// <summary>
		/// -t, --timestamps
		/// default: false
		/// Show timestamps
		/// </summary>
		public bool? Timestamps { get; set; }
        /// <summary>
        /// --tail="all"
        /// Number of lines to show from the end of the logs for each container.
        /// </summary>
        public string Tail { get; set; }
    }
}
