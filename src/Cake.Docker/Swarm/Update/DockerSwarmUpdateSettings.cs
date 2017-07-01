namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerSwarmUpdateSettings : AutoToolSettings
    {
        /// <summary>
        /// --autolock 
        /// default: false
        /// Change manager autolocking setting (true|false)
        /// </summary>
        public bool? Autolock { get; set; }
        /// <summary>
        /// --cert-expiry 
        /// default: 2160h0m0s
        /// Validity period for node certificates (ns|us|ms|s|m|h)
        /// </summary>
        public string CertExpiry { get; set; }
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

