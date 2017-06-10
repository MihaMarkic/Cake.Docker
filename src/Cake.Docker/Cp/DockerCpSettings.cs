namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker cp command.
    /// </summary>
    public sealed class DockerCpSettings: AutoToolSettings
    {
        /// <summary>
        /// Always follow symbol link in SRC_PATH
        /// </summary>
        public bool FollowLink { get; set; }
    }
}
