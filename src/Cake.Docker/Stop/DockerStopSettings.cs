namespace Cake.Docker.Rm
{
    /// <summary>
    ///  Settings for docker stop
    /// </summary>
    public sealed class DockerStopSettings: AutoToolSettings
    {
        /// <summary>
        ///  Seconds to wait for stop before killing it.
        /// </summary>
        public int? Time { get; set; }
    }
}
