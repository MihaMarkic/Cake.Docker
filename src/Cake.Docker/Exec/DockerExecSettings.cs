namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker exec command.
    /// </summary>
    public sealed class DockerExecSettings: AutoToolSettings
    {
        /// <summary>
        /// Always follow symbol link in SRC_PATH
        /// </summary>
        public bool FollowLink { get; set; }
    }
}
