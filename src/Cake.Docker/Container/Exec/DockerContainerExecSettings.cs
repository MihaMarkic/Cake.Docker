using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker exec [OPTIONS] CONTAINER COMMAND [ARG...].
	/// Run a command in a running container
	/// </summary>
	public sealed class DockerContainerExecSettings : AutoToolSettings
	{
		/// <summary>
		/// --detach, -d
		/// default: false
		/// Detached mode: run command in the background
		/// </summary>
		public bool? Detach { get; set; }
		/// <summary>
		/// --detach-keys
		/// Override the key sequence for detaching a container
		/// </summary>
		public string DetachKeys { get; set; }
		/// <summary>
		/// --env, -e
		/// Set environment variables
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public string[] Env { get; set; }
		/// <summary>
		/// --interactive, -i
		/// default: false
		/// Keep STDIN open even if not attached
		/// </summary>
		public bool? Interactive { get; set; }
		/// <summary>
		/// --privileged
		/// default: false
		/// Give extended privileges to the command
		/// </summary>
		public bool? Privileged { get; set; }
		/// <summary>
		/// --tty, -t
		/// default: false
		/// Allocate a pseudo-TTY
		/// </summary>
		public bool? Tty { get; set; }
		/// <summary>
		/// --user, -u
		/// Username or UID (format: &lt;name|uid&gt;[:&lt;group|gid&gt;])
		/// </summary>
		public string User { get; set; }
	}
}