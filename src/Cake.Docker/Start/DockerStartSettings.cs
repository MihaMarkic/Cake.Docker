namespace Cake.Docker
{
    /// <summary>
    ///  Settings for docker Start
    /// </summary>
    public sealed class DockerStartSettings: AutoToolSettings
    {
        /// <summary>
        ///  Seconds to wait for stop before killing it.
        /// </summary>
        public int? Time { get; set; }
    }
}
