namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker-compose ps.
    /// </summary>
    public sealed class DockerComposePsSettings : DockerComposeSettings
    {
        /// <summary>
        /// --filter
        /// Filter services by a property.
        /// </summary>
        [AutoProperty(Format = "--filter {1}")]
        public string[] Filters { get; set; }

        /// <summary>
        /// --quiet, -q
        /// Only display IDs
        /// </summary>
        [AutoProperty(Format = "--quiet", OnlyWhenTrue = true)]
        public bool? Quiet { get; set; }
    }
}
