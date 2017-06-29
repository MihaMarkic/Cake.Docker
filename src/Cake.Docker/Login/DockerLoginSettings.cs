namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker login.
    /// </summary>
    public sealed class DockerLoginSettings : AutoToolSettings
    {
        /// <summary>
        /// Password for login.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Username for login.
        /// </summary>
        public string Username { get; set; }
    }
}
