using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker swarm join [OPTIONS] HOST:PORT.
	/// Join a swarm as a node and/or manager
	/// </summary>
	public sealed partial class DockerSwarmJoinSettings : AutoToolSettings
	{
		/// <summary>
		/// --advertise-addr
		/// Advertised address (format: &lt;ip|interface&gt;[:port])
		/// </summary>
		public string AdvertiseAddr { get; set; }
		/// <summary>
		/// --availability
		/// default: active
		/// Availability of the node (active|pause|drain)
		/// </summary>
		public string Availability { get; set; }
		/// <summary>
		/// --data-path-addr
		/// Address or interface to use for data path traffic (format: &lt;ip|interface&gt;)
		/// </summary>
		public string DataPathAddr { get; set; }
		/// <summary>
		/// --listen-addr
		/// Listen address (format: &lt;ip|interface&gt;[:port])
		/// </summary>
		public string ListenAddr { get; set; }
		/// <summary>
		/// --token
		/// Token for entry into the swarm
		/// </summary>
		public string Token { get; set; }
	}
}