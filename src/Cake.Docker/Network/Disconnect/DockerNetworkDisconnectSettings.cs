using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker disconnect [OPTIONS] NETWORK CONTAINER.
	/// Disconnect a container from a network
	/// </summary>
	public sealed partial class DockerNetworkDisconnectSettings : AutoToolSettings
	{
		/// <summary>
		/// --force, -f
		/// default: false
		/// Force the container to disconnect from a network
		/// </summary>
		public bool? Force { get; set; }
	}
}