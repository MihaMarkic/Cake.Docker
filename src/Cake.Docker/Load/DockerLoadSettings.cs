namespace Cake.Docker
{
    /// <summary>
    ///  Settings for docker stop
    /// </summary>
    public sealed class DockerLoadSettings: AutoToolSettings
    {
        /// <summary>
        /// Read from tar archive file, instead of STDIN.
        /// The tarball may be compressed with gzip, bzip, or xz
        /// </summary>
        public string InputString { get; set; }
    }
}
