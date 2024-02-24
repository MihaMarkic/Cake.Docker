namespace Cake.Docker;
/// <summary>
/// Settings for docker compose cp.
/// </summary>
public sealed class DockerComposeCpSettings : AutoToolSettings
{
	/// <summary>
	/// Archive mode (copy all uid/gid information)
	/// </summary>
	public bool? Archive { get; set; }
	/// <summary>
	/// Always follow symbol link in SRC_PATH
	/// </summary>
	public bool? FollowLink { get; set; }
	/// <summary>
	/// index of the container if service has multiple replicas
	/// </summary>
	public int? Index { get; set; }
}
