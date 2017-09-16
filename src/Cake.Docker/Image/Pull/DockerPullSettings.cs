using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker pull [OPTIONS] NAME[:TAG|@DIGEST].
	/// Pull an image or a repository from a registry
	/// </summary>
	public sealed class DockerPullSettings : AutoToolSettings
	{
		/// <summary>
		/// --all-tags, -a
		/// default: false
		/// Download all tagged images in the repository
		/// </summary>
		public bool? AllTags { get; set; }
		/// <summary>
		/// --disable-content-trust
		/// default: true
		/// Skip image verification
		/// </summary>
		public bool? DisableContentTrust { get; set; }
	}
}