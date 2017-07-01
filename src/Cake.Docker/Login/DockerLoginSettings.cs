namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker login.
    /// </summary>
    public sealed class DockerLoginSettings : AutoToolSettings
    {
        /// <summary>
        /// --password, -p 
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// --username, -u 
        /// Username
        /// </summary>
        public string Username { get; set; }
    }
}
