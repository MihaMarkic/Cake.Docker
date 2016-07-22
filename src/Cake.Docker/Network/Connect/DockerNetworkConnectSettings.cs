namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerNetworkConnectSettings : AutoToolSettings
    {
        /// <summary>
        /// Add network-scoped alias for the container (default [])
        /// </summary>
        public string[] Alias { get; set; }
        /// <summary>
        /// IP Address
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// IPv6 Address
        /// </summary>
        public string Ip6 { get; set; }
        /// <summary>
        /// Add link to another container (default [])
        /// </summary>
        public string[] Link { get; set; }
        /// <summary>
        /// Add a link-local address for the container (default [])
        /// </summary>
        public string[] LinkLocalIp { get; set; }
    }
}
