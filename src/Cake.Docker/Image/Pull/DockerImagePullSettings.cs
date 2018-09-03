using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker pull [OPTIONS] NAME[:TAG|@DIGEST].
	/// Pull an image or a repository from a registry
	/// </summary>
	public sealed partial class DockerImagePullSettings : AutoToolSettings
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
        [AutoProperty(Format = Constants.BoolWithTrueDefaultFormat)]
		public bool? DisableContentTrust { get; set; }
		/// <summary>
		/// --platform
		/// Set platform if server is multi-platform capable
		/// </summary>
		public string Platform { get; set; }
	}
}