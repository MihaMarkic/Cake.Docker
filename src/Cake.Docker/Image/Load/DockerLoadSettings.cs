namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker swarm init.
	/// </summary>
	public sealed class DockerLoadSettings : AutoToolSettings
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
