using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker stop [OPTIONS] CONTAINER [CONTAINER...].
	/// Stop one or more running containers
	/// </summary>
	public sealed partial class DockerContainerStopSettings : AutoToolSettings
	{
		/// <summary>
		/// --time, -t
		/// default: 10
		/// Seconds to wait for stop before killing it
		/// </summary>
		public int? Time { get; set; }
	}
}