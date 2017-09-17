using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker connect [OPTIONS] NETWORK CONTAINER.
	/// Connect a container to a network
	/// </summary>
	public sealed class DockerNetworkConnectSettings : AutoToolSettings
	{
		/// <summary>
		/// --alias
		/// default: 
		/// Add network-scoped alias for the container
		/// </summary>
		public string[] Alias { get; set; }
		/// <summary>
		/// --ip
		/// IPv4 address (e.g., 172.30.100.104)
		/// </summary>
		public string Ip { get; set; }
		/// <summary>
		/// --ip6
		/// IPv6 address (e.g., 2001:db8::33)
		/// </summary>
		public string Ip6 { get; set; }
		/// <summary>
		/// --link
		/// Add link to another container
		/// </summary>
		public string[] Link { get; set; }
		/// <summary>
		/// --link-local-ip
		/// default: 
		/// Add a link-local address for the container
		/// </summary>
		public string[] LinkLocalIp { get; set; }
	}
}