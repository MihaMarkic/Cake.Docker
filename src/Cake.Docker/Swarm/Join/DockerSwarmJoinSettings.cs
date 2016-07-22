namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerSwarmJoinSettings : AutoToolSettings
    {
        /// <summary>
        /// Hash of the Root Certificate Authority certificate used for trusted join
        /// </summary>
        public string CaHash { get; set; }
        /// <summary>
        /// Listen address (default 0.0.0.0:2377)
        /// </summary>
        public string ListenAddr { get; set; }
        /// <summary>
        /// Try joining as a manager.
        /// </summary>
        public bool Manager { get; set; }
        /// <summary>
        /// Secret for node acceptance
        /// </summary>
        public string Secret { get; set; }
    }
}
