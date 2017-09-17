using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker load [OPTIONS].
	/// Load an image from a tar archive or STDIN
	/// </summary>
	public sealed class DockerImageLoadSettings : AutoToolSettings
	{
		/// <summary>
		/// --input, -i
		/// Read from tar archive file, instead of STDIN
		/// </summary>
		public string Input { get; set; }
		/// <summary>
		/// --quiet, -q
		/// default: false
		/// Suppress the load output
		/// </summary>
		public bool? Quiet { get; set; }
	}
}