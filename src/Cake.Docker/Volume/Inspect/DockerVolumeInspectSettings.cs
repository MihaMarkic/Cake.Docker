namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker volume inspect.
    /// </summary>
    public sealed class DockerVolumeInspectSettings : AutoToolSettings
    {
        /// <summary>
        /// Format the output using the given Go template
        /// </summary>
        public string? Format { get; set; }
    }
}
