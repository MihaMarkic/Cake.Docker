namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker login.
    /// </summary>
    public sealed class DockerLoginSettings : AutoToolSettings
    {
        /// <summary>
        /// Email for login. Depreciated in Docker 1.11.0.
        /// </summary>
        public string Email { get; set; }
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
