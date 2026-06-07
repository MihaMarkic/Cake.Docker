namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume ls.
    /// </summary>
    public sealed class DockerVolumeLsSettings : AutoToolSettings
    {
        /// <summary>
        /// Pretty-print volumes using a Go template
        /// </summary>
        public string? Format { get; set; }
        /// <summary>
        /// Provide filter values (e.g. ‘dangling=true’)
        /// </summary>
        public string? Filter { get; set; }
        /// <summary>
        /// Only display volume names
        /// </summary>
        public bool Quiet { get; set; }
    }
}
