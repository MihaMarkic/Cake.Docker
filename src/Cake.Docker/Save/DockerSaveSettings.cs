namespace Cake.Docker
{
    /// <summary>
    ///  Settings for docker stop
    /// </summary>
    public sealed class DockerSaveSettings: AutoToolSettings
    {
        /// <summary>
        ///  Seconds to wait for stop before killing it.
        /// </summary>
        public string OutputString { get; set; }
    }
}
