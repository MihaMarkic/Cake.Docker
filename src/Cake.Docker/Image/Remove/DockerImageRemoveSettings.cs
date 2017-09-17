using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker rmi [OPTIONS] IMAGE [IMAGE...].
	/// Remove one or more images
	/// </summary>
	public sealed class DockerImageRemoveSettings : AutoToolSettings
	{
		/// <summary>
		/// --force, -f
		/// default: false
		/// Force removal of the image
		/// </summary>
		public bool? Force { get; set; }
		/// <summary>
		/// --no-prune
		/// default: false
		/// Do not delete untagged parents
		/// </summary>
		public bool? NoPrune { get; set; }
	}
}