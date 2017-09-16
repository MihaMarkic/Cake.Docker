using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker save [OPTIONS] IMAGE [IMAGE...].
	/// Save one or more images to a tar archive (streamed to STDOUT by default)
	/// </summary>
	public sealed class DockerSaveSettings : AutoToolSettings
	{
		/// <summary>
		/// --output, -o
		/// Write to a file, instead of STDOUT
		/// </summary>
		public string Output { get; set; }
	}
}