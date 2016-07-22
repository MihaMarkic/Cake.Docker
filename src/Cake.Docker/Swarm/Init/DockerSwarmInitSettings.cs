using System;

namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerSwarmInitSettings : AutoToolSettings
    {
        /// <summary>
        /// Auto acceptance policy (default worker)
        /// </summary>
        public string AutoAccept { get; set; }
        /// <summary>
        /// Validity period for node certificates (default 2160h0m0s)
        /// </summary>
        public TimeSpan? CertExpiry { get; set; }
        /// <summary>
        /// Dispatcher heartbeat period (default 5s)
        /// </summary>
        public TimeSpan? DispatcherHeartbeat { get; set; }
        /// <summary>
        /// Specifications of one or more certificate signing endpoints
        /// </summary>
        public string ExternalCa { get; set; }
        /// <summary>
        /// Force create a new cluster from current state.
        /// </summary>
        public bool ForceNewCluster { get; set; }
        /// <summary>
        /// Listen address (default 0.0.0.0:2377)
        /// </summary>
        public string ListenAddr { get; set; }
        /// <summary>
        /// Set secret value needed to accept nodes into cluster
        /// </summary>
        public bool Secret { get; set; }
        /// <summary>
        /// Task history retention limit (default 10)
        /// </summary>
        public bool TaskHistoryLimit { get; set; }
    }
}
