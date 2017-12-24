using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker login [OPTIONS] [SERVER].
	/// Log in to a Docker registry
	/// </summary>
	public sealed partial class DockerRegistryLoginSettings : AutoToolSettings
	{
		/// <summary>
		/// --password, -p
		/// Password
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// --password-stdin
		/// default: false
		/// Take the password from stdin
		/// </summary>
		public bool? PasswordStdin { get; set; }
		/// <summary>
		/// --username, -u
		/// Username
		/// </summary>
		public string Username { get; set; }
	}
}