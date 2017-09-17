using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker update [OPTIONS].
	/// Update the swarm
	/// </summary>
	public sealed class DockerSwarmUpdateSettings : AutoToolSettings
	{
		/// <summary>
		/// --cert-expiry
		/// default: 90*24*time.Hour
		/// Validity period for node certificates (ns|us|ms|s|m|h)
		/// </summary>
		public string CertExpiry { get; set; }
		/// <summary>
		/// --dispatcher-heartbeat
		/// default: 5*time.Second
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
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public UInt64? MaxSnapshots { get; set; }
		/// <summary>
		/// --snapshot-interval
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public UInt64? SnapshotInterval { get; set; }
		/// <summary>
		/// --task-history-limit
		/// default: 5
		/// Task history retention limit
		/// </summary>
		public Int64? TaskHistoryLimit { get; set; }
	}
}