using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker swarm leave [OPTIONS].
	/// Leave the swarm
	/// </summary>
	public sealed partial class DockerSwarmLeaveSettings : AutoToolSettings
	{
		/// <summary>
		/// --force, -f
		/// default: false
		/// Force this node to leave the swarm, ignoring warnings
		/// </summary>
		public bool? Force { get; set; }
	}
}