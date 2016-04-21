namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerCpSettings: AutoToolSettings
    {
        public string[] Tag { get; set; }
        /// <summary>
        /// Always follow symbol link in SRC_PATH
        /// </summary>
        public bool FollowLink { get; set; }
    }
}
