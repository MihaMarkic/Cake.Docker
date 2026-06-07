namespace Cake.Docker;
/// <summary>
/// Settings for docker compose push.
/// </summary>
public sealed class DockerComposePushSettings : AutoToolSettings
{
	/// <summary>
	/// Push what it can and ignores images with
	/// push failures
	/// </summary>
	public bool? IgnorePushFailures { get; set; }
	/// <summary>
	/// Also push images of services declared as
	/// dependencies
	/// </summary>
	public bool? IncludeDeps { get; set; }
	/// <summary>
	/// Push without printing progress information
	/// </summary>
	public bool? Quiet { get; set; }
}
