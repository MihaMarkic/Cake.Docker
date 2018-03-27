using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker Use: `cp [OPTIONS] CONTAINER:SRC_PATH DEST_PATH|-.
	/// Copy files/folders between a container and the local filesystem
	/// </summary>
	public sealed partial class DockerContainerCpSettings : AutoToolSettings
	{
		/// <summary>
		/// --archive, -a
		/// default: false
		/// Archive mode (copy all uid/gid information)
		/// </summary>
		public bool? Archive { get; set; }
		/// <summary>
		/// --follow-link, -L
		/// default: false
		/// Always follow symbol link in SRC_PATH
		/// </summary>
		public bool? FollowLink { get; set; }
	}
}