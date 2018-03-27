using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker start [OPTIONS] CONTAINER [CONTAINER...].
	/// Start one or more stopped containers
	/// </summary>
	public sealed partial class DockerContainerStartSettings : AutoToolSettings
	{
		/// <summary>
		/// --attach, -a
		/// default: false
		/// Attach STDOUT/STDERR and forward signals
		/// </summary>
		public bool? Attach { get; set; }
		/// <summary>
		/// --checkpoint
		/// Restore from this checkpoint
		/// </summary>
		/// <remarks>
		/// Experimental
		/// </remarks>
		public string Checkpoint { get; set; }
		/// <summary>
		/// --checkpoint-dir
		/// Use a custom checkpoint storage directory
		/// </summary>
		/// <remarks>
		/// Experimental
		/// </remarks>
		public string CheckpointDir { get; set; }
		/// <summary>
		/// --detach-keys
		/// Override the key sequence for detaching a container
		/// </summary>
		public string DetachKeys { get; set; }
		/// <summary>
		/// --interactive, -i
		/// default: false
		/// Attach container&#39;s STDIN
		/// </summary>
		public bool? Interactive { get; set; }
	}
}