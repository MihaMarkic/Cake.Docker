namespace Cake.Docker
{
    /// <summary>
    ///  Settings for docker stop
    /// </summary>
    public sealed class DockerSaveSettings: AutoToolSettings
    {
        /// <summary>
        /// Write to a file, instead of STDOUT
        /// </summary>
        public string OutputString { get; set; }
    }
}
