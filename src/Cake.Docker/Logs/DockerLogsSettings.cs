namespace Cake.Docker
{
    /// <summary>
    ///  Settings for docker Logs
    /// </summary>
    public sealed class DockerLogsSettings: AutoToolSettings
    {
        /// <summary>
        ///  Seconds to wait for stop before killing it.
        /// </summary>
        public int? Time { get; set; }
    }
}
