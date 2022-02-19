namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker compose cp.
	/// </summary>
	public sealed class DockerComposeCpSettings : AutoToolSettings
	{
		/// <summary>
		/// Copy to all the containers of the service.
		/// </summary>
		public bool All { get; set; }
		/// <summary>
		/// Archive mode (copy all uid/gid information)
		/// </summary>
		public bool Archive { get; set; }
		/// <summary>
		/// Always follow symbol link in SRC_PATH
		/// </summary>
		public bool FollowLink { get; set; }
		/// <summary>
		/// Index of the container if there are multiple
		///   instances of a service [default: 1]. (default 1)
		/// </summary>
		public int? Index { get; set; }
	}
}