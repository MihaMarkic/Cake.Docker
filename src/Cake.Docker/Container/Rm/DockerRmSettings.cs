using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker rm [OPTIONS] CONTAINER [CONTAINER...].
	/// Remove one or more containers
	/// </summary>
	public sealed class DockerRmSettings : AutoToolSettings
	{
		/// <summary>
		/// --force, -f
		/// default: false
		/// Force the removal of a running container (uses SIGKILL)
		/// </summary>
		public bool? Force { get; set; }
		/// <summary>
		/// --link, -l
		/// default: false
		/// Remove the specified link
		/// </summary>
		public bool? Link { get; set; }
		/// <summary>
		/// --volumes, -v
		/// default: false
		/// Remove the volumes associated with the container
		/// </summary>
		public bool? Volumes { get; set; }
	}
}