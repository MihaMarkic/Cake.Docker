namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerSwarmInitSettings : AutoToolSettings
    {
        /// <summary>
        /// --advertise-addr 
        /// Advertised address (format: &lt;ip|interface&gt;[:port])
        /// </summary>
        public string AdvertiseAddr { get; set; }
        /// <summary>
        /// --autolock 
        /// default: false
        /// Enable manager autolocking (requiring an unlock key to start a stopped manager)
        /// </summary>
        public bool? Autolock { get; set; }
        /// <summary>
        /// --availability 
        /// default: active
        /// Availability of the node (“active”|“pause”|“drain”)
        /// </summary>
        public string Availability { get; set; }
        /// <summary>
        /// --cert-expiry 
        /// default: 2160h0m0s
        /// Validity period for node certificates (ns|us|ms|s|m|h)
        /// </summary>
        public string CertExpiry { get; set; }
        /// <summary>
        /// --data-path-addr 
        /// Address or interface to use for data path traffic (format: &lt;ip|interface&gt;)
        /// </summary>
        public string DataPathAddr { get; set; }
        /// <summary>
        /// --dispatcher-heartbeat 
        /// default: 5s
        /// Dispatcher heartbeat period (ns|us|ms|s|m|h)
        /// </summary>
        public string DispatcherHeartbeat { get; set; }
        /// <summary>
        /// --external-ca 
        /// Specifications of one or more certificate signing endpoints
        /// </summary>
        public string ExternalCa { get; set; }
        /// <summary>
        /// --force-new-cluster 
        /// default: false
        /// Force create a new cluster from current state
        /// </summary>
        public bool? ForceNewCluster { get; set; }
        /// <summary>
        /// --listen-addr 
        /// default: 0.0.0.0:2377
        /// Listen address (format: &lt;ip|interface&gt;[:port])
        /// </summary>
        public string ListenAddr { get; set; }
        /// <summary>
        /// --max-snapshots 
        /// default: 0
        /// Number of additional Raft snapshots to retain
        /// </summary>
        public int? MaxSnapshots { get; set; }
        /// <summary>
        /// --snapshot-interval 
        /// default: 10000
        /// Number of log entries between Raft snapshots
        /// </summary>
        public int? SnapshotInterval { get; set; }
        /// <summary>
        /// --task-history-limit 
        /// default: 5
        /// Task history retention limit
        /// </summary>
        public int? TaskHistoryLimit { get; set; }
    }
}

